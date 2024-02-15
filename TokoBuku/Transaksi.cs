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
    public partial class Transaksi : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False");
        public Transaksi()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.View = View.Details;

            listView1.Columns.Add("Nama Pelanggan", 100);
            listView1.Columns.Add("Judul", 100);
            listView1.Columns.Add("Jumlah", 50);
            listView1.Columns.Add("Tanggal Pembelian", 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "Select Nama_Pelanggan,Judul,Jumlah,Tanggal_Pembelian from Checkout";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0));
                lv.SubItems.Add(reader.GetString(1));
                lv.SubItems.Add(reader.GetInt32(2).ToString());
                lv.SubItems.Add(reader.GetDateTime(3).ToString());
                listView1.Items.Add(lv);
            }
            reader.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
