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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        string adsoyad,gmail;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        SqlConnection cnn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        void adsoyadal()
        {
            cnn2.Open();
            gmail = Properties.Settings.Default["profilgmail"].ToString();
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "select * from kullanicilar where gmail='" + gmail + "'";
            komut.Connection = cnn2;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;

            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {

                adsoyad = dr2["adsoyad"].ToString();
            }
         
            cnn2.Close();
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
       

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox2.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Giris_Load(object sender, EventArgs e)
        {
           
            textBox1.Text = Properties.Settings.Default["gmail"].ToString();
            textBox2.Text = Properties.Settings.Default["sifre"].ToString();
            if (textBox1.Text.Count() > 0)
            {
                bunifuCheckBox1.Checked = true;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("select YetkiİD from kullanicilar where gmail = @gmail and sifre = @sifre", cnn);
                cmd.Parameters.AddWithValue("@gmail", textBox1.Text);
                cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rd.HasRows) // Girilen K.Adı ve K.Parola Dahilinde Gelen Data var ise 
                {
                    if (bunifuCheckBox1.Checked == true)
                    {
                        Properties.Settings.Default["gmail"] = textBox1.Text;
                        Properties.Settings.Default["sifre"] = textBox2.Text;
                    }
                    else
                    {
                        Properties.Settings.Default["gmail"] = "";
                        Properties.Settings.Default["sifre"] = "";
                    }
                    while (rd.Read()) // reader Okuyabiliyorsa
                    {

                        if (rd["YetkiİD"].ToString() == "1") // 1 Rolü Admin'e ait olarak Ayarlanmışdır
                        {
                            // Kullanıcı Rolü 1 ise Admin Ekranı Aç
                            
                            Properties.Settings.Default["profilgmail"] = textBox1.Text;
                            Properties.Settings.Default["profilsifre"] = textBox2.Text;
                            Properties.Settings.Default.Save();
                            adsoyadal();
                            Properties.Settings.Default["adsoyad"] = adsoyad;
                            Properties.Settings.Default.Save();
                            Admin admin = new Admin();
                            admin.Show();
                            this.Hide();
                            cnn.Close();
                        }
                        else
                        {
                            // Kullanıcı Rolü 1 dışında ise Kullanıcı Ekranı Aç
                    
                            Properties.Settings.Default["profilgmail"] = textBox1.Text;
                            Properties.Settings.Default["profilsifre"] = textBox2.Text;
                            Properties.Settings.Default.Save();
                            adsoyadal();
                            Properties.Settings.Default["adsoyad"] = adsoyad;
                            Properties.Settings.Default.Save();
                            Anasayfa kul = new Anasayfa();
                            kul.Show();
                            this.Hide();
                            cnn.Close();
                        }
                    }
                }
                else /// Reader SATIR döndüremiyorsa K.Adı Parola Yanlış Demekdir
                {
                    rd.Close();
                  
                    MessageBox.Show("Gmail Adı veya Parola Geçersizdir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch // Bağlantı açamayıp Sorgu Çalıştıramıyorsa Veritabanına Ulaşamıyor Demekdir
            {
               
            }












        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kayıt kayıt = new Kayıt();
            kayıt.Show();
            this.Hide();
        }
        int lx, ly;
        int sw, sh;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
    }
}
