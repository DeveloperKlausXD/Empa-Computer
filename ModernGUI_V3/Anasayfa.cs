using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);
        string gmail = Properties.Settings.Default["profilgmail"].ToString();
        private void FormPrincipal_Load(object sender, EventArgs e)
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
        #region Funcionalidades del formulario
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
           
            this.Size = new Size(sw,sh);
            this.Location = new Point(lx,ly);
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Siparis>(); 
            button1.BackColor = Color.FromArgb(12, 61, 92);
            button3.BackColor = Color.FromArgb(4, 41, 68);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            profil form2 = new profil();
            form2.Show();
            this.Hide();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Siparisler>();
            button3.BackColor = Color.FromArgb(12, 61, 92);
            button1.BackColor = Color.FromArgb(4, 41, 68);
        }

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            bunifuPictureBox1.BackColor = Color.FromArgb(13, 93, 142);
        }

        private void bunifuPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            bunifuPictureBox1.BackColor = Color.FromArgb(4, 41, 68);
            
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            profil form2 = new profil();
            form2.Show();
            this.Hide();
            
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new() {
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
                formulario.FormClosed += new FormClosedEventHandler(CloseForms );
            }
          
            else {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender,FormClosedEventArgs e) {
            if (Application.OpenForms["Form1"] == null)
                button1.BackColor = Color.FromArgb(4, 41, 68);
            
            if (Application.OpenForms["Form3"] == null)
                button3.BackColor = Color.FromArgb(4, 41, 68);
        }
    }
}
