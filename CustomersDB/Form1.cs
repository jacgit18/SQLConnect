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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myconn;
            myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\joshu\\Downloads\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();
         
            SqlCommand mycmd;
            mycmd = new SqlCommand();
            mycmd.CommandText = "Select * from Customer_T";
            mycmd.Connection = myconn;

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
            SqlConnection myconn;
            myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\joshu\\Downloads\\pvfc\\PVFC.mdf;Integrated Security=True;Connect Timeout=30";
            myconn.Open();


            SqlCommand mycmd;
            mycmd = new SqlCommand();
            mycmd.CommandText = "Select * from Customer_T where CustomerState = '" + textBox1.Text + "'";
            mycmd.Connection = myconn;

            SqlDataAdapter myadapter;
            myadapter = new SqlDataAdapter();
            myadapter.SelectCommand = mycmd;

            DataTable mydt;
            mydt = new DataTable();
            myadapter.Fill(mydt);

            dataGridView1.DataSource = mydt;
        }
    }
}
