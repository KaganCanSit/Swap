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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading;

namespace Swap
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
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

        //FONKSİYONLAR
        //Ürünü Satan Kişiye Parasının Ödenmesi
        void SaticiyaParasiniOdeme(int EklenecenkTutar, int KullaniciID)
        {
            SqlCommand komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", EklenecenkTutar);
            komut.Parameters.AddWithValue("@p2", KullaniciID);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }

        //Muhasebe Kullanıcısının %1'lik Ücretinin Ödenmesi
        void MuhasebeKomisyonOde(int ToplamSatisUcreti)
        {
            SqlCommand komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", (ToplamSatisUcreti / 100));
            komut.Parameters.AddWithValue("@p2", 2);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }

        //Program Kullanıcısından Yaptığı Satın Alma İşlemi Parasının Düşülmesi
        void KullanicidanIslemUcretiAl(int YeniPara)
        {
            //Satın Alan Kişiden Paranın Tahsil Edilmesi
            SqlCommand komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari = @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", YeniPara);
            komut.Parameters.AddWithValue("@p2", Login.UserId);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }

        //Satıcının Sahip Olduğu Ürün Adetinin Düşürülmesi
        void SatilanUrunleriDus(int KullaniciID, int YeniMiktar)
        {
            SqlCommand komut = new SqlCommand("UPDATE KullaniciUrun SET MiktarKG = @p1 WHERE Id = @p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p2", KullaniciID);
            komut.Parameters.AddWithValue("@p1", YeniMiktar);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }

        //Kullanıcının Satın Alma İşlemini Kayıt Altına Alıyoruz
        void SatinAlmaKayit(int UrunID, int Miktar, int Fiyat, int Komisyon)
        {
            SqlCommand komut = new SqlCommand("insert into AlimKayitTablosu(KullaniciID,Tarih,UrunID,Miktar,AlimTutari,UygulamaKomisyonu)" + "values(@p0,@p1,@p2,@p3,@p4,@p5)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p0", Login.UserId);
            komut.Parameters.AddWithValue("@p1", DateTime.Now.ToLocalTime());
            komut.Parameters.AddWithValue("@p2", UrunID);
            komut.Parameters.AddWithValue("@p3", Miktar);
            komut.Parameters.AddWithValue("@p4", Fiyat);
            komut.Parameters.AddWithValue("@p5", Komisyon);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }

        //Para Onay Başvurusundaki Verileri Tabloya Alma
        void ParaOnayBasvurusu(int EklenecekTutar, string ParaTipi)
        {
            SqlCommand komut = new SqlCommand("insert into ParaOnay(KullaniciID, ParaMiktari,ParaTipiAd)" + "values(@p0, @p1,@p2)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p0", Login.UserId);
            komut.Parameters.AddWithValue("@p1", EklenecekTutar);
            komut.Parameters.AddWithValue("@p2", ParaTipi);
            komut.ExecuteNonQuery();

            MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Onaylacağız.");
            baglanti.baglanti().Close();
        }

        //Girilen Bilgilerin Ürün Onay Tablosuna Eklenmesi
        void UrunOnayBasvurusu(int EklenecekUrun, int UrunMiktari, int SatisTutari)
        {
            SqlCommand komut = new SqlCommand("insert into UrunOnay(KullaniciID,UrunID,Miktarkg,SatisFiyati)" + "values(@p0,@p1,@p2,@p3)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p0", Login.UserId);
            komut.Parameters.AddWithValue("@p1", EklenecekUrun);
            komut.Parameters.AddWithValue("@p2", UrunMiktari);
            komut.Parameters.AddWithValue("@p3", SatisTutari);
            komut.ExecuteNonQuery();

            MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Onaylacağız.");
            baglanti.baglanti().Close();
        }

        //Seçilen UrunID Değerine Göre Tabloyu Getirme
        void SecimeGoreUrunleriGetir(int UrunSecimi)
        {
            SqlCommand komut = new SqlCommand("Select * From KullaniciUrun Where UrunID=" + UrunSecimi, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FinanceDataGrid.DataSource = dt;
            baglanti.baglanti().Close();
        }

        //Alınan Değerleri Talep Tablosuna Ekle
        void TalepTablosunaEkle(int UrunSecimi, int TalepKG, int TalepFiyat)
        {
            SqlCommand komut = new SqlCommand("insert into TalepTablosu(KullaniciID,UrunID,MiktarKG,Fiyat,isActive)" + "values(@p1,@p2,@p3,@p4,@p5)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", Login.UserId);
            komut.Parameters.AddWithValue("@p2", UrunSecimi);
            komut.Parameters.AddWithValue("@p3", TalepKG);
            komut.Parameters.AddWithValue("@p4", TalepFiyat);
            komut.Parameters.AddWithValue("@p5", 1);
            komut.ExecuteNonQuery();

            MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Talebiniz Hakkında Dönüş Sağlayacağız.");
            baglanti.baglanti().Close();
        }

        //isActive hücresinin 1'den 0'a çekilmesi. Bu sayede başka bir sorguda yeniden kontrol edilmesi önlenmiş olacak.
        void TalepAktiflikYonet(int TalepID)
        {
            SqlCommand komut = new SqlCommand("UPDATE TalepTablosu SET isActive = @p1 WHERE TalepID = @p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", 0);
            komut.Parameters.AddWithValue("@p2", TalepID);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }



        //ComboBox'ların İçerisini Hatali Seçim Olmaması İçin Ürün Id'leri İle Dolduruyoruz.
        private void MainMenu_Load(object sender, EventArgs e)
        {
            UrunIdComboBoxVeri();
            //TalepleriOku();
            Thread TalepControl = new Thread(new ThreadStart(TalepleriOku));
            TalepControl.Start();
        }
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


        //Hesap >> Para Ekleme Onay Başvurusu : Kullanıcı sisteme eklemek istediği para miktarı ve türünü bildiriyor.
        private void ParaEkleButton_Click(object sender, EventArgs e)
        {
            if (ParaEkleTB.Text == "" || ParaTipleriComboBox.Text == "")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                ParaOnayBasvurusu(Convert.ToInt32(ParaEkleTB.Text), ParaTipleriComboBox.Text);
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
                UrunOnayBasvurusu(Convert.ToInt32(UrunEkleSecimCB.Text), Convert.ToInt32(UrunMiktariTB.Text), Convert.ToInt32(SatisTutariTB.Text));
            }
        }

        //Ürün Satın Al >> İçerisinde Tabloda Seçime Göre Genel Ürünleri Gösterme.
        private void GoruntuleButton_Click(object sender, EventArgs e)
        {
            SecimeGoreUrunleriGetir(Convert.ToInt32(UrunSecimComboBox.Text));
        }

        //Alım Geçmişi Butonu
        private void DateButton_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select KayitID,KullaniciID,CONVERT(nvarchar(16),Tarih,104) as Tarih,UrunID,Miktar,AlimTutari,UygulamaKomisyonu From AlimKayitTablosu Where Tarih BETWEEN @t1 and @t2 and KullaniciID=" + Login.UserId, baglanti.baglanti());
            SqlDataAdapter data = new SqlDataAdapter(komut);
            data.SelectCommand.Parameters.AddWithValue("@t1", StartDatePicker.Value);
            data.SelectCommand.Parameters.AddWithValue("@t2", EndDatePicker.Value);
            DataTable dt = new DataTable();
            data.Fill(dt);
            SatinAlmaGecmisiDataGrid.DataSource = dt;
            baglanti.baglanti().Close();
        }
        //Alım Geçmişi Pdf Rapor Butonu
        private void PdfButton_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();

            PdfWriter.GetInstance(pdfDosya, new FileStream("D:Rapor.pdf", FileMode.Create));
            pdfDosya.Open();
            pdfDosya.AddCreator("Swap - Modern Dünyada Tarıma Dair Alışveriş");
            pdfDosya.AddAuthor("Kullanıcı");
            pdfDosya.AddTitle("SATIN ALMA RAPORU");

            SqlCommand komut = new SqlCommand("Select * From AlimKayitTablosu Where Tarih BETWEEN @t1 and @t2 and KullaniciID=" + Login.UserId, baglanti.baglanti());
            SqlDataAdapter data = new SqlDataAdapter(komut);
            data.SelectCommand.Parameters.AddWithValue("@t1", StartDatePicker.Value);
            data.SelectCommand.Parameters.AddWithValue("@t2", EndDatePicker.Value);
            SqlDataReader oku = komut.ExecuteReader();

            string id, tarih, miktar, alimtutar, komisyon, metin;
            metin = "KullaniciID / Tarih / Miktar / AlimTutari / UygulamaKomsiyon \n";
            pdfDosya.Add(new Paragraph(metin));
            while (oku.Read())
            {
                id = Convert.ToString(oku["KullaniciID"]);
                tarih = Convert.ToString(oku["Tarih"]);
                miktar = Convert.ToString(oku["Miktar"]);
                alimtutar = Convert.ToString(oku["AlimTutari"]);
                komisyon = Convert.ToString(oku["UygulamaKomisyonu"]);
                metin = id + "  -  " + tarih + "  -  " + miktar + "  -  " + alimtutar + "  -  " + komisyon + "\n";
                pdfDosya.Add(new Paragraph(metin));
            }
            pdfDosya.Close();
            baglanti.baglanti().Close();
        }

        //Ürün Satın Al >> Ürün Satın Alma, Ürünlerin Sistemden Düşülmesi, Para Değerlerinin Düzeltilmesi İşlemleri.
        private void SatinAlButton_Click(object sender, EventArgs e)
        {
            int UrunId = Convert.ToInt32(UrunSecimiComboBox.Text);
            int Miktar = Convert.ToInt32(UrunMiktariTextBox.Text);
            int Para = Convert.ToInt32(ParaLabel.Text);

            List<KullaniciUrun> Urunler = ProductList(UrunId);
            foreach (var urun in Urunler)
            {

                if (Miktar >= urun.MiktarKG)
                {
                    if ((Miktar * urun.Fiyat) <= Para)
                    {
                        int uruncarpfiyat = 0;
                        uruncarpfiyat = urun.MiktarKG * urun.Fiyat;
                        Para -= (uruncarpfiyat + (uruncarpfiyat / 100));
                        UpdateSales(urun.KullaniciId, urun.MiktarKG * urun.Fiyat);
                        Miktar -= urun.MiktarKG;
                        urun.MiktarKG = 0;
                    }
                    else
                    {
                        MessageBox.Show("Alışveriş Yapabilmek İçin Gerekli Tutar : " + Miktar * urun.Fiyat + " TL'dir. Bakiyeniz Yetersiz.");
                        break;
                    }
                }
                else
                {
                    if ((Miktar * urun.Fiyat) <= Para)
                    {
                        int aradegisken;
                        aradegisken = Miktar * urun.Fiyat;
                        Para -= (aradegisken + (aradegisken / 100));
                        UpdateSales(urun.KullaniciId, Miktar * urun.Fiyat);
                        urun.MiktarKG -= Miktar;
                        Miktar = 0;
                    }
                    else
                    {
                        MessageBox.Show("Alışveriş Yapabilmek İçin Gerekli Tutar : " + Miktar * urun.Fiyat + " TL'dir. Bakiyeniz Yetersiz.");
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
        private List<KullaniciUrun> ProductList(int UrunId)
        {
            List<KullaniciUrun> Urunler = new List<KullaniciUrun>();
            SqlCommand komut = new SqlCommand("SELECT Id,UrunID,MiktarKG,Fiyat,KullaniciID From KullaniciUrun Where UrunID=@p1 order by Fiyat,MiktarKG ", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", UrunId);

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Urunler.Add(new KullaniciUrun(
                    int.Parse(dr[0].ToString()),
                    int.Parse(dr[1].ToString()),
                    int.Parse(dr[2].ToString()),
                    int.Parse(dr[3].ToString()),
                    int.Parse(dr[4].ToString())));
            }
            dr.Close();
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            return Urunler;
        }
        private bool UpdateTable(List<KullaniciUrun> urun, int para)
        {
            List<KullaniciUrun> urunler = urun;
            SqlCommand komut;
            try
            {
                foreach (var item in urunler)
                {
                    int IlkMiktar = 0;
                    komut = new SqlCommand("SELECT MiktarKG From KullaniciUrun Where Id=" + item.Id, baglanti.baglanti());
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        IlkMiktar = int.Parse(dr[0].ToString());
                    }
                    dr.Close();
                    komut.ExecuteNonQuery();
                    baglanti.baglanti().Close();

                    SatilanUrunleriDus(item.Id, item.MiktarKG);

                    if (item.MiktarKG == 0)
                    {
                        SatinAlmaKayit(item.UrunId, IlkMiktar, item.Fiyat, ((item.Fiyat * IlkMiktar) / 100));

                    }
                    else if (IlkMiktar - item.MiktarKG != 0 || IlkMiktar - item.MiktarKG > 0 || IlkMiktar != item.MiktarKG)
                    {
                        SatinAlmaKayit(item.UrunId, IlkMiktar - item.MiktarKG, item.Fiyat, ((item.Fiyat * (IlkMiktar - item.MiktarKG)) / 100));
                    }
                }

                KullanicidanIslemUcretiAl(para);

                ParaLabel.Text = Convert.ToString(para);
                MessageBox.Show("Satın Alım Başarılı");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Bir hata oluştu." + e.ToString());
                return false;
            }
        }
        private void UpdateSales(int kullaniciId, int miktar)
        {
            try
            {
                SaticiyaParasiniOdeme(miktar, kullaniciId);
                MuhasebeKomisyonOde(miktar);
            }
            catch (Exception e)
            {
                MessageBox.Show("Bir hata oluştu." + e.ToString());
            }
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Talep İle Satın Alma İşlemleri
        private void TalepOlusturButton_Click(object sender, EventArgs e)
        {
            if (TalepKGTB.Text == "" || TalepFiyatTB.Text == " ")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                int sonuc;
                sonuc = Convert.ToInt32(TalepFiyatTB.Text) * Convert.ToInt32(TalepKGTB.Text);
                if (sonuc > Convert.ToInt32(ParaLabel.Text))
                {
                    MessageBox.Show("Talep Ettiginiz Urun Toplam Hesap Bakiyesini Asiyor. Islem Gercekleşemez.");
                    Environment.Exit(0);
                }
                TalepTablosunaEkle(Convert.ToInt32(UrunSecimComboBox.Text), Convert.ToInt32(TalepKGTB.Text), Convert.ToInt32(TalepFiyatTB.Text));
                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Talebiniz Hakkında Dönüş Sağlayacağız.");
            }
        }

        public void TalepleriOku()
        {
            int TalepID, KullaniciID, UrunID, MiktarKG, Fiyat, isActive;
            int KUID, KUKullaniciID, KUUrunID, KUMiktarKG, KUFiyat;         //Kullanıcı Ürün Tablosu = KU
            int paramiktari, dusulecekpara, komisyon;

            while (true)
            {
                SqlCommand komut = new SqlCommand("Select * From TalepTablosu", baglanti.baglanti());
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    TalepID = Convert.ToInt32(oku["TalepID"]);
                    KullaniciID = Convert.ToInt32(oku["KullaniciID"]);
                    UrunID = Convert.ToInt32(oku["UrunID"]);
                    MiktarKG = Convert.ToInt32(oku["MiktarKG"]);
                    Fiyat = Convert.ToInt32(oku["Fiyat"]);
                    isActive = Convert.ToInt32(oku["isActive"]);

                    if (isActive == 1)
                    {
                        SqlCommand komut2 = new SqlCommand("Select * From KullaniciUrun", baglanti.baglanti());
                        SqlDataReader KUoku = komut2.ExecuteReader();

                        while (KUoku.Read())
                        {
                            KUID = Convert.ToInt32(KUoku["Id"]);
                            KUKullaniciID = Convert.ToInt32(KUoku["KullaniciID"]);
                            KUUrunID = Convert.ToInt32(KUoku["UrunID"]);
                            KUMiktarKG = Convert.ToInt32(KUoku["MiktarKG"]);
                            KUFiyat = Convert.ToInt32(KUoku["Fiyat"]);

                            if (UrunID == KUUrunID && MiktarKG <= KUMiktarKG && KUFiyat <= Fiyat)
                            {
                                paramiktari = MiktarKG * Fiyat;
                                komisyon = paramiktari / 100;
                                dusulecekpara = komisyon + paramiktari;

                                SaticiyaParasiniOdeme(paramiktari, KUKullaniciID);
                                KullanicidanIslemUcretiAl(Login.ParaMik - dusulecekpara);
                                MuhasebeKomisyonOde(paramiktari);
                                SatilanUrunleriDus(KUID, KUMiktarKG - MiktarKG);
                                TalepAktiflikYonet(TalepID);
                                SatinAlmaKayit(UrunID, MiktarKG, Fiyat, komisyon);

                                ParaLabel.Text = Convert.ToString(Convert.ToInt32(ParaLabel.Text) - dusulecekpara);

                                if (KullaniciID == Login.UserId)
                                {
                                    MessageBox.Show("Talep Ettiginiz Urun Sisteme An Itıbariyle Eklendi. Isleminiz Otomatik Olarak Gerçekleştirildi. Iyi Gunler Dileriz.");
                                }
                            }
                        }
                        KUoku.Close();
                        baglanti.baglanti().Close();
                    }
                }
                oku.Close();
                SqlConnection.ClearPool(baglanti.baglanti());
                baglanti.baglanti().Close();
                Thread.Sleep(5000);
            }
        }
    }
}