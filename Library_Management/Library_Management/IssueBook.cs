using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management
{
    public partial class IssueBook : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-O2IU0D16\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_getbooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString()); 
            }
            dr.Close(); 
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EnrollmentNo", SqlDbType.NVarChar).Value = textBox7.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                textBox1.Text = dr[0].ToString(); 
                textBox6.Text = dr[1].ToString(); 
                textBox3.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addissuebook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Enrollment_no", SqlDbType.NVarChar).Value = textBox6.Text;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = comboBox1.Text;
            cmd.Parameters.Add("@Issue_Date", SqlDbType.NVarChar).Value = dateTimePicker1.Value.ToShortDateString();
            cmd.Parameters.Add("@Return_Date", SqlDbType.NVarChar).Value = "";
            // cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = textBox5.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Issued Book added");
            con.Close();
            textBox1.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
