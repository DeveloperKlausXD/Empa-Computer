using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public partial class Admin_UrunEkle : Form
    {
        public Admin_UrunEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        void listele()
        {

            string com = "select * from urunler";
            SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

            bunifuDataGridView1.DataSource = dt;

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        bool SayiMi(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex>-1 && bunifuTextBox1.Text.Length>0 && bunifuTextBox2.Text.Length>0)
            {
                
                    if (SayiMi(bunifuTextBox2.Text) == true)
                    {

                    string ekle = "INSERT INTO urunler(UrunAD,UrunKategoriID,UrunFiyat) values (@UrunAD,@UrunKategoriID,@UrunFiyat)";
                    SqlCommand komut = new SqlCommand();
                    komut = new SqlCommand(ekle, baglanti);

                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@UrunAD", bunifuTextBox1.Text);
                    komut.Parameters.AddWithValue("@UrunFiyat", bunifuTextBox2.Text);
                    komut.Parameters.AddWithValue("@UrunKategoriID", comboBox1.SelectedIndex + 1);

                    MessageBox.Show("Ürün AD - " + bunifuTextBox1.Text + "\nÜrün Fiyat - " + bunifuTextBox2.Text + "\nÜrün Kategori - " + comboBox1.Text + "\nOlarak Ürün Raflara Koyuldu.");
                    komut.ExecuteNonQuery();
                }
                    else
                    {
                    MessageBox.Show("Geçerli Bir Para Miktarı Giriniz.");
                }
               
            }
            else
            {
                MessageBox.Show("Boş Kısımları Doldurunuz.");
            }
            
        }

        private void Admin_UrunEkle_Load(object sender, EventArgs e)
        {
            bunifuDataGridView1.AllowUserToAddRows = false;
            bunifuDataGridView1.AllowUserToDeleteRows = false;
            bunifuDataGridView1.ReadOnly = true;
            baglanti.Open();
            listele();
            timer1.Interval = 5000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listele();
        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
