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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Admin_kullanicilar>();
            button2.BackColor = Color.FromArgb(12, 61, 92);
            button1.BackColor = Color.FromArgb(4, 41, 68);
            button3.BackColor = Color.FromArgb(4, 41, 68);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Admin_Siparis>();
            button3.BackColor = Color.FromArgb(12, 61, 92);
            button1.BackColor = Color.FromArgb(4, 41, 68);
            button2.BackColor = Color.FromArgb(4, 41, 68);

        }
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }

            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Admin_Siparis"] == null)
                button3.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Admin_kullanicilar"] == null)
                button2.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Admin_UrunEkle"] == null)
                button1.BackColor = Color.FromArgb(4, 41, 68);
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Admin_UrunEkle>();
            button1.BackColor = Color.FromArgb(12, 61, 92);
            button2.BackColor = Color.FromArgb(4, 41, 68);
            button3.BackColor = Color.FromArgb(4, 41, 68);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        string gmail = Properties.Settings.Default["profilgmail"].ToString();
        private void Admin_Load(object sender, EventArgs e)
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
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            profil profil = new profil();
            profil.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
