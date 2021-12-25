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
    public partial class Siparis : Form
    {
        public Siparis()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        //Fiyat Hesaplaması
        void toplamfiyatlabel()
        {
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
        }

        int islemcif = 0, anakartf = 0, ramf = 0, ekrankartif = 0, sabitdiskf = 0, monitorf = 0, kasaf = 0;
        int toplam;
        //Fiyat Hesaplaması

        //Satın Alınan Ürünün İD'sini Almak İçin Değişken
        int islemciurunid = 0, anakarturunid = 0, ramurunid = 0, ekrankartiurunid = 0, sabitdiskurunid = 0, monitorurunid = 0, kasaurunid = 0;
        //Satın Alınan Ürünün İD'sini Almak İçin Değişken

        //Profil İD
        string idd;

        void stokDoldur()
        {
            //İşlemci
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.CommandText = "select * from urunler where UrunKategoriID=1";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr3;
            dr3 = komut.ExecuteReader();
            while (dr3.Read())
            {
                islemci.Items.Add(dr3["UrunAD"].ToString()); 
            }
            dr3.Close();
            

            //anakart
            komut.CommandText = "select * from urunler where UrunKategoriID=2";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr4;
            dr4 = komut.ExecuteReader();
            while (dr4.Read())
            {
                anakart.Items.Add(dr4["UrunAD"].ToString());
            }
            dr4.Close();

            //Ram
            komut.CommandText = "select * from urunler where UrunKategoriID=3";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr5;
            dr5 = komut.ExecuteReader();
            while (dr5.Read())
            {
                ram.Items.Add(dr5["UrunAD"].ToString());
            }
            dr5.Close();

            //Ekran Kartı
            komut.CommandText = "select * from urunler where UrunKategoriID=4";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr6;
            dr6 = komut.ExecuteReader();
            while (dr6.Read())
            {
                ekrankarti.Items.Add(dr6["UrunAD"].ToString());
            }
            dr6.Close();

            //Sabit Dİsk
            komut.CommandText = "select * from urunler where UrunKategoriID=5";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr7;
            dr7 = komut.ExecuteReader();
            while (dr7.Read())
            {
                sabitdisk.Items.Add(dr7["UrunAD"].ToString());
            }
            dr7.Close();

            //Monitör
            komut.CommandText = "select * from urunler where UrunKategoriID=6";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr8;
            dr8 = komut.ExecuteReader();
            while (dr8.Read())
            {
                monitor.Items.Add(dr8["UrunAD"].ToString());
            }
            dr8.Close();

            //Kasa
            komut.CommandText = "select * from urunler where UrunKategoriID=7";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr9;
            dr9 = komut.ExecuteReader();
            while (dr9.Read())
            {
                kasa.Items.Add(dr9["UrunAD"].ToString());
            }
            dr9.Close();
            baglanti.Close();

        }

        //Label'a Fiyat Yazan Metodlar
        void islemciFiyat()
        {
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.CommandText = "select * from urunler where UrunAD='" + islemci.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader islemci2;
            islemci2 = komut.ExecuteReader();
            while (islemci2.Read())
            {
                label19.Text = islemci2["UrunFiyat"].ToString();
                islemciurunid = Convert.ToInt32(islemci2["UrunID"].ToString());
                islemcif = Convert.ToInt32(islemci2["UrunFiyat"].ToString());
                label19.Text += " TL";
            }
            islemci2.Close();
            baglanti.Close();
           
        }

        void anakartFiyat()
        {
            SqlCommand komut = new SqlCommand();
            baglanti.Open(); 
            komut.CommandText = "select * from urunler where UrunAD='" + anakart.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader anakart2;
            anakart2 = komut.ExecuteReader();
            while (anakart2.Read())
            {
                label20.Text = anakart2["UrunFiyat"].ToString();
                anakarturunid = Convert.ToInt32(anakart2["UrunID"].ToString());
                anakartf = Convert.ToInt32(anakart2["UrunFiyat"].ToString());
                label20.Text += " TL";
            }
            anakart2.Close();
            baglanti.Close();
        }
        void ramFiyat()
        {
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.CommandText = "select * from urunler where UrunAD='" + ram.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader Ram2;
            Ram2 = komut.ExecuteReader();
            while (Ram2.Read())
            {
                label21.Text = Ram2["UrunFiyat"].ToString();
                ramurunid = Convert.ToInt32(Ram2["UrunID"].ToString());
                ramf = Convert.ToInt32(Ram2["UrunFiyat"].ToString());
                label21.Text += " TL";
            }
            Ram2.Close();
            baglanti.Close();
        }
        void ekrankartiFiyat()
        {
            SqlCommand komut = new SqlCommand();
            baglanti.Open(); 
            komut.CommandText = "select * from urunler where UrunAD='" + ekrankarti.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader Ekrankart;
            Ekrankart = komut.ExecuteReader();
            while (Ekrankart.Read())
            {
                label22.Text = Ekrankart["UrunFiyat"].ToString();
                ekrankartiurunid = Convert.ToInt32(Ekrankart["UrunID"].ToString());
                ekrankartif = Convert.ToInt32(Ekrankart["UrunFiyat"].ToString());
                label22.Text += " TL";
            }
            Ekrankart.Close();
            baglanti.Close();
        }

        void sabitDiskFiyat()
        {
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.CommandText = "select * from urunler where UrunAD='" + sabitdisk.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader sabitdisk2;
            sabitdisk2 = komut.ExecuteReader();
            while (sabitdisk2.Read())
            {
                label23.Text = sabitdisk2["UrunFiyat"].ToString();
                sabitdiskurunid = Convert.ToInt32(sabitdisk2["UrunID"].ToString());
                sabitdiskf = Convert.ToInt32(sabitdisk2["UrunFiyat"].ToString());
                label23.Text += " TL";

            }
            sabitdisk2.Close();
            baglanti.Close();
        }

        void monitorFiyat()
        {
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.CommandText = "select * from urunler where UrunAD='" + monitor.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader monitor2;
            monitor2 = komut.ExecuteReader();
            while (monitor2.Read())
            {
                label24.Text = monitor2["UrunFiyat"].ToString();
                monitorurunid = Convert.ToInt32(monitor2["UrunID"].ToString());
                monitorf = Convert.ToInt32(monitor2["UrunFiyat"].ToString());
                label24.Text += " TL";
            }
            monitor2.Close();
            baglanti.Close();
        }

        void kasaFiyat()
        {
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.CommandText = "select * from urunler where UrunAD='" + kasa.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader kasa2;
            kasa2 = komut.ExecuteReader();
            while (kasa2.Read())
            {
                label25.Text = kasa2["UrunFiyat"].ToString();
                kasaurunid = Convert.ToInt32(kasa2["UrunID"].ToString());
                kasaf = Convert.ToInt32(kasa2["UrunFiyat"].ToString());
                label25.Text += " TL";
            }
            kasa2.Close();
            baglanti.Close();
        }


        //Label'a Fiyat Yazan Metodlar
        string gmail = Properties.Settings.Default["profilgmail"].ToString();
        string sifre = Properties.Settings.Default["sifre"].ToString();
        //Satın Al

        //Uygulamaya Girdiğinden beri Kaç Kere Satın Aldığı
        int siparis=0;
        void satınAl()
        {
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            DialogResult secenek = MessageBox.Show("Siparişi tamamlamak istediğinize emin misiniz ? \nToplam - " + toplam + " TL", "Sipariş Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (secenek == DialogResult.OK)
            {

                
                baglanti.Open();

                //Siparişler Hangi İD(Kullanıcı)ye Gidicek; "İDD"
                SqlCommand İD = new SqlCommand();

                İD.CommandText = "select İD from kullanicilar where gmail='" + gmail + "'";
                İD.Connection = baglanti;
                İD.CommandType = CommandType.Text;
                SqlDataReader İD2;

                İD2 = İD.ExecuteReader();
                while (İD2.Read())
                {
                    idd = İD2["İD"].ToString();
                }
                İD2.Close();
                //////////////////////////////////////////
                
                //islemci 
                string ekle = "INSERT INTO siparisler(İD,UrunID) values (@İD, @UrunID)";
                SqlCommand komut = new SqlCommand();
                if (islemci.SelectedIndex > -1)
                {
                    komut = new SqlCommand(ekle, baglanti);

                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@İD", idd);
                   
                    komut.Parameters.AddWithValue("@UrunID", islemciurunid);
                    
                    komut.ExecuteNonQuery();
                }
                //anakart
                if (anakart.SelectedIndex > -1)
                {


                    komut = new SqlCommand(ekle, baglanti);
                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@İD", idd);
                  
                    komut.Parameters.AddWithValue("@UrunID", anakarturunid);
                   
                    komut.ExecuteNonQuery();
                }
                //ram
                if (ram.SelectedIndex > -1)
                {


                    komut = new SqlCommand(ekle, baglanti);
                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@İD", idd);
                  
                    komut.Parameters.AddWithValue("@UrunID", ramurunid);
               
                    komut.ExecuteNonQuery();
                }
                //ekrankarti
                if (ekrankarti.SelectedIndex > -1)
                {


                    komut = new SqlCommand(ekle, baglanti);
                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@İD", idd);
              
                    komut.Parameters.AddWithValue("@UrunID", ekrankartiurunid);
                   
                    komut.ExecuteNonQuery();
                }
                //sabitdisk
                if (sabitdisk.SelectedIndex > -1)
                {


                    komut = new SqlCommand(ekle, baglanti);
                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@İD", idd);
        
                    komut.Parameters.AddWithValue("@UrunID", sabitdiskurunid);
          
                    komut.ExecuteNonQuery();
                }
                //monitor
                if (monitor.SelectedIndex > -1)
                {


                    komut = new SqlCommand(ekle, baglanti);
                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@İD", idd);
              
                    komut.Parameters.AddWithValue("@UrunID", monitorurunid);
        
                    komut.ExecuteNonQuery();
                }
                //kasa
                if (kasa.SelectedIndex > -1)
                {


                    komut = new SqlCommand(ekle, baglanti);
                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@İD", idd);
       ;
                    komut.Parameters.AddWithValue("@UrunID", kasaurunid);
                 
                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Sipariş Onaylandı, iyi günler dileriz.", "Onaylandı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                siparis++;

                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Siparişe Devam edebilirsiniz.", "Sipariş Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            stokDoldur();

        }

        private void ram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ram.SelectedIndex >= 0)
            {
                ramFiyat();
            toplamfiyatlabel();
            }
            else
            {

            }
        }

        private void ekrankarti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ekrankarti.SelectedIndex >= 0)
            {
                ekrankartiFiyat();
            toplamfiyatlabel();
                }
                else
                {

                }
            }

        private void sabitdisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sabitdisk.SelectedIndex >= 0)
            {
                sabitDiskFiyat();
            toplamfiyatlabel();
                    }
                    else
                    {

                    }
                }

        private void monitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (monitor.SelectedIndex >= 0)
            {
                monitorFiyat();
            toplamfiyatlabel();
                        }
                        else
                        {

                        }
                    }

        private void kasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kasa.SelectedIndex >= 0)
            {
                kasaFiyat();
            toplamfiyatlabel();
                            }
                            else
                            {

                            }
                        }

        private void islemci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (islemci.SelectedIndex>=0)
            {
                islemciFiyat();
                toplamfiyatlabel();
            }
            else
            {

            }
            

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (siparis==0)
            {
                satınAl();
                toplamfiyatlabel();
                
            }
            else
            {
                DialogResult secenek = MessageBox.Show("Uygulamaya girdiğinizden beri zaten " + siparis + " adet sipariş verdiniz. \nsiparişi onaylamak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secenek == DialogResult.Yes)
                {
                    satınAl();
                    toplamfiyatlabel();
                }
                else
                {
                    MessageBox.Show("Daha Sonra Tekrar Bekleriz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show(islemci.Text + " Seçimini kaldırmak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                label19.Text = "0";
            islemciurunid = Convert.ToInt32(null);
            islemcif = 0;
            label19.Text += " TL";
            islemci.SelectedItem = null;
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
            }
            {
                MessageBox.Show("Sipariş vermeye devam edebilirsiniz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }



        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show(anakart.Text + " Seçimini kaldırmak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                label20.Text = "0";
            anakarturunid = Convert.ToInt32(null);
            anakartf = 0;
            label20.Text += " TL";
            anakart.SelectedItem = null;
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
            }
            {
                MessageBox.Show("Sipariş vermeye devam edebilirsiniz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                DialogResult secenek = MessageBox.Show(ram.Text + " Seçimini kaldırmak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secenek == DialogResult.Yes)
                {
                    label21.Text = "0";
            ramurunid = Convert.ToInt32(null);
            ramf = 0;
            label21.Text += " TL";
            ram.SelectedItem = null;
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
            }
            {
                MessageBox.Show("Sipariş vermeye devam edebilirsiniz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
                    DialogResult secenek = MessageBox.Show(ekrankarti.Text + " Seçimini kaldırmak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (secenek == DialogResult.Yes)
                    {
                        label22.Text = "0";
            ekrankartiurunid = Convert.ToInt32(null);
            ekrankartif = 0;
            label22.Text += " TL";
            ekrankarti.SelectedItem = null;
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
            }
            {
                MessageBox.Show("Sipariş vermeye devam edebilirsiniz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
                        DialogResult secenek = MessageBox.Show(sabitdisk.Text + " Seçimini kaldırmak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (secenek == DialogResult.Yes)
                        {
                            label23.Text = "0";
            sabitdiskurunid = Convert.ToInt32(null);
            sabitdiskf = 0;
            label23.Text += " TL";
            sabitdisk.SelectedItem = null;
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
            }
            {
                MessageBox.Show("Sipariş vermeye devam edebilirsiniz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
                            DialogResult secenek = MessageBox.Show(monitor.Text + " Seçimini kaldırmak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (secenek == DialogResult.Yes)
                            {
                                label24.Text = "0";
            monitorurunid = Convert.ToInt32(null);
            monitorf = 0;
            label24.Text += " TL";
            monitor.SelectedItem = null;
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
            }
            {
                MessageBox.Show("Sipariş vermeye devam edebilirsiniz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
                                DialogResult secenek = MessageBox.Show(kasa.Text + " Seçimini kaldırmak istediğinize emin misiniz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (secenek == DialogResult.Yes)
                                {
                                    label19.Text = "0";
            kasaurunid = Convert.ToInt32(null);
            kasaf = 0;
            label19.Text += " TL";
            kasa.SelectedItem = null;
            toplam = islemcif + anakartf + ramf + ekrankartif + sabitdiskf + monitorf + kasaf;
            label10.Text = toplam + " TL";
            }
            {
                MessageBox.Show("Sipariş vermeye devam edebilirsiniz ...", "Sipariş İptal", MessageBoxButtons.OK, MessageBoxIcon.Question);
            } 
        }

        private void anakart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (anakart.SelectedIndex >= 0)
            {
                anakartFiyat();
                toplamfiyatlabel();
            }
            else
            {
                    
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        

       
    }
}
