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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Establish a connection and pick file location
            SqlConnection myconn;
            myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();
         
            // make an sql command object
            SqlCommand mycmd;
            mycmd = new SqlCommand();
            mycmd.CommandText = "Select * from Order_T where OrderID = @orderid";
            mycmd.Parameters.Add("@orderid", SqlDbType.NVarChar, 30);
            mycmd.Parameters["@orderid"].Value = textBox1.Text;
            mycmd.Connection = myconn;

            // create an adapter (message carrying are request)
            SqlDataAdapter myadapter;
            myadapter = new SqlDataAdapter();
            myadapter.SelectCommand = mycmd;



            myadapter.Fill(mytable);

            dataGridView1.AutoGenerateColumns = false;
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
