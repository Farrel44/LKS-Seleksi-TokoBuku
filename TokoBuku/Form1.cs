using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace TokoBuku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from Login where UserName = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }

            else if (dtbl.Rows[0][1].ToString() == "2")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            
            else
            {
                MessageBox.Show("Username dan password yang anda masukkan tidak ada di database", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
