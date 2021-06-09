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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //Görünebilirlik Ayarı
        private void HesapButton_Click(object sender, EventArgs e)
        {
            FinanceGroupBox.Visible = false;
            BuyProductGroupBox.Visible = false;
            SatinAlmaGecmisiGB.Visible = false;
            MoneyGB.Visible = true;
            UrunEkleGB.Visible = true;
            BilgiLabel.Visible = true;
        }
        private void BuyButton_Click(object sender, EventArgs e)
        {
            MoneyGB.Visible = false;
            UrunEkleGB.Visible = false;
            BilgiLabel.Visible = false;
            SatinAlmaGecmisiGB.Visible = false;
            FinanceGroupBox.Visible = true;
            BuyProductGroupBox.Visible = true;
        }

        private void SatinAlmaGecmisiFB_Click(object sender, EventArgs e)
        {
            MoneyGB.Visible = false;
            UrunEkleGB.Visible = false;
            BilgiLabel.Visible = false;
            FinanceGroupBox.Visible = false;
            BuyProductGroupBox.Visible = false;
            SatinAlmaGecmisiGB.Visible = true;
        }

        //Sql Bağlantı Adresimizi Alıyoruz.
        SQLBaglantisi baglanti = new SQLBaglantisi();

        //ComboBox içerisinde UrunID'lerinin çekilmesi.
        void UrunIdComboBoxVeri()
        {
            SqlCommand komut = new SqlCommand("Select * From AnaUrunTablosu", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UrunEkleSecimCB.ValueMember = "UrunID";
            UrunEkleSecimCB.DataSource = dt;
            UrunSecimiComboBox.ValueMember = "UrunID";
            UrunSecimiComboBox.DataSource = dt;
            UrunSecimComboBox.ValueMember = "UrunID";
            UrunSecimComboBox.DataSource = dt;
        }

        //ComboBox'ların İçerisini Hatali Seçim Olmaması İçin Ürün Id'leri İle Dolduruyoruz.
        private void MainMenu_Load(object sender, EventArgs e)
        {
            UrunIdComboBoxVeri();
            TalepIzle();
        }

        //Hesap >> Para Ekleme Onay Başvurusu
        private void ParaEkleButton_Click(object sender, EventArgs e)
        {
            //Değerlerin Boş Girilmesi Durumunda Uyarı Vermesini Sağlıyoruz.
            if (ParaEkleTB.Text == "" || ParaTipleriComboBox.Text== "")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into ParaOnay(KullaniciID, ParaMiktari,ParaTipiAd)" + "values(@p0, @p1,@p2)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p0", Login.UserId);
                komut.Parameters.AddWithValue("@p1", ParaEkleTB.Text);
                komut.Parameters.AddWithValue("@p2", ParaTipleriComboBox.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Onaylacağız.");
                baglanti.baglanti().Close();
            }
        }

        //Hesap >> Sisteme Ürün Ekleme Onay Başvurusu
        private void UrunEkleButton_Click(object sender, EventArgs e)
        {
            if (UrunEkleSecimCB.Text == "" || UrunMiktariTB.Text == "" || SatisTutariTB.Text == "")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into UrunOnay(KullaniciID,UrunID,Miktarkg,SatisFiyati)" + "values(@p0,@p1,@p2,@p3)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p0", Login.UserId);
                komut.Parameters.AddWithValue("@p1", UrunEkleSecimCB.Text);
                komut.Parameters.AddWithValue("@p2", UrunMiktariTB.Text);
                komut.Parameters.AddWithValue("@p3", SatisTutariTB.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Onaylacağız.");
                baglanti.baglanti().Close();
            }
        }
       
        //Ürün Satın Al >> İçerisinde Tabloda Seçime Göre Genel Ürünleri Gösterme.
        private void GoruntuleButton_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From KullaniciUrun Where UrunID=" + UrunSecimiComboBox.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FinanceDataGrid.DataSource = dt;            
        }

        //Alım Geçmişi Butonu
        private void DateButton_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From AlimKayitTablosu Where KullaniciID=" + Login.UserId + "and Tarih BETWEEN @t1 and @t2", baglanti.baglanti());
            SqlDataAdapter data = new SqlDataAdapter(komut);
            data.SelectCommand.Parameters.AddWithValue("@t1", StartDatePicker.Value);
            data.SelectCommand.Parameters.AddWithValue("@t2", EndDatePicker.Value);
            DataTable dt = new DataTable();
            data.Fill(dt);
            SatinAlmaGecmisiDataGrid.DataSource = dt;
        }





        //Ürün Satın Al >> Ürün Satın Alma, Ürünlerin Sistemden Düşülmesi, Para Değerlerinin Düzeltilmesi İşlemleri.
        private void SatinAlButton_Click(object sender, EventArgs e)
        {
            int UrunId = Convert.ToInt32(UrunSecimiComboBox.Text);
            double Miktar = Convert.ToDouble(UrunMiktariTextBox.Text);
            double Para = Convert.ToDouble(ParaLabel.Text);

            List<KullaniciUrun> Urunler = ProductList(UrunId);
            foreach (var urun in Urunler) {

                 if (Miktar >=  double.Parse(urun.MiktarKG.ToString()))
                {
                    if ((Miktar * double.Parse(urun.Fiyat.ToString())) <= Para)
                    {
                        double uruncarpfiyat = 0;
                        uruncarpfiyat = double.Parse(urun.MiktarKG.ToString()) * double.Parse(urun.Fiyat.ToString());
                        Para -= (uruncarpfiyat+(uruncarpfiyat/100));
                        UpdateSales(int.Parse(urun.KullaniciId.ToString()), (double.Parse(urun.MiktarKG.ToString()) * double.Parse(urun.Fiyat.ToString())));
                        Miktar -= double.Parse(urun.MiktarKG.ToString());
                        urun.MiktarKG = 0;
                    }
                    else
                    {
                        MessageBox.Show("Alışveriş Yapabilmek İçin Gerekli Tutar : " + (Miktar * double.Parse(urun.Fiyat.ToString())) + " TL'dir. Bakiyeniz Yetersiz.");
                        break;
                    }
                }
                else
                {

                    if ((Miktar * double.Parse(urun.Fiyat.ToString())) <= Para)
                    { 
                        Para -= (Miktar * double.Parse(urun.Fiyat.ToString()));
                        UpdateSales(int.Parse(urun.KullaniciId.ToString()), (Miktar * double.Parse(urun.Fiyat.ToString())));
                        urun.MiktarKG -= Miktar;
                        Miktar = 0;
                       
                    }
                    else
                    {
                        MessageBox.Show("Alışveriş Yapabilmek İçin Gerekli Tutar : " + (Miktar * double.Parse(urun.Fiyat.ToString())) + " TL'dir. Bakiyeniz Yetersiz.");
                        break;
                    }
                }
                if (Miktar == 0)
                {
                    break;
                }
            }
            UpdateTable(Urunler, Para);  
        }

        private List<KullaniciUrun> ProductList(int UrunId) {
            List<KullaniciUrun> Urunler = new List<KullaniciUrun>();
            SqlCommand komut = new SqlCommand("SELECT  Id,UrunID,MiktarKG,Fiyat,KullaniciID From KullaniciUrun Where UrunID=@p1 order by Fiyat,MiktarKG ", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", UrunId);

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Urunler.Add(new KullaniciUrun(
                    int.Parse(dr[0].ToString()),
                    int.Parse(dr[1].ToString()),
                    double.Parse(dr[2].ToString()),
                    double.Parse(dr[3].ToString()),
                    int.Parse(dr[4].ToString())
                    ));
            }

            dr.Close();
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            return Urunler;
        }

        private bool UpdateTable(List<KullaniciUrun> urun,double para)
        {
            List<KullaniciUrun> urunler = urun;
            SqlCommand komut;
            try
            {
                foreach (var item in urunler)
                {
                    komut = new SqlCommand("UPDATE KullaniciUrun SET MiktarKG = @p1 WHERE Id = @p2", baglanti.baglanti());
                    komut.Parameters.AddWithValue("@p1", double.Parse(item.MiktarKG.ToString()));
                    komut.Parameters.AddWithValue("@p2", int.Parse(item.Id.ToString()));
                    komut.ExecuteNonQuery();
                    baglanti.baglanti().Close();
                }

                komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari = @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", para);
                komut.Parameters.AddWithValue("@p2", Login.UserId);
                komut.ExecuteNonQuery();
                ParaLabel.Text = para.ToString();

                MessageBox.Show("Satın Alım Başarılı");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Bir hata oluştu." + e.ToString());
                return false;
            }
        }

        private void UpdateSales(int kullaniciId,double miktar)
        {
            SqlCommand komut;
            try
            {
                komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", miktar);
                komut.Parameters.AddWithValue("@p2", kullaniciId);
                komut.ExecuteNonQuery();

                //Muhasebe Kullanıcısına %1 Komisyonu İçin Para Ekleme.
                komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", (miktar/100));
                komut.Parameters.AddWithValue("@p2", 2);
                komut.ExecuteNonQuery();

                baglanti.baglanti().Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Bir hata oluştu." + e.ToString());
            }
        }







        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void TalepOlusturBtn_Click(object sender, EventArgs e)
        {
            //UrunSecimComboBox
            //TalepKGTB
            //TalepFiyatTB
        }
        void TalepIzle()
        {
            SqlCommand komut = new SqlCommand("Select TalepID, KullaniciID, UrunID, MiktarKG, Fiyat, isActive From TalepTablosu", baglanti.baglanti());
            SqlDataReader reader = komut.ExecuteReader();
            List<TalepOlustur> kullaniciverileri = new List<TalepOlustur>();
            int TalepID, KullaniciID, UrunID, MiktarKG, Fiyat, isActive;

            //!!!Bu sorgunun en büyük hatası tablo içerisinde NULL veri varsa okuma işlemi gerçekleşmiyor.
            while(reader.Read())
            {
                kullaniciverileri.Add(new TalepOlustur(
                    TalepID=int.Parse(reader[0].ToString()),
                    KullaniciID=int.Parse(reader[1].ToString()),
                    UrunID=int.Parse(reader[2].ToString()),
                    MiktarKG=int.Parse(reader[3].ToString()),
                    Fiyat=int.Parse(reader[4].ToString()),
                    isActive=int.Parse(reader[5].ToString())
                    ));

                //MessageBox.Show(Convert.ToString(TalepID) + " " + Convert.ToString(KullaniciID) + " " + Convert.ToString(UrunID) + " " +
                //    " " + Convert.ToString(MiktarKG) + " " + Convert.ToString(Fiyat) + " " + Convert.ToString(isActive));
            }

            reader.Close();
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }
    }

}
