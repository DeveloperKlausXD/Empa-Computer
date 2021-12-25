using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public partial class ProfilDuzenle : Form
    {
        public ProfilDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProfilDuzenle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            bunifuTextBox1.Text = Properties.Settings.Default["adsoyad"].ToString();
            bunifuTextBox2.Text = Properties.Settings.Default["profilgmail"].ToString();
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from kullanicilar where gmail='" + bunifuTextBox1.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                bunifuTextBox3.Text = dr2["telno"].ToString();
                if (dr2["profilresim"]!=null)
                {
                    byte[] resim = new byte[0];
                    resim = (byte[])dr2["profilresim"];
                    MemoryStream memoryStream = new MemoryStream(resim);
                    bunifuPictureBox1.Image = Image.FromStream(memoryStream);

                }
            }
            dr2.Close();
            komut.Dispose();
            baglanti.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
       
       
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kullanıcı Adınızı " + bunifuTextBox1.Text + " olarak değiştirmek istediğinize emin misiniz? ", "Profil Düzenleme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (secenek == DialogResult.OK)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Update kullanicilar Set adsoyad=@adsoyad Where gmail='" + bunifuTextBox2.Text + "'");
                kmt.Connection = baglanti;
                kmt.Parameters.AddWithValue("@adsoyad", bunifuTextBox1.Text);
                Properties.Settings.Default["adsoyad"] = bunifuTextBox1.Text;
                Properties.Settings.Default.Save();
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ad Soyad Değiştirildi. ", "Düzenleme Onay", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Gmail Adresinizi " + bunifuTextBox2.Text + " olarak değiştirmek istediğinize emin misiniz? ", "Profil Düzenleme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (secenek == DialogResult.OK)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Update kullanicilar Set gmail=@gmail Where adsoyad='" + bunifuTextBox1.Text + "'");
                kmt.Connection = baglanti;
                kmt.Parameters.AddWithValue("@gmail", bunifuTextBox2.Text);
                Properties.Settings.Default["profilgmail"] = bunifuTextBox2.Text;
                Properties.Settings.Default.Save();
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Gmail Değiştirildi. ", "Düzenleme Onay", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Telefon Numarınızı " + bunifuTextBox3.Text + " olarak değiştirmek istediğinize emin misiniz? ", "Profil Düzenleme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (secenek == DialogResult.OK)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Update kullanicilar Set telno=@telno Where adsoyad='" + bunifuTextBox1.Text + "'");
                kmt.Connection = baglanti;
                kmt.Parameters.AddWithValue("@telno", bunifuTextBox3.Text);
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Telefon Numarası Değiştirildi. ", "Düzenleme Onay", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            profil profil = new profil();
            profil.Show();
            this.Hide();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
