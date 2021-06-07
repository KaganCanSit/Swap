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
using System.Xml;  //Bu önemli XML kullanmak için gerek

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

        //Görünebilirlik Ayarı
        private void ParaOnayButton_Click(object sender, EventArgs e)
        {
            ParaOnayBekleyenlerGB.Visible = true;
            ParaIslemleriGerceklestirGB.Visible = true;
            KullaniciyaParaEkleGB.Visible = true;
            BorsaDurumuGB.Visible = true;
            HesapMakinesiGB.Visible = true;
            UrunOnayBekleyenlerGB.Visible = false;
            UrunIslemleriGerceklestirGB.Visible = false;
            KullaniciUrunEkleGB.Visible = false;
        }
        private void UrunOnayButton_Click(object sender, EventArgs e)
        {
            ParaOnayBekleyenlerGB.Visible = false;
            ParaIslemleriGerceklestirGB.Visible = false;
            KullaniciyaParaEkleGB.Visible = false;
            BorsaDurumuGB.Visible = false;
            HesapMakinesiGB.Visible = false;
            UrunOnayBekleyenlerGB.Visible = true;
            UrunIslemleriGerceklestirGB.Visible = true;
            KullaniciUrunEkleGB.Visible = true;
        }

        public DataTable source()
        {
            DataTable dt = new DataTable();     // DataTable Nesnemizi Yaratıyoruz.
            DataRow dr;                         // DataTable'ın Satırlarını Tanımlıyoruz.

            dt.Columns.Add(new DataColumn("Adı", typeof(string)));
            dt.Columns.Add(new DataColumn("Kod", typeof(string)));
            dt.Columns.Add(new DataColumn("Döviz alış", typeof(string)));
            dt.Columns.Add(new DataColumn("Döviz satış", typeof(string)));
            // DataTableımıza 4 sütün ekliyoruz ve değişken tiplerini tanımlıyoruz.

            XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            // XmlTextReader nesnesini yaratıyoruz ve parametre olarak xml dokümanın urlsini veriyoruz
            // XmlTextReader urlsi belirtilen xml dokümanlarına hızlı ve forward-only giriş imkanı sağlar.

            XmlDocument myxml = new XmlDocument();      // XmlDocument nesnesini yaratıyoruz.
            myxml.Load(rdr);                            // Load metodu ile xml yüklüyoruz

            XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
            XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
            XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
            XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");

            // XmlNodeList cinsinden her bir nodu, SelectSingleNode metoduna nodların xpathini parametre olarak göndererek tanımlıyoruz.
            //  dataGrid1.CaptionText = tarih.InnerText.ToString() + " tarihli merkez bankası kur bilgileri";
            // datagridimin captionu ayarlıyoruz.
            for (int i = 0; i < 12; i++)
            {
                dr = dt.NewRow();
                if (adi.Item(i).InnerText.ToString() == "ABD DOLARI" || adi.Item(i).InnerText.ToString() == "EURO" || adi.Item(i).InnerText.ToString() == "İNGİLİZ STERLİNİ")
                {
                    dr[0] = adi.Item(i).InnerText.ToString(); // i. adi nodunun içeriği
                    // Adı isimli DataColumn un satırlarını  /Tarih_Date/Currency/Isim node ları ile dolduruyoruz.
                    dr[1] = kod.Item(i).InnerText.ToString();
                    dr[2] = doviz_alis.Item(i).InnerText.ToString();
                    dr[3] = doviz_satis.Item(i).InnerText.ToString();
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        //Sistemdeki Kullanıcı Bilgileri DataGrid'e Yazılır.
        void KullaniciBilgileriGetir()
        {
            SqlCommand komut3 = new SqlCommand("Select * From Kullanicilar", baglanti.baglanti());
            SqlDataAdapter data2 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            data2.Fill(dt3);
            KullanicilarDatGrid.DataSource = dt3;
        }
        //Sistemdeki Kullanıcı Urun Bilgileri DataGried'e Yazılır.
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
            //Borsa Data Gridi İçin Form Yüklenirken Kaynak Belirityoruz.
            BorsaDataGrid.DataSource = source();

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

        //Temel Eklenecek Tutarı HEsaplama
        private void HesaplaBTN_Click(object sender, EventArgs e)
        {
            double anapara, eklenecektutar, kur;
            anapara = Convert.ToDouble(IlkParaTB.Text);
            eklenecektutar = Convert.ToDouble(EklenecekTutarTB.Text);
            kur = Convert.ToDouble(ParaAlisFiyatıTB.Text);
            SonucLabel.Text = "Sonuç: " + (anapara + (eklenecektutar * kur));
        }
    }
}
