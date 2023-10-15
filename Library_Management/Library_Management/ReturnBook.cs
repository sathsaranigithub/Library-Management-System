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
    public partial class ReturnBook : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-O2IU0D16\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewIssueBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EnrollmentNo", SqlDbType.NVarChar).Value = textBox7.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          if (e.RowIndex >= 0)
            {
              DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update_issueBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Return_Date", SqlDbType.NVarChar).Value = dateTimePicker1.Value.ToShortDateString();
            cmd.ExecuteNonQuery();
            MessageBox.Show("book returned");
            con.Close();
        }
    }
}
