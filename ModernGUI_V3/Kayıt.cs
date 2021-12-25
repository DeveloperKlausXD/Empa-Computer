using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

namespace ModernGUI_V3
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }
       
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["VatanPc_Baglan"].ConnectionString);

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        byte[] resim = null;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            
            var input = textBox2.Text;
            string ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Şifre boş olmamalıdır");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Şifre En az bir küçük harf içermelidir";

            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Şifre En az bir büyük harf içermelidir";

            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Şifre 12 karakterden küçük veya büyük olmamalıdır";

            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Şifre En az bir sayısal değer içermelidir";

            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Şifre en az bir özel durum karakteri içermelidir";

            }
            else 
            {
                ErrorMessage = null;
            }
            if (ErrorMessage==null)
            {

            
            string gmail = textBox3.Text;
        string email = gmail;
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success)
        {
                bool TelefonDogruMu = TelefonFormatKontrol(textBox4.Text);
                if (TelefonDogruMu == true)
                {
                   
               

                if (bunifuPictureBox1!=null)
            {
                FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                resim = binaryReader.ReadBytes((int)fileStream.Length);
                binaryReader.Close();
                fileStream.Close();
            }

            if (bunifuCheckBox1.Checked == true)
            {
                if (
    textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
    textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty
)
                {
                    textBox1.BackColor = Color.Yellow;
                    textBox2.BackColor = Color.Yellow;
                    textBox3.BackColor = Color.Yellow;
                    MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası");
                }
                else
                {
                    string ekle = "INSERT INTO kullanicilar(adsoyad,gmail,sifre,telno,YetkiİD,profilresim) values (@adsoyad, @gmail, @sifre, @telno,@YetkiİD,@profilresim)";
                    SqlCommand komut = new SqlCommand();
                    komut = new SqlCommand(ekle, baglanti);
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.Parameters.AddWithValue("@adsoyad", textBox1.Text);
                    komut.Parameters.AddWithValue("@gmail", textBox3.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                    komut.Parameters.AddWithValue("@telno", textBox4.Text);
                    komut.Parameters.AddWithValue("@YetkiİD", 2);
                    komut.Parameters.Add("@profilresim", SqlDbType.Image, resim.Length).Value = resim;


                    komut.ExecuteNonQuery();

                    baglanti.Close();

                    MessageBox.Show("Başarılı bir şekilde kaydoldunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult secenek = MessageBox.Show("Lütfen 'Okudum Kabul Ediyorum.' Kısmını Okuyunuz.", "Önemli", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                if (secenek == DialogResult.Retry)
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }
                }
                else
                {
                    MessageBox.Show("Telefon numarası hatalıdır. Lütfen kontrol ediniz. \nGeçerli Format : 0555-555-55-55");
                }

            }
            else
                MessageBox.Show(email + " Email adresi hatalıdır. Lütfen kontrol ediniz.");
            }
            else
            {
                MessageBox.Show(ErrorMessage);
            }
            }
            catch (Exception)
            {
             
                throw;
            }
        }
    

        private void Kayıt_Load(object sender, EventArgs e)
        {
        
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int lx, ly;
        int sw, sh;

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox3.BackColor = SystemColors.Control;
            panel6.BackColor = SystemColors.Control;
            textBox4.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
            panel6.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
            textBox4.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
            panel7.BackColor = Color.White;
            textBox3.BackColor = SystemColors.Control;
            panel6.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            textBox3.BackColor = SystemColors.Control;
            panel6.BackColor = SystemColors.Control;
            textBox4.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }
        string imagepath = "0x.png";
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Profil Fotoğrafı Seç";
            openFileDialog1.Filter = "Resim dosyaları (*.png)|*.png|Gif dosyaları (*.gif)|*.gif|Tüm dosyalar (*.*)|*.*";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                bunifuPictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;
            }
        }
       
        private void ValidateEmail()
        {
            string gmail=textBox3.Text;
            string email = gmail;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                MessageBox.Show(email + " is Valid Email Address");
            else
                MessageBox.Show(email + " is Invalid Email Address"); 
        }
        public static bool TelefonFormatKontrol(string Telefon)
        {
            string RegexDesen = @"^(0(\d{10}))$";
            Match Eslesme = Regex.Match(Telefon, RegexDesen, RegexOptions.IgnoreCase);
            return Eslesme.Success; // bool değer döner
        }
        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Okudum Kabul Ediyorum.";
            Aciklama.ToolTipIcon = ToolTipIcon.Warning;
            Aciklama.IsBalloon = true;

            Aciklama.SetToolTip(button1, "Deneme");
          
            Aciklama.SetToolTip(bunifuLabel1, "Deneme Deneme");
        }

        private void bunifuLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Okudum Kabul Ediyorum.";
            Aciklama.ToolTipIcon = ToolTipIcon.Warning;
            Aciklama.IsBalloon = true;

            Aciklama.SetToolTip(button1, "Deneme");
           
            Aciklama.SetToolTip(bunifuLabel1, "Deneme Deneme");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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
