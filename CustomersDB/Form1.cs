using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomersDB
{
    // Make a desktop application that maintains the data in the Employee Table.
    // Make a FILL button to search on a value contained in the Employee Name.
    // Your application should be able to add, delete and update, and check 
    // for concurrency.Also, see what happens if you put a Supervisor ID 
    // that is not in the table(foreign-key reference error).
    public partial class Form1 : Form
    {
        DataTable mytable;
        SqlDataAdapter myadapter;
        SqlCommand updcmd;
        SqlCommand delcmd;
        SqlCommand mycmd;
        SqlCommand mycommand;
        SqlCommand insertcmd;
        SqlTransaction myTrans;


        public Form1()
        {
            InitializeComponent();
        }

        // fill Button
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();

            // make an sql command object
            mycmd = new SqlCommand();
            mycmd.CommandText = "Select * from Employee_T where EmployeeName = @name";


            mycmd.Parameters.Add("@name", SqlDbType.NChar, 20);
            mycmd.Parameters["@name"].Value = textBox1.Text;


            mycmd.Connection = myconn;

            // create an adapter (message carrying are request)
            myadapter = new SqlDataAdapter();
            myadapter.SelectCommand = mycmd;

            mytable = new DataTable();
            myadapter.Fill(mytable);

            dataGridView1.DataSource = mytable;

        }

        private void gr(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();


            mycommand = new SqlCommand();


            mycommand.CommandText = "Select * from Employee_T where EmployeeState = @state and EmployeeName like @name";
            mycommand.CommandText = "Select * from Employee_T";

            mycommand.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            mycommand.Parameters["@name"].Value = "%" + textBox1.Text + "%";

            mycommand.Parameters.Add("@state", SqlDbType.NChar, 20);
            mycommand.Parameters["@state"].Value = textBox2.Text;


            mycommand.Connection = myconn;

            myadapter = new SqlDataAdapter();
            myadapter.SelectCommand = mycommand;

            mytable = new DataTable();
            myadapter.Fill(mytable);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = mytable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mytable.Rows[1].ItemArray[2].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();

            insertcmd = new SqlCommand();
            insertcmd.Connection = myconn;

            insertcmd.CommandText = "Insert Into Employee_T Values (@id,@name,@address," +
                "@city,@state,@zip_code,@supervisor,@date_hired)";

            insertcmd.Parameters.Add("@id", SqlDbType.NVarChar, 50, "EmployeeID");
            insertcmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "EmployeeName");
            insertcmd.Parameters.Add("@address", SqlDbType.NVarChar, 50, "EmployeeAddress");
            insertcmd.Parameters.Add("@city", SqlDbType.NVarChar, 50, "EmployeeCity");
            insertcmd.Parameters.Add("@state", SqlDbType.NVarChar, 2, "EmployeeState");
            insertcmd.Parameters.Add("@zip_code", SqlDbType.NVarChar, 10, "EmployeeZipCode");
            insertcmd.Parameters.Add("@supervisor", SqlDbType.NVarChar, 10, "EmployeeSupervisor");
            insertcmd.Parameters.Add("@date_hired", SqlDbType.DateTime, 11, "EmployeeDateHired");

            myadapter = new SqlDataAdapter();
            myadapter.InsertCommand = insertcmd;





            try
            {
                myadapter.Update(mytable);
                MessageBox.Show("Data Inserted ");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Insert ");
            }

        }

        private void DbUpdate_Click(object sender, EventArgs e)

        {
            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();

            myTrans = myconn.BeginTransaction(IsolationLevel.ReadUncommitted);

            updcmd = new SqlCommand();
            updcmd.Connection = myconn;
            updcmd.Transaction = myTrans;



            updcmd.CommandText = "Update Employee_T set EmployeeName = @name " + "where EmployeeID = @id and"
             + " EmployeeVersion = @version";

            updcmd.Parameters.Add("@version", SqlDbType.Binary, 50, "EmployeeVersion");
            updcmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "EmployeeName");
            updcmd.Parameters.Add("@id", SqlDbType.Int, 50, "EmployeeID");

            myadapter.UpdateCommand = updcmd;

           

            // changinging data is important take into account if data is link like if you change data of someone in a
            // insurance database
            // you wouldnt want update to continue if there are multiple updates being done at same time then system try to update 
            // the same time you would want it to stop and not continue or but if rows and changes are indepent you would
            // want updates to continue since they arent related thus you wont get alot of problems 
            myadapter.ContinueUpdateOnError = true;
            try
            {
                myadapter.Update(mytable);

            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Database has been updated - please refill grid and make updates ");
            }

        }

        private void CommitBT_Click(object sender, EventArgs e)
        {
            myTrans.Commit();

        }

        private void DeleteBT_Click(object sender, EventArgs e)
        {

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();


            delcmd = new SqlCommand();
            delcmd.Connection = myconn;


            delcmd.CommandText = "Delete Employee_T where EmployeeName = @name ";

            delcmd.Parameters.Add("@name", SqlDbType.Int, 50, "EmployeeID");
            delcmd.Parameters["@name"].Value = textBox1.Text;

            myadapter = new SqlDataAdapter();

            myadapter.DeleteCommand = delcmd;


            try
            {
                myadapter.Update(mytable);
                MessageBox.Show("Data row deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete the row");
            }

        }
    }
}
