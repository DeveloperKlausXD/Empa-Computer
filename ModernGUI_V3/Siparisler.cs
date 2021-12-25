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
    public partial class Siparisler : Form
    {
        public Siparisler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        //Hangi Kullanıcınının siparişlerini görüntülencek; idd
        string idd;
        //
        int sil;
        //
        List<string> liste = new List<string>();
        List<string> liste2 = new List<string>();
        List<string> liste3 = new List<string>();
        //
        string gmail = Properties.Settings.Default["gmail"].ToString();
        string sifre = Properties.Settings.Default["sifre"].ToString();

        void goruntule()
        {

            baglanti.Open();
            //İD ALMA
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
            /////////////////////////////


            //Kategori İD URUN İD
            SqlDataReader goruntule;
            SqlCommand newkomut = new SqlCommand();

            newkomut.CommandText = "select  * from siparisler where İD='" + idd + "'";
            newkomut.Connection = baglanti;
            newkomut.CommandType = CommandType.Text;


            goruntule = newkomut.ExecuteReader();
            while (goruntule.Read())
            {
                liste.Add(goruntule["UrunID"].ToString());
               
            }
            goruntule.Close();

            //Ürünler
             foreach (string item in liste)
            {
                SqlDataReader goruntule2;
                SqlCommand newkomut2 = new SqlCommand();

                newkomut2.CommandText = "select  * from urunler where UrunID='" + item + "'";
                newkomut2.Connection = baglanti;
                newkomut2.CommandType = CommandType.Text;


                goruntule2 = newkomut2.ExecuteReader();
                while (goruntule2.Read())
                {

                    listBox2.Items.Add(goruntule2["UrunAD"].ToString());
                    listBox3.Items.Add(goruntule2["UrunFiyat"].ToString() + " TL");
                    liste3.Add(goruntule2["UrunKategoriID"].ToString());

                }
                goruntule2.Close();
            }
            

             //Fiyat
            foreach (string item2 in liste3)
            {
                SqlDataReader goruntule3;
                SqlCommand newkomut3 = new SqlCommand();

                newkomut3.CommandText = "select  * from UrunKategori where UrunKategoriID='" + item2 + "'";
                newkomut3.Connection = baglanti;
                newkomut3.CommandType = CommandType.Text;


                goruntule3 = newkomut3.ExecuteReader();
                while (goruntule3.Read())
                {

                    listBox1.Items.Add(goruntule3["UrunKategoriAD"].ToString());

                }
                goruntule3.Close();
            }
 

            baglanti.Close();
        }

        void siparisİptal()
        {
            if (listBox1.SelectedIndex > -1)
            {
                sil = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(sil);
                listBox2.Items.RemoveAt(sil);
                listBox3.Items.RemoveAt(sil);

                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from siparisler where UrunID=@UrunID", baglanti);
                komut.Parameters.AddWithValue("@UrunID", liste[sil]);
              
                komut.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Sipariş başarı ile iptal edilmiştir.");

            }
            else
            {
                MessageBox.Show(" Lütfen iptal etmek istediğiniz ürünün kategorisini seçiniz.", "İptal İşlemi");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            liste.Clear();
            liste2.Clear();
            liste3.Clear();
           
            goruntule();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            siparisİptal();
        }

        private void Siparisler_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            liste.Clear();
            liste2.Clear();
            liste3.Clear();

            goruntule();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>-1)
            {
                listBox2.SetSelected(listBox1.SelectedIndex, true);
                listBox3.SetSelected(listBox1.SelectedIndex, true);
            }
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            siparisİptal();
        }
    }
}
