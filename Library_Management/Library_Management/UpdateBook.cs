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
    public partial class UpdateBook : Form
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-O2IU0D16\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public UpdateBook()
        {
            InitializeComponent();
        }

        private void UpdateBook_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newBookName = textBox2.Text;
            string newAuthorName = textBox3.Text;
            string newPublication = textBox4.Text;
            DateTime newPurchaseDate = dateTimePicker1.Value; // Make sure to use the appropriate data type for dates.
            string newBookPrice = textBox5.Text;
            string newQuantity = textBox6.Text;

            if (string.IsNullOrEmpty(newBookName))
            {
                MessageBox.Show("Please provide a new book name.");
                return;
            }

            if (!int.TryParse(textBox7.Text, out int bookId))
            {
                MessageBox.Show("Invalid Book ID.");
                return;
            }

            con.Open();

            // Create an SQL UPDATE query
            string updateQuery = "UPDATE tb1_books SET BookName = @NewBookName, AuthorName = @NewAuthorName, Publication = @NewPublication, PurchaseDate = @NewPurchaseDate, BookPrice = @NewBookPrice, Quantity = @NewQuantity WHERE BookID = @BookId";

            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.Add(new SqlParameter("@NewBookName", SqlDbType.NVarChar, 30)).Value = newBookName;
                cmd.Parameters.Add(new SqlParameter("@NewAuthorName", SqlDbType.NVarChar, 30)).Value = newAuthorName;
                cmd.Parameters.Add(new SqlParameter("@NewPublication", SqlDbType.NVarChar, 30)).Value = newPublication;
                cmd.Parameters.Add(new SqlParameter("@NewPurchaseDate", SqlDbType.DateTime)).Value = newPurchaseDate;
                cmd.Parameters.Add(new SqlParameter("@NewBookPrice", SqlDbType.NVarChar, 20)).Value = newBookPrice;
                cmd.Parameters.Add(new SqlParameter("@NewQuantity", SqlDbType.NVarChar, 30)).Value = newQuantity;
                cmd.Parameters.Add(new SqlParameter("@BookId", SqlDbType.Int)).Value = bookId;

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Book with BookID {bookId} updated to {newBookName}.");
                }
                else
                {
                    MessageBox.Show($"No records updated. Book with BookID {bookId} not found.");
                }
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddBook AB = new AddBook();
            AB.Show();
            this.Hide();
        }
    }
}
