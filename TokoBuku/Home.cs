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
    public partial class Home : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HBSV8M\SQLEXPRESS;Initial Catalog=Toko_Buku;Integrated Security=True;Encrypt=False");

        public Home()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "Select Isbn,Judul,Penulis,Stok,Harga from Store";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetInt32(0).ToString());
                lv.SubItems.Add(reader.GetString(1));
                lv.SubItems.Add(reader.GetString(2));
                lv.SubItems.Add(reader.GetInt32(3).ToString());
                lv.SubItems.Add(reader.GetInt32(4).ToString() + " IDR");
                listView1.Items.Add(lv);
            }
            reader.Close();
            conn.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.View = View.Details;

            listView1.Columns.Add("ISBN", 100);
            listView1.Columns.Add("Judul", 120);
            listView1.Columns.Add("Penulis", 100);
            listView1.Columns.Add("Stok", 50);
            listView1.Columns.Add("Harga", 110);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Beli beli = new Beli();
            beli.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hapus hapus = new Hapus();
            hapus.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Transaksi taksi = new Transaksi();
            taksi.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();

        }
    }
}
