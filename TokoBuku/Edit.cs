using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TokoBuku
{
    public partial class Edit : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;");
        public Edit()
        {
            InitializeComponent();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Store SET Isbn = @Isbn, Judul = @Judul_Baru, Penulis = @Penulis, Stok = @Stok, Harga = @Harga WHERE Judul = @Judul_Lama";
            cmd.Parameters.AddWithValue("@Judul_Lama", textBox1.Text);
            cmd.Parameters.AddWithValue("@Isbn", numericUpDown2.Value);
            cmd.Parameters.AddWithValue("@Judul_Baru", textBox3.Text);
            cmd.Parameters.AddWithValue("@Penulis", textBox2.Text);
            cmd.Parameters.AddWithValue("@Stok", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@Harga", numericUpDown3.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data buku berhasil diubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information );
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            this.Hide();
        }
    }
}
