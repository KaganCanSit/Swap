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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        //SQL Sınıfı İle Veri Kaynağımıza Bağlantı Sağlıyoruz.
        SQLBaglantisi baglanti = new SQLBaglantisi();

        void KullaniciBilgileriGetir()
        {
            SqlCommand komut3 = new SqlCommand("Select * From Kullanicilar", baglanti.baglanti());
            SqlDataAdapter data2 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            data2.Fill(dt3);
            KullanicilarDatGrid.DataSource = dt3;
        }
        void KullanicilarinUrunBilgisiniGetir()
        {
            SqlCommand komut4 = new SqlCommand("Select * From KullaniciUrun", baglanti.baglanti());
            SqlDataAdapter data3 = new SqlDataAdapter(komut4);
            DataTable dt4 = new DataTable();
            data3.Fill(dt4);
            KullaniciUrunDataGrid.DataSource = dt4;
        }

        //ComboBox içerisinde UrunID'lerinin Çekilmesi
        void UrunIdComboBox()
        {
            SqlCommand komut = new SqlCommand("Select * From AnaUrunTablosu", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UrunIDComboBox.ValueMember = "UrunID";
            UrunIDComboBox.DataSource = dt;
        }
        //ComboBox İçerisine  KullaniciID'lerinin Çekilmesi
        void KullaniciIDCB()
        {
            SqlCommand komut = new SqlCommand("Select * From Kullanicilar", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KullaniciIDComboBox.ValueMember = "KullaniciID";
            KullaniciIDComboBox.DataSource = dt;
            KullaniciIDComboBox2.ValueMember = "KullaniciID";
            KullaniciIDComboBox2.DataSource = dt;
        }

        //Form Yüklenirken Gridlerin İçerisini ve ComboBox'ları Tablo Verilerinin Çekilmesi
        private void AdminForm_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From ParaOnay", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ParaOnayDataGrid.DataSource = dt;

            SqlCommand komut2 = new SqlCommand("Select * From UrunOnay", baglanti.baglanti());
            SqlDataAdapter data = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            data.Fill(dt2);
            UrunOnayDataGrid.DataSource = dt2;

            KullaniciBilgileriGetir();
            KullanicilarinUrunBilgisiniGetir();

            UrunIdComboBox();
            KullaniciIDCB();
        }

 
        //Para Değerini Güncellenme İşlemi(Onay)
        public int KullaniciSecim;
        private void ParaEkleButton_Click(object sender, EventArgs e)
        {
            KullaniciSecim= Convert.ToInt32(KullaniciIDComboBox.Text);

            SqlCommand komut = new SqlCommand("update Kullanicilar set ParaMiktari=@p6 where KullaniciID="+KullaniciSecim, baglanti.baglanti());
            komut.Parameters.AddWithValue("@p6", SonParaTB.Text);
            komut.ExecuteNonQuery();

            MessageBox.Show("Kullanıcının Sahip Olduğu Para Miktari Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.baglanti().Close();
            KullaniciBilgileriGetir();
        }

        //Urun Ekleme İşlemi(Onay)
        private void UrunEkle_Click(object sender, EventArgs e)
        {
            if (KullaniciIDComboBox2.Text == "" || UrunIDComboBox.Text == "" || MiktarTextBox.Text == "" || FiyatTextBox.Text == "")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into KullaniciUrun(KullaniciID, UrunID, MiktarKG, Fiyat)" + "values(@p0,@p1,@p2,@p3)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p0", KullaniciIDComboBox2.Text);
                komut.Parameters.AddWithValue("@p1", UrunIDComboBox.Text);
                komut.Parameters.AddWithValue("@p2", MiktarTextBox.Text);
                komut.Parameters.AddWithValue("@p3", FiyatTextBox.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. " + Environment.NewLine + "Ürün Sisteme Eklendi.");
                baglanti.baglanti().Close();
                KullanicilarinUrunBilgisiniGetir();
            }
        }
    }
}
