using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beyza_16008118047
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.SteelBlue;
            this.Text = "**Sayıyı Bul**";
            //form1 arka plan rengini düzenler
           
            label1.Font = new Font("Georgia", 12, FontStyle.Italic);
            label1.Text = "0";
            //label'in fontunu ve textini düzenler.
            
            label2.Font = new Font("Georgia", 12, FontStyle.Italic);
            label2.Text = "0";
            //label'in fontunu ve textini düzenler.

            label3.Font = new Font("Georgia", 12, FontStyle.Italic);
            label3.Text = "+";
            //label'in fontunu ve textini düzenler.

            label4.Font = new Font("Georgia", 12, FontStyle.Italic);
            label4.Text = "=";
            //label'in fontunu ve textini düzenler.

            label5.Font = new Font("Georgia", 12, FontStyle.Italic);
            label5.Text = "0";
            label5.Visible = false;
            //label'in fontunu ve textini düzenler ve visible nı kapatarak labeli görünmez yapar.

            label6.Font = new Font("Georgia", 12, FontStyle.Italic);
            label6.Text = "puan :";
            label6.ForeColor = Color.Purple;
            //label'in fontunu ve textini düzenler ve textin rengini değiştirir.

            label7.Font = new Font("Georgia", 12, FontStyle.Italic);
            label7.Text = "0";
            label7.ForeColor = Color.Purple;
            //label'in fontunu ve textini düzenler ve textin rengini değiştirir.

            label8.Font = new Font("Georgia", 12, FontStyle.Italic);
            label8.Text = "kalan süre :";
            label8.ForeColor = Color.Purple;
            //label'in fontunu ve textini düzenler ve textin rengini değiştirir.

            label9.Font = new Font("Georgia", 12, FontStyle.Italic);
            label9.Text = "100";
            label9.ForeColor = Color.Purple;
            //label'in fontunu ve textini düzenler ve textin rengini değiştirir.

            label10.Font = new Font("Georgia", 8, FontStyle.Italic);
            label10.Text = "zorluk derecesi :";
            //label'in fontunu ve textini düzenler.

            label11.Font = new Font("Georgia", 8, FontStyle.Italic);
            label11.Text = "seçilen";
            //label'in fontunu ayarlar ve textini değiştirir.

            label12.Font = new Font("Georgia", 8, FontStyle.Italic);
            label12.Visible = false;
            //label'in fontunu değiştirir ve labeli gizler.

            label13.Text = "kişiselleştr";
            label13.Font = new Font("Georgia", 8, FontStyle.Italic);
            //label'in fontunu ayarlar ve textini değiştirir.

            maskedTextBox1.Font = new Font("Georgia", 12, FontStyle.Italic);
             maskedTextBox1.Mask = "######";
            //maskedtextboxun fontunu düzenler ve karakter sayısını belirler 6 karakter fazlası girilmez.

            button1.Text = "işlem üret";
            button1.Font = new Font("Georgia", 8, FontStyle.Bold);
            //button un textini düzenler.

            button2.Text = "cevapla";
            button2.Font = new Font("Georgia", 8, FontStyle.Bold);
            button2.Enabled = false;
            //button ikinin textini düzenler ve enabledini false yaparak erişilmez yapar.
            
            button3.Text = "yeniden başla";
            button3.Font = new Font("Georgia", 8, FontStyle.Bold);
            button3.Visible = false;
            //button un textini düzenler ve visible sini false yaparak oyun başında buttonu saklar.
         

            radioButton1.Text = "kolay";
            radioButton2.Text = "orta";
            radioButton3.Text = "zor";
            //radiobuttonların textlerini düzenler.

            timer1.Start();
            timer1.Interval = 1000;
            //timeri başlatır ve saniyesini ayarlar.

            dateTimePicker1.Font = new Font("Geargia", 8, FontStyle.Italic);
            dateTimePicker1.ShowUpDown = true;
            //takvim değerlerini ayarlamak için pencere açar.
            dateTimePicker1.MinDate = new DateTime(1985, 6, 20);
            dateTimePicker1.MaxDate = DateTime.Today;
            //dateTimePicker ın min ve max değerlerini ayarlar.
            DateTime dt = dateTimePicker1.Value;

            notifyIcon1.Text = "oyun";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            //ikon ekler (i).
            notifyIcon1.BalloonTipText = "kolay gelsin :)";
            //uygulamanın ikonundaki mesaj başlığı.
            notifyIcon1.ShowBalloonTip(5000);
            //süresini belirler.
            groupBox1.Text = "OYUN ALANI";
            //groupBox un textini değiştirir.

            listBox1.BackColor = Color.MediumPurple;
            listBox1.Items.Add("mor");
            listBox1.Items.Add("yeşil");
            listBox1.Items.Add("pembe");
            listBox1.Items.Add("sarı");
            //listbox un arka plan rengini belirler ve indexlerini ekler.
            checkBox1.Font = new Font("Georgia", 8, FontStyle.Italic);
            checkBox1.Text = "oyunu beğendim";
            checkBox2.Font = new Font("Georgia", 8, FontStyle.Italic);
            checkBox2.Text = "oyunu beğenmedim";
            //checbox un textlerini ve fontlarını ayarlar. 
        }
        Random rastgele = new Random();
        //rastgele adında random üretir.
        int puan = 0;
        int süre = 60;

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            maskedTextBox1.Clear();
            //button1 e tıklandığında buton1 erişilir ve button2 erişilmez olur

            int sayi1, sayi2, işlem;
            int a, b;
            int toplam, carp, çıkar, bol;

            if (radioButton1.Checked == true)
            {
                sayi1 = rastgele.Next(0, 51);
                sayi2 = rastgele.Next(0, 51);
                //radiobutton1 seçildiğinde 1 ile 50 arasında rastgele sayı uretir.
                label1.Text = sayi1.ToString();
                label2.Text = sayi1.ToString();
               //üretilen sayılar labellere yazılır.
            }
            if (radioButton2.Checked == true)
            {
                sayi1 = rastgele.Next(49,200);
                sayi2 = rastgele.Next(49, 200);
                //radibutton2 seçildiğinde 50 ile 200 arasında rastgele sayı üretir.
                label1.Text = sayi1.ToString();
                label2.Text = sayi1.ToString();
                //üretilen sayılar labellere yazdırılır.
            }
            if (radioButton3.Checked == true)
            {
                sayi1 = rastgele.Next(199, 1001);
                sayi2 = rastgele.Next(199, 1001);
                //raddiobutton3 seçildiğinde 200 ile 1000 arasında rastgele sayi üretir
                label1.Text = sayi1.ToString();
                label2.Text = sayi1.ToString();
                //üretilen sayılar labellere yazılır.
            }
            işlem = rastgele.Next(1, 5);
            a = Convert.ToInt32(label1.Text);
            b = Convert.ToInt32(label2.Text);
            //labellerdeki sayılar inteegere convert edilir,

            if (işlem == 1)
            {
                label3.Text = "+";
                toplam = a + b;
                label5.Text = toplam.ToString();
                //toplama yapılır
            }
            if(işlem==2)
            {
                label3.Text = "-";
                çıkar = a - b;
                label5.Text = çıkar.ToString();
                //çıkarma yapılır.
            }
            if (işlem == 3)
            {
                label3.Text = "*";
                carp = a * b;
                label5.Text = carp.ToString();
                //çarpma yapılır
            }
            if (işlem == 4)
            {
                label3.Text = "/";
                bol = a / b;
                label5.Text = bol.ToString();
                //bölme yapılır.
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            //button2 ye tıklandığında button1 erişilir button2 ise erişilmez olur.

            if (label5.Text == maskedTextBox1.Text)
            {
                puan = puan + 10;
                label7.Text = puan.ToString();
                //işlem sonucu label5 e yazılır(visible=true) label5 dki sonuç ile textboxtaki sonuç eşitse 10 puan eklenir.
            }
            else
            {
                puan = puan - 10;
                label7.Text = puan.ToString();
                //label5 teki sonuç ile textboxtaki sonuç eşit değilse 10 puan siler.
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            süre--;
            label9.Text = süre.ToString();
            //süreyi 1 er 1er azaltır ve label9 a yazdırır.
            progressBar1.Value += 1;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 60;
            progressBar1.Step = 5;
            //progressaBarın min/max değerlerini belirler ve progressBarı 1er 1er arttırır.
            
            if (süre == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                timer1.Stop();
                süre = 60;
                button3.Visible = true;
                //süre 0 olduğunda button1 ve button2 erişilmez olur timer durur.
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            //button3 e tıklandığında button1 aktif button 2 pasif olur.
            timer1.Start();
            süre = 60;
            button3.Visible = false;
            //süre başladığında button3 gizlenir
            puan = 0;
            label7.Text = puan.ToString();
            //puanı labele yazdırır
            label1.Text = "0";
            label2.Text = "0";
            maskedTextBox1.Clear();
            //button3 e tıklandığında button1 erişilebilir button2 erişilmez olur. ve timer yeniden başlar
            //kısaca oyun en baştaki haline döner.
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = radioButton1.Text;
            //raddiobuttondan gelen değeri labele yazdırır.
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = radioButton2.Text;
            //raddiobuttondan gelen değeri labele yazdırır.

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = radioButton3.Text;
            //raddiobuttondan gelen değeri labele yazdırır.
        }

        private void nasılOynanırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "İşlem üret butonuna basarak yeni işlem türetin ve sonuçları bulmaya çalışın. Süre bitmeden tamamlamanız gerekiyor. Bol şanslar :).";
            //menustripetki nasıl oynanır butonuna tıklandığında richtextboxa yazdırır.c
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Belli bir yaş grubundaki çoçuklar için, basit matematik olarak gördüşümüz dört işlem yeteneğini geliştirir, işlem hızını arttırır ve hızlı olmasını sağlar";
            //raddiobuttondan gelen değeri labele yazdırır.

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                this.BackColor = Color.Purple;
            }
            if (listBox1.SelectedIndex == 1)
            {
                this.BackColor = Color.Green;
            }
            if (listBox1.SelectedIndex == 2)
            {
                this.BackColor = Color.DeepPink;
            }
            if (listBox1.SelectedIndex == 3)
            {
                this.BackColor = Color.Yellow;
            }
            //listboxtaki seçilen indexe göre arkaplan rengini değiştirir.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) 
            {
                MessageBox.Show("teşekkürler");
            }
                
            //ceheckbox seçildiğinde messageboxla messaj verir,
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                MessageBox.Show("üzgünüm");
            }

            //ceheckbox seçildiğinde messageboxla messaj verir,


        }
        private void puanlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

    }
}
