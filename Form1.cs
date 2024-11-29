using CURD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CURD
{
    public partial class Form1 : Form
    {
        public object SHRITI { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SHRITI\\SQLEXPRESS;Initial Catalog=CURD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into user1 values (@ID , @NAME, @AGE)" ,con);
            cmd.Parameters.AddWithValue("@id" , int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@NAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@AGE", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Entered Data ");

        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SHRITI\\SQLEXPRESS;Initial Catalog=CURD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(" update user1 set NAME=@NAME ,AGE=@AGE where ID=@ID ",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@NAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@AGE", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Updated Successfully ");

        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SHRITI\\SQLEXPRESS;Initial Catalog=CURD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(" delete user1 where ID=@ID ",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Deleted Successfully ");

        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SHRITI\\SQLEXPRESS;Initial Catalog=CURD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from user1",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;


        }
    }
}




//WHILE CONNECTING TO SQL SERVER 
//Connection SHOULD BE MADE USING OPTIONAL SETUP 