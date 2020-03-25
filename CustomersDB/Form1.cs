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
        SqlDataAdapter myadapter;
        DataTable mytable;
        SqlConnection myconn;
        SqlCommand mycmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Establish a connection and pick file location
            myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();
         
            // make an sql command object
            mycmd = new SqlCommand();
            // Find out how to get search working in one text box 
            //mycmd.CommandText = "Select * from Order_T ";
            
            String query1 = mycmd.CommandText = "Select * from Order_T where OrderID = @my_order_id";
           
            mycmd.Parameters.Add("@my_order_id", SqlDbType.NVarChar, 30);
            mycmd.Parameters["@my_order_id"].Value = textBox1.Text;
            //mycmd.Parameters.Add(query1, SqlDbType.NVarChar, 30);
            //mycmd.Parameters[query1].Value = textBox1.Text;


            String query2 = mycmd.CommandText = "Select * from Order_T where OrderDate = @order_date";
            mycmd.Parameters.Add("@order_date", SqlDbType.NVarChar, 30);
            mycmd.Parameters["@order_date"].Value = textBox2.Text;


            String query3 = mycmd.CommandText = "Select * from Order_T where CustomerID = @my_customer_id";
            mycmd.Parameters.Add("@my_customer_id", SqlDbType.NVarChar, 30);
            mycmd.Parameters["@my_customer_id"].Value = textBox3.Text;


            mycmd.Connection = myconn;

            // create an adapter (message carrying are request)
            myadapter = new SqlDataAdapter();
            myadapter.SelectCommand = mycmd;

            mytable = new DataTable();
            myadapter.Fill(mytable);

            //dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = mytable;

        }

        private void gr(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {





            //  Establish a connection and pick file location
          //  SqlConnection myconn;
          //  myconn = new SqlConnection();
          //  myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\joshu\\Downloads\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
          //  myconn.Open();


          //  //SqlCommand mycmd;
          //  // mycmd = new SqlCommand();
          //  // mycmd.CommandText = "Select * from Customer_T where CustomerState = '" + textBox1.Text + "'";


          //  SqlCommand mycommand = new SqlCommand();
          //  mycommand.CommandText = "Select * from Order_T where OrderID = '" + textBox1.Text + "'";


          //  mycommand.CommandText = "Select * from Order_T where OrderDate = @state and CustomerID like @name";
          //  mycommand.Parameters.Add("@state", SqlDbType.NVarChar, 50);
          //  mycommand.Parameters["@state"].Value = textBox1.Text;


          //  mycommand.Parameters.Add("@name", SqlDbType.NVarChar, 50);
          //  mycommand.Parameters["@name"].Value = "%" + textBox2.Text + "%";
          //  mycommand.Connection = myconn;

          //  SqlDataAdapter myadapter;
          //  myadapter = new SqlDataAdapter();
          //  myadapter.SelectCommand = mycommand;

          ////  mytable = new DataTable();
          //     myadapter.Fill(mytable);

          //  dataGridView1.AutoGenerateColumns = false;
          //  dataGridView1.DataSource = mytable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mytable.Rows[1].ItemArray[2].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
           mytable.Rows[1].SetField(2, "ABC");

        }
    }
}
