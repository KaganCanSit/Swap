using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Swap
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Oluşturmuş Olduğumuz Database Sınıfı Aracılığıyla Database'den Veri Alımı
        SQLBaglantisi baglanti = new SQLBaglantisi();
        SqlCommand komut;
        
        //Program İçerisinde Kullanabilmek İçin Kullanıcının ID ve Parası Alınarak Public Değişkene Atanması
        public static int UserId;
        public static int ParaMik;

        //Kullanıcının Adı, Soyadı, Kullanıcı Tipi Kontrolü Ve Giriş
        private void LoginButton_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("Select KullaniciID, ParaMiktari From Kullanicilar where KullaniciTuru=@p3 and KullaniciAdi=@p4 and Şifre=@p5", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p3", UserTypeComboBox.Text);
            komut.Parameters.AddWithValue("@p4", NameTextBox.Text);
            komut.Parameters.AddWithValue("@p5", PassTextBox.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                UserId = int.Parse(dr[0].ToString());
                ParaMik =int.Parse(dr[1].ToString());
                
                //Kullanıcı Girişi Yetkisine Göre İşlem Yapacağı Forma İletiyoruz. 
                if (UserTypeComboBox.Text == "Kullanici")
                {
                    MainMenu MainMenu = new MainMenu();
                    MainMenu.ParaLabel.Text = (dr[1].ToString());
                    MainMenu.Show();
                    this.Hide();
                }
                else if (UserTypeComboBox.Text == "Admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    this.Hide(); ;
                }
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre Girdiniz. Lütfen Yeniden Deneyiniz.");
            }
            baglanti.baglanti().Close();
        }


        //Kayıt Olma Ekranına Geçiş Ve Giriş Ekranını Gizleme
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register Register = new Register();
            Register.Show();
            this.Hide();
        }

        //Hızlı İşlem İçin ComboBox Tercihinin "Kullanici" Olarak Ayarlanmasi
        private void Login_Load(object sender, EventArgs e)
        {
            UserTypeComboBox.SelectedIndex = 1;
        }
    }
}

