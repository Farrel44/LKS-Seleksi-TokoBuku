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
    public partial class Add : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False");

        public Add()
        {
            InitializeComponent();
        }

        private void Beli_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Store] (Isbn, Judul, Penulis, Stok, Harga) values (@Isbn, @Judul, @Penulis, @Stok, @Harga)";
            cmd.Parameters.AddWithValue("@Judul", textBox1.Text);
            cmd.Parameters.AddWithValue("@Penulis", textBox2.Text);
            cmd.Parameters.AddWithValue("@Stok", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@Isbn", numericUpDown2.Value);
            cmd.Parameters.AddWithValue("@Harga", numericUpDown3.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            MessageBox.Show("Buku baru berhasil dimasukkan ke database!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Hide();
        }
    }
}
