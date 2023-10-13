using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-O2IU0D16\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = textBox2.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Dashbord db = new Dashbord();
                    db.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}

