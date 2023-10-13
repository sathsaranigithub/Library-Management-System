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

namespace Library_Management
{
    public partial class AddStudent : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-O2IU0D16\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashbord dab = new Dashbord();
            dab.Show();
            this.Hide();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_addStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Enrollment_Number", SqlDbType.NVarChar).Value = textBox6.Text;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@contact", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@Semester", SqlDbType.NVarChar).Value = textBox5.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student details added");
            con.Close();
            textBox1.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
