using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace beyza_16008118047
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection Conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=oyun1;Trusted_Connection=True;");
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.SteelBlue;
            this.Text = "kayıt ol/sil formu";
            //formun arkaplan rengini ve textini değiştirir.

            label1.Text = "Kullanıcı Adı :";
            label1.Font = new Font("Georgia", 7, FontStyle.Bold);
            label2.Text = "Şifre :";
            label2.Font = new Font("Georgia", 7, FontStyle.Bold);
            label3.Text = "Doğum Tarihi :";
            label3.Font = new Font("Georgia", 7, FontStyle.Bold);
            label5.Text = "yaş";
            label5.Font = new Font("Georgia", 7, FontStyle.Bold);
            label6.Text = "cinsiyet";
            label6.Font = new Font("Georgia", 7, FontStyle.Bold); 
            label7.Text = "aranacak kişi :";
            label7.Font = new Font("Georgia", 7, FontStyle.Italic);
            //labellerin textini ve fontunu ayarlar.

            button1.Text = "Kayıt Ol";
            button2.Text = "Sil";
            button3.Text = "ara";
            button2.ForeColor = Color.Red;
            //buttonların textini ve textin rengini belirler.

            textBox2.Multiline = true;
            textBox1.Multiline = true;
            //textboxun tek satır yerine çok satır özelliğini açar.

            label4.Text = dateTimePicker1.Value.ToString();
            //labele datetimepickerdeki değeri yazdırır.

            dataGridView1.GridColor = Color.Aqua;
            dataGridView1.MultiSelect = true;
            //datagridview de tablo çizgilerinin rengini değiştirir ve çoklu seçme özelliğini açar.

            comboBox1.Items.Add("kadın");
            comboBox1.Items.Add("erkek");
            comboBox1.Items.Add("belirtmek istemiyorum");
            //combobox a değer ekler.

            comboBox1.Sorted = true; 
            dateTimePicker1.ShowUpDown = true;
            tabPage1.Text = "kayıt";
            tabPage1.BackColor = Color.SteelBlue;
            tabPage2.Text = "ara";
            tabPage2.BackColor = Color.SteelBlue;
            //tabpagenin textini ve arkaplan rengini değiştirir.

            listView1.View = View.Details;
            //listviewdeki sütunlar belirginleşir.

            listView1.Columns.Add("kAdı");
            listView1.Columns.Add("cinsiyet"); ;
            listView1.Columns.Add("yaş");
            listView1.MultiSelect = true;
            //listview sütun başlıklarını belirler ve çoklu secme özelliğini açar.
            listView1.GridLines = true;
            //ListView'e ızgaralı görünüm kazandırır. (Excel tablosu gibi.)
            
            listView1.CheckBoxes = true;
            //Verimizin başına checkbox kutucuğu ekler.



            kayıtgörüntüle();
           
            
        }
        public void kayıtgörüntüle()
        {
            Conn.Open();
            string kayıt = "select*from oyuncular";
            SqlCommand komut = new SqlCommand(kayıt, Conn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Conn.Close();
            //oyuncular tablosundan verileri datagridviewe gösterir.
        }
        public void kayıtekle()
        {
            if (textBox1.Text!=null && textBox2.Text != null)
            {
                Conn.Open();
                string kayit = "insert into oyuncular (kAdı,sifre,dTarihi,yaş,cinsiyet) values (@ku,@sf,@dt,@ys,@cns)";
                SqlCommand komut = new SqlCommand(kayit, Conn);
                komut.Parameters.AddWithValue("@ku", textBox1.Text);
                komut.Parameters.AddWithValue("@sf", textBox2.Text);
                komut.Parameters.AddWithValue("@dt", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@ys", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@cns", comboBox1.Text);
                komut.ExecuteNonQuery();
                Conn.Close();                           
            }
            kayıtgörüntüle();
            //yeni kayıt ekleme işlemi yapar.
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
             kayıtekle();

        }
        void KayıtSil(int kAdı)
        {
            string sql = "DELETE FROM oyuncular WHERE kAdı=@ka";
            SqlCommand komut = new SqlCommand(sql, Conn);
            komut.Parameters.AddWithValue("@ka",kAdı);
            Conn.Open();
            komut.ExecuteNonQuery();
            Conn.Close();
            //oyuncular tablosundan kullanıcı adına göre kayıt siler.
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int kAdı = Convert.ToInt32(drow.Cells[1].Value);
                KayıtSil(kAdı);
            }
            kayıtgörüntüle();
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            tabPage2.BackColor = Color.Green;
            //tabpage clicklendiğinde arka plan yeşil olur.
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox1, "Bu alan boş geçilemez");
            }
            Conn.Open();
                SqlCommand komut = new SqlCommand("select*from oyuncular where kAdı like '%" + textBox3.Text + "%'", Conn);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["kAdı"].ToString();
                    ekle.SubItems.Add(oku["cinsiyet"].ToString());
                    ekle.SubItems.Add(oku["yaş"].ToString());
                    listView1.Items.Add(ekle);
                }
                Conn.Close();
            //listviewvde veri araması yapar.

          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

        
    
}
