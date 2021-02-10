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

namespace SqlTabanlıKullanıcıAdiVeŞifreProjesi
{
    public partial class Guncelle : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=sizin bilginiz;Initial Catalog=Guvenlik;Integrated Security=True");
        int id=0;
        public Guncelle()
        {
            InitializeComponent();
        }
        public void veriler()
        {
            listView1.Items.Clear();
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From Parola", connection);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ID"].ToString();
                ekle.SubItems.Add(oku["Isim"].ToString());
                ekle.SubItems.Add(oku["Sifre"].ToString());
                listView1.Items.Add(ekle);
            }
            connection.Close();


        }
        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("update Parola set Isim='" + textBox1.Text.ToString() + "',Sifre='" + textBox2.Text.ToString() + "'where ID=" + id + "", connection);
            komut.ExecuteNonQuery();
            connection.Close();
            veriler();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void Guncelle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            veriler();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
