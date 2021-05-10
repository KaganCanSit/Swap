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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        SQLBaglantisi baglanti = new SQLBaglantisi();

        //Değerleri Kullanıcı Tablosu içerisine aktarıyoruz.
        private void BasvuruButton_Click(object sender, EventArgs e)
        {
            //Değerlerin Boş Girilmesi Durumunda Uyarı Vermesini Sağlıyoruz.
            if (AdTB.Text == "" || SoyadTB.Text == "" || TCTB.Text == "" || TelTB.Text == "" || MailTB.Text == "" || IlTB.Text == "" || IlceTB.Text == "" || KullaniciAdiTB.Text == "" || KullaniciSifreTB.Text == "")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Kullanicilar(Ad, Soyad, KullaniciTuru, KullaniciAdi, Şifre, [Para Miktari], TC, Telefon, Email, Il, Ilce)" +
                "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", AdTB.Text);
                komut.Parameters.AddWithValue("@p2", SoyadTB.Text);
                komut.Parameters.AddWithValue("@p3", "Kullanici");
                komut.Parameters.AddWithValue("@p4", KullaniciAdiTB.Text);
                komut.Parameters.AddWithValue("@p5", KullaniciSifreTB.Text);
                komut.Parameters.AddWithValue("@p6", 0);
                komut.Parameters.AddWithValue("@p7", TCTB.Text);
                komut.Parameters.AddWithValue("@p8", TelTB.Text);
                komut.Parameters.AddWithValue("@p9", MailTB.Text);
                komut.Parameters.AddWithValue("@p10", IlTB.Text);
                komut.Parameters.AddWithValue("@p11", IlceTB.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "Şu an sisteme giriş yapabilirsiniz.");
                baglanti.baglanti().Close();
            }
        }
    }
}
