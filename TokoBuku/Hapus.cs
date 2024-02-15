using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokoBuku
{
    public partial class Hapus : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False");
        public Hapus()
        {
            InitializeComponent();
        }

        private void Hapus_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Store where Judul = @Judul";
            cmd.Parameters.AddWithValue("@Judul", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Buku berhasil dihapus dari database", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            conn.Close();
            this.Hide();
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.Hide();
        }
    }
}
