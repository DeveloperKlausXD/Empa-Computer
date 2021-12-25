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
    public partial class Admin_Siparis : Form
    {
        public Admin_Siparis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        void listele()
        {
            baglanti.Open();
            string com = "  select s.SiparisID as 'Sipariş Numarası' ,k.adsoyad as 'Alıcı Ad-Soyad',ur.UrunAD as 'Ürün Adı'from siparisler as s left join kullanicilar as k on k.İD=s.İD left join urunler as ur on ur.UrunID=s.UrunID";
            SqlDataAdapter da = new SqlDataAdapter(com, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

            bunifuDataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void Admin_Siparis_Load(object sender, EventArgs e)
        {
            bunifuDataGridView1.AllowUserToAddRows = false;
            bunifuDataGridView1.AllowUserToDeleteRows = false;
            bunifuDataGridView1.ReadOnly = true;
            listele();
            timer1.Interval = 5000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listele();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {






            string Aratxt = bunifuTextBox1.Text.Trim().ToUpper();



            int j = -1;

       


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

                                cell.Style.BackColor = Color.Yellow;

                                j = 0;

                                break;

                            }



                        }

                    }

                }

            }

            if (j == -1)

            {

                MessageBox.Show("Kayıt bulunamadı!");

            }
            else if (j == 0)
            {
                DialogResult secenek = MessageBox.Show("[" + bunifuTextBox1.Text + "] İDli Üyenin siparişini tamamlamak istediğine emin misiniz?", "Sipariş Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (secenek == DialogResult.OK)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand("delete from siparisler where SiparisID='" + bunifuTextBox1.Text + "'");
                    kmt.Connection = baglanti;
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                }

            }

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
