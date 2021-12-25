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
    public partial class profilsifre : Form
    {
        public profilsifre()
        {
            InitializeComponent();
        }
        string gmail,sifre;
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        string gmail2 = Properties.Settings.Default["profilgmail"].ToString();
        void sifreal()
        {
            baglanti.Open();
           gmail = Properties.Settings.Default["profilgmail"].ToString();
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from kullanicilar where gmail='" + gmail + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                
                sifre = dr2["sifre"].ToString();
            }
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            profil profil = new profil();
            profil.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == sifre)
            {
                if (bunifuTextBox3.Text == bunifuTextBox4.Text)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand("Update kullanicilar Set sifre=@sifre Where gmail='" + gmail + "'");
                    kmt.Connection = baglanti;
                    kmt.Parameters.AddWithValue("@sifre", bunifuTextBox4.Text);

                    kmt.ExecuteNonQuery();
                    baglanti.Close();

                    bunifuTextBox1.Text = bunifuTextBox3.Text;
                    Properties.Settings.Default["profilsifre"] = bunifuTextBox3.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Başarılı bir şekilde şifre değiştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuTextBox2.Text = " ";
                    bunifuTextBox3.Text = " ";
                    bunifuTextBox4.Text = " ";
                }
                else
                {
                    MessageBox.Show("Yeni Şifreler Bir Biri İle Uyuşmuyor.");
                }

            }
            else
            {
                MessageBox.Show("Yanlış Giriş 'Eski Şifre'");
            }
        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
          
        }

        private void profilsifre_Load(object sender, EventArgs e)
        {

            baglanti.Open();

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from kullanicilar where gmail='" + gmail2 + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {

                if (dr2["profilresim"] != null)
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
            sifreal();
            bunifuTextBox1.Text = sifre;
           
        }
    }
}
