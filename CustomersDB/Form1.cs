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
    public partial class Form1 : Form
    {
        DataTable mytable = new DataTable();
        SqlConnection myconn = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Establish a connection and pick file location
            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();
         
            // make an sql command object
            SqlCommand mycmd;
            mycmd = new SqlCommand();
            mycmd.CommandText = "Select * from Customer_T";
            mycmd.Connection = myconn;

            // create an adapter (message carrying are request)
            SqlDataAdapter myadapter;
            myadapter = new SqlDataAdapter();
            myadapter.SelectCommand = mycmd;

            DataTable mydt;
            mydt = new DataTable();
            myadapter.Fill(mydt);

            dataGridView1.DataSource = mydt;

        }

        private void gr(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //  Establish a connection and pick file location
            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();


            //SqlCommand mycmd;
            // mycmd = new SqlCommand();
            // mycmd.CommandText = "Select * from Customer_T where CustomerState = '" + textBox1.Text + "'";


            SqlCommand mycommand = new SqlCommand();
            mycommand.CommandText = "Select * from Customer_T where CustomerState = '" + textBox1.Text + "'";


            mycommand.CommandText = "Select * from Customer_T where CustomerState = @state and CustomerName like @name";
            mycommand.Parameters.Add("@state", SqlDbType.NChar, 20);
            mycommand.Parameters["@state"].Value = textBox1.Text;


            mycommand.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            mycommand.Parameters["@name"].Value = "%" + textBox2.Text + "%";
            mycommand.Connection = myconn;

            SqlDataAdapter myadapter;
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
           mytable.Rows[1].SetField(2, "ABC");

        }

        private void DbUpdate_Click(object sender, EventArgs e)

        {
            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();

            SqlCommand updcmd;
            updcmd = new SqlCommand();
            updcmd.Connection = myconn;
            updcmd.CommandText = "Update Customer_T set CustomerName = @customername " + "where CustomerID = @customerid and"
                ;
            updcmd.Parameters.Add("@customername", SqlDbType.NVarChar, 50, "CustomerName");


            updcmd.Parameters.Add("@customername", SqlDbType.NVarChar, 50, "CustomerName");
            updcmd.Parameters.Add("@customerid", SqlDbType.Int, 50, "CustomerID");
            SqlDataAdapter myadapter = new SqlDataAdapter();
            myadapter.UpdateCommand = updcmd;

            SqlCommand delcmd;
            delcmd = new SqlCommand();
            delcmd.Connection = myconn;
            delcmd.CommandText = "Delete Customer_T where CustomerID = @customerid ";
            delcmd.Parameters.Add("@customerid", SqlDbType.Int, 50, "CustomerID");

            myadapter.DeleteCommand = delcmd;
            myadapter.Update(mytable);
        }
    }
}
