using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokoBuku
{
    public partial class Beli : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False");

        private int GetHargaFromDatabase()
        {
            int harga = 0;

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False"))
            {
                string query = "Select Harga from Store where Judul = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    object hasil = cmd.ExecuteScalar();
                    if (hasil != null && hasil != DBNull.Value)
                    {
                        harga = (int)hasil;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error mendapatkan harga untuk judul tersebut" + ex.Message);
                }
                return harga;
            }
        }

        private int GetStokFromDatabase()
        {
            int stok = 0;

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False"))
            {
                string query = "Select Stok from Store where Judul = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    object hasil = cmd.ExecuteScalar();
                    if (hasil != null && hasil != DBNull.Value)
                    {
                        stok = (int)hasil;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error mendapatkan harga untuk judul tersebut" + ex.Message);
                }
                return stok;
            }
        }

        public Beli()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Checkout] (Nama_Pelanggan, Judul, Jumlah, Tanggal_Pembelian) values (@Nama, @Judul, @Jumlah, @Tanggal)";
            cmd.Parameters.AddWithValue("@Judul", textBox1.Text);
            cmd.Parameters.AddWithValue("@Nama", textBox2.Text);
            cmd.Parameters.AddWithValue("@Jumlah", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@Tanggal", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            conn.Close();

            int uang = (int)numericUpDown2.Value;
            int harga = GetHargaFromDatabase();
            int total = ((int)(harga * numericUpDown1.Value));
            int kembalian;
            int stok = GetStokFromDatabase();
            int sisa_stok = ((int)(stok - numericUpDown1.Value));

            if(uang >= total)
            {
                kembalian = uang - total;
                MessageBox.Show($"Terimakasih telah membeli {textBox1.Text}\n Kembalian anda adalah {kembalian} IDR", "Terimakasih!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                textBox1.Text = "";
                textBox2.Text = "";
                numericUpDown1.Value = 0;
                dateTimePicker1.Value = DateTimePicker.MinimumDateTime;
                this.Hide();

                conn.Open();
                string sql_updatestok = "Update Store set Stok = @stok where Judul = @Judul";
                cmd.CommandText = sql_updatestok;
                cmd.Parameters.AddWithValue("@stok", sisa_stok);
                cmd.ExecuteNonQuery();

            }
            else if(uang < total)
            {
                MessageBox.Show($"Uang anda {uang} IDR, tidak cukup", "Uang tidak cukup!!", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False"))
            {
                string query = "Select Stok from Store where Judul = '"+textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    object hasil = cmd.ExecuteScalar();
                    if(hasil != null && hasil != DBNull.Value)
                    {
                        numericUpDown1.Maximum = (int)hasil;
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error mendapatkan stok untuk judul tersebut" + ex.Message);
                }

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int harga = GetHargaFromDatabase();
            int jumlah;
            jumlah = ((int)(harga * numericUpDown1.Value));
            label7.Text = jumlah.ToString() + " IDR";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 0;
            dateTimePicker1.Value = DateTimePicker.MinimumDateTime;
        }
    }
}
