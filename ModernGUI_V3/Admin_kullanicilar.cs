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
    public partial class Admin_kullanicilar : Form
    {
        int j = -1;
        void Ara()
        {
            string Aratxt = bunifuTextBox1.Text.Trim().ToUpper();



            j = -1;




            for (int i = 0; i <= bunifuDataGridView1.Rows.Count - 1; i++)

            {

                foreach (DataGridViewRow row in bunifuDataGridView1.Rows)

                {

                    foreach (DataGridViewCell cell in bunifuDataGridView1.Rows[i].Cells)

                    {

                        if (cell.Value != null)

                        {

                            if (cell.Value.ToString().ToUpper() == Aratxt)

                            {

                              

                                j = 0;

                                break;

                            }



                        }

                    }

                }

            }

          
        }
        public Admin_kullanicilar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        void listele()
        {
            baglanti.Open();
            string com = "select * from kullanicilar";
            SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

            bunifuDataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Ara();
            if (j==0)
            {

                
                    DialogResult secenek = MessageBox.Show("[" + bunifuTextBox1.Text + "] İDli Üyeyi silmek istediğinize emin misiniz?", "Silme Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                 if (secenek == DialogResult.OK)
                 {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("delete from kullanicilar where İD='" + bunifuTextBox1.Text + "'");
                kmt.Connection = baglanti;
                kmt.ExecuteNonQuery();
                baglanti.Close();
                 }
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı!");
            }
        }

        private void Admin_kullanicilar_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Start();
            bunifuDataGridView1.AllowUserToAddRows = false;
            bunifuDataGridView1.AllowUserToDeleteRows = false;
            bunifuDataGridView1.ReadOnly = true;
            listele();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Ara();
            if (j == 0)
            {

                DialogResult secenek = MessageBox.Show("[" + bunifuTextBox1.Text + "] İDli Üyenin Gmailini " + bunifuTextBox3.Text + " olarak değiştirmek istediğinize emin misiniz?", "Değiştirme Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (secenek == DialogResult.OK)
                {

                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand("Update kullanicilar Set gmail=@gmail Where İD='" + bunifuTextBox1.Text + "'");
                    kmt.Connection = baglanti;
                    kmt.Parameters.AddWithValue("@gmail", bunifuTextBox3.Text);
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı!");
            }
            }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Ara();
            if (j == 0)
            {
                DialogResult secenek = MessageBox.Show("[" + bunifuTextBox1.Text + "] İDli Üyenin Şifresini " + bunifuTextBox5.Text + " olarak değiştirmek istediğinize emin misiniz?", "Değiştirme Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (secenek == DialogResult.OK)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand("Update kullanicilar Set sifre=@sifre Where İD='" + bunifuTextBox1.Text + "'");
                    kmt.Connection = baglanti;
                    kmt.Parameters.AddWithValue("@sifre", bunifuTextBox5.Text);
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı!");
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Ara();
            if (j == 0)
            {
                DialogResult secenek = MessageBox.Show("[" + bunifuTextBox1.Text + "] İDli Üyenin Kullanıcı Adını " + bunifuTextBox2.Text + " olarak değiştirmek istediğinize emin misiniz?", "Değiştirme Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (secenek == DialogResult.OK)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Update kullanicilar Set adsoyad=@adsoyad Where İD='" + bunifuTextBox1.Text + "'");
                kmt.Connection = baglanti;
                kmt.Parameters.AddWithValue("@adsoyad", bunifuTextBox2.Text);
                kmt.ExecuteNonQuery();
                baglanti.Close();
            }
            }
            else if ((j == -1))
            {
              
                MessageBox.Show("Kayıt bulunamadı!");
            }
        
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Ara();
            if (j == 0)
            {
                DialogResult secenek = MessageBox.Show("[" + bunifuTextBox1.Text + "] İDli Üyenin telefon numarasını " + bunifuTextBox4.Text + " olarak değiştirmek istediğinize emin misiniz?", "Değiştirme Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (secenek == DialogResult.OK)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Update kullanicilar Set telno=@telno Where İD='" + bunifuTextBox1.Text + "'");
                kmt.Connection = baglanti;
                kmt.Parameters.AddWithValue("@telno", bunifuTextBox5.Text);
                kmt.ExecuteNonQuery();
                baglanti.Close();
            }
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listele();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
