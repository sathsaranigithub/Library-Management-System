using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AddBook ab = new AddBook();
            ab.Show();
            this.Hide();
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IssueBook ib = new IssueBook();
            ib.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            rb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IssueBookReport ibr = new IssueBookReport();
            ibr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnBookReport rbr = new ReturnBookReport();
            rbr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            ViewStudent vs = new ViewStudent();
            vs.Show();
        }
    }
}
