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
    public partial class profil : Form
    {
        public profil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string adminuye;

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        string gmail = Properties.Settings.Default["profilgmail"].ToString();
        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
           
            
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from kullanicilar where gmail='" + gmail + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                adminuye = dr2["YetkiİD"].ToString();


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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProfilDuzenle profilduzenle = new ProfilDuzenle();
            profilduzenle.Show();
            this.Hide();
        }

        private void flowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            profilsifre profilsifre = new profilsifre();
            profilsifre.Show();
            this.Hide();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

        }
    
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (adminuye=="2")
            {
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            
        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {

        }
    }
}
