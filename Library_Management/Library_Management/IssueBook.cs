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
                textBox1.Text = dr["Column1Name"].ToString(); // Replace "Column1Name" with the actual column name
                textBox6.Text = dr["Column2Name"].ToString(); // Replace "Column2Name" with the actual column name
                textBox3.Text = dr["Column3Name"].ToString(); // Replace "Column3Name" with the actual column name
                textBox2.Text = dr["Column4Name"].ToString(); // Replace "Column4Name" with the actual column name
                comboBox1.SelectedValue = dr["Column5Name"].ToString(); // Replace "Column5Name" with the actual column name
                dateTimePicker1.Value = Convert.ToDateTime(dr["DateColumnName"]); // Replace "DateColumnName" with the actual column nam
            }
            dr.Close();
            con.Close();
        }
    }
}
