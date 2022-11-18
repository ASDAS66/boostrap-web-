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

namespace beyza_16008118047
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=oyun1;Trusted_Connection=True;");

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.Text = "Giriş Yap";
            //form1'in arka planını değiştirir ve form ismini giriş yap olarak değiştirir.
           
            label1.Text = "Kullanici Adı :";
            label1.Font = new Font("Georgia", 7, FontStyle.Bold);
            label1.ForeColor = Color.White;
            //labelin fontunu ve textini değiştirir yazı rengini beyaz yapar.

            label2.Text = "Şifre :";
            label2.Font = new Font("Georgia", 7, FontStyle.Bold);
            label2.ForeColor = Color.White;
            //labelin fontunu ve textini değiştirir yazı rengini beyaz yapar.
            
            button1.Text = "Giriş Yap";
            button2.Text = "Kayıt Sil/Ol";
            button2.ForeColor = Color.Red;
            //butonların textini ve rengini değiştirir.

            //this.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            maskedTextBox1.PasswordChar = '*';
            //maskedTextBox a girilen şifredeki her bir karakter yerine * yazar;
            textBox1.Multiline = true;
            //textboxun tek satır yerine çoklu satır özelliği.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
            //login fonksiyonunu çağırır.
            button1.Enabled = true;
            //button tıklamdığı zaman pasif olur.

            if(textBox1.Text==null&& maskedTextBox1.Text == null)
            {      
                    errorProvider1.SetError(maskedTextBox1, "bu alan boş geçilemez");
                    //textboxlar boş geçilirse uyarı verir.
            }
        }
        public void login()
        {
            Conn.Open();
            string kayit = "SELECT*from oyuncular where(kAdı=@ka and sifre=@sf)";
            //şifre ve kullanici adi doğru olduğunda veri tabanından veri çeker
            SqlCommand komut = new SqlCommand(kayit, Conn);
            komut.Parameters.AddWithValue("@ka", textBox1.Text);
            komut.Parameters.AddWithValue("@sf", maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Form2 frm = new Form2();
                frm.ShowDialog();
                //kullanici ve sifre doğruysa form2'ye geçer(giriş yapılır)
            }
            else 
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol edin.", "HEY!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //kullanıcı adı ve şifre boş bırakılırsa uyarı verir.
            }

                Conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
            //button2 ye tıklandığında form3 e geçer.
        }
   
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            //resme tıklandığında form kapanır.
        }
    }
}
