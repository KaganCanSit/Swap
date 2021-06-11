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
            baglanti.baglanti().Close();
        }

        //Alım Geçmişi Butonu
        private void DateButton_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From AlimKayitTablosu Where Tarih BETWEEN @t1 and @t2 and KullaniciID=" + Login.UserId, baglanti.baglanti());
            SqlDataAdapter data = new SqlDataAdapter(komut);
            //MessageBox.Show(Convert.ToString(StartDatePicker.Value) + " --- " + DateTime.Now.ToLocalTime().ToString());
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
                id=Convert.ToString(oku["KullaniciID"]);
                tarih=Convert.ToString(oku["Tarih"]);
                miktar=Convert.ToString(oku["Miktar"]);
                alimtutar=Convert.ToString(oku["AlimTutari"]);
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
            foreach (var urun in Urunler) {

                 if (Miktar >=  urun.MiktarKG)
                 {
                    if ((Miktar * urun.Fiyat) <= Para)
                    {
                        int uruncarpfiyat = 0;
                        uruncarpfiyat = urun.MiktarKG * urun.Fiyat;
                        Para -= (uruncarpfiyat+(uruncarpfiyat/100));
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
                        Para -= (aradegisken + (aradegisken/100));
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
        private List<KullaniciUrun> ProductList(int UrunId) {
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
        private bool UpdateTable(List<KullaniciUrun> urun,int para)
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

                    //Satıcıdan satın alma işlemi tamamlanma sonrası ürünlerin düşülmesi
                    komut = new SqlCommand("UPDATE KullaniciUrun SET MiktarKG = @p1 WHERE Id = @p2", baglanti.baglanti());
                    komut.Parameters.AddWithValue("@p1", item.MiktarKG);
                    komut.Parameters.AddWithValue("@p2", item.Id);
                    komut.ExecuteNonQuery();
                    baglanti.baglanti().Close();
                    
                    if(item.MiktarKG==0)
                    {
                        //Kullanıcının Satın Alma İşlemini Kayıt Altına Alıyoruz
                        komut = new SqlCommand("insert into AlimKayitTablosu(KullaniciID,Tarih,UrunID,Miktar,AlimTutari,UygulamaKomisyonu)" + "values(@p0,@p1,@p2,@p3,@p4,@p5)", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p0", Login.UserId);
                        komut.Parameters.AddWithValue("@p1", DateTime.Now.ToLocalTime().ToString());
                        komut.Parameters.AddWithValue("@p2", item.UrunId);
                        komut.Parameters.AddWithValue("@p3", IlkMiktar);
                        komut.Parameters.AddWithValue("@p4", item.Fiyat);
                        komut.Parameters.AddWithValue("@p5", ((item.Fiyat * IlkMiktar) / 100));
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();
                    }
                    else if(IlkMiktar-item.MiktarKG!=0 || IlkMiktar-item.MiktarKG>0 || IlkMiktar!=item.MiktarKG)
                    {
                        //Kullanıcının Satın Alma İşlemini Kayıt Altına Alıyoruz
                        komut = new SqlCommand("insert into AlimKayitTablosu(KullaniciID,Tarih,UrunID,Miktar,AlimTutari,UygulamaKomisyonu)" + "values(@p0,@p1,@p2,@p3,@p4,@p5)", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p0", Login.UserId);
                        komut.Parameters.AddWithValue("@p1", DateTime.Now.ToLocalTime().ToString());
                        komut.Parameters.AddWithValue("@p2", item.UrunId);
                        komut.Parameters.AddWithValue("@p3", IlkMiktar-item.MiktarKG);
                        komut.Parameters.AddWithValue("@p4", item.Fiyat);
                        komut.Parameters.AddWithValue("@p5", ((item.Fiyat * (IlkMiktar - item.MiktarKG)) / 100));
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();
                    }
                }

                ///Kullanıcıdan Satın Alma Parasının Düşülmesi
                komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari = @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", para);
                komut.Parameters.AddWithValue("@p2", Login.UserId);
                komut.ExecuteNonQuery();
                ParaLabel.Text = Convert.ToString(para);
                baglanti.baglanti().Close();

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
            SqlCommand komut;
            try
            {
                //Satıcıya Parasının Ödenmesi
                komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", miktar);
                komut.Parameters.AddWithValue("@p2", kullaniciId);
                komut.ExecuteNonQuery();
                baglanti.baglanti().Close();

                //Muhasebe Kullanıcısına %1 Komisyonu İçin Para Ekleme.
                komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1",(miktar / 100));
                komut.Parameters.AddWithValue("@p2", 2);
                komut.ExecuteNonQuery();
                baglanti.baglanti().Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Bir hata oluştu." + e.ToString());
            }
        }

        /*
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Talep İle Satın Alma İşlemleri
        private void TalepOlusturBtn_Click(object sender, EventArgs e)
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
                //Talep Tablosuna Ekle
                SqlCommand komut = new SqlCommand("insert into TalepTablosu(KullaniciID,UrunID,MiktarKG,Fiyat,isActive)" + "values(@p1,@p2,@p3,@p4,@p5)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", Login.UserId);
                komut.Parameters.AddWithValue("@p2", Convert.ToInt32(UrunSecimComboBox.Text));
                komut.Parameters.AddWithValue("@p3", Convert.ToInt32(TalepKGTB.Text));
                komut.Parameters.AddWithValue("@p4", Convert.ToInt32(TalepFiyatTB.Text));
                komut.Parameters.AddWithValue("@p5", 1);
                komut.ExecuteNonQuery();

                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Talebiniz Hakkında Dönüş Sağlayacağız.");
                baglanti.baglanti().Close();
            }
        }

        public void TalepleriOku()
        {
            int TalepID, KullaniciID, UrunID, MiktarKG, Fiyat, isActive;
            int KUID,KUKullaniciID, KUUrunID, KUMiktarKG, KUFiyat;         //Kullanıcı Ürün Tablosu = KU

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

                komut = new SqlCommand("Select * From KullaniciUrun", baglanti.baglanti());
                SqlDataReader KUoku = komut.ExecuteReader();

                while (KUoku.Read())
                {
                    KUID = Convert.ToInt32(KUoku["Id"]);
                    KUKullaniciID = Convert.ToInt32(KUoku["KullaniciID"]);
                    KUUrunID = Convert.ToInt32(KUoku["UrunID"]);
                    KUMiktarKG = Convert.ToInt32(KUoku["MiktarKG"]);
                    KUFiyat = Convert.ToInt32(KUoku["Fiyat"]);

                    if (UrunID == KUUrunID && MiktarKG <= KUMiktarKG && KUFiyat <= Fiyat)
                    {
                        int paramiktari, dusulecekpara, komisyon;

                        paramiktari = MiktarKG * Fiyat;
                        komisyon = paramiktari / 100;
                        dusulecekpara = komisyon + paramiktari;

                        //Satıcıya Kazandığı Paranın Atanması
                        komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p2", KUKullaniciID);
                        komut.Parameters.AddWithValue("@p1", paramiktari);
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();

                        //Satıcının Sahip Olduğu Ürün Adetinin Düşürülmesi
                        komut = new SqlCommand("UPDATE KullaniciUrun SET MiktarKG -= @p1 WHERE Id = @p2", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p2", KUID);
                        komut.Parameters.AddWithValue("@p1", MiktarKG);
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();

                        //Satın Alan Kişiden Paranın Tahsil Edilmesi
                        komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari -= @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p1", dusulecekpara);
                        komut.Parameters.AddWithValue("@p2", KullaniciID);
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();

                        //Muhasebe Kullanıcısına % 1 Komisyonu İçin Para Ekleme.
                        komut = new SqlCommand("UPDATE Kullanicilar SET ParaMiktari += @p1 WHERE KullaniciID = @p2", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p1", komisyon);
                        komut.Parameters.AddWithValue("@p2", 2);
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();

                        //isActive hücresinin 1'den 0'a çekilmesi. Bu sayede başka bir sorguda yeniden kontrol edilmesi önlenmiş olacak.
                        komut = new SqlCommand("UPDATE TalepTablosu SET isActive = @p1 WHERE TalepID = @p2", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p1", 0);
                        komut.Parameters.AddWithValue("@p2", TalepID);
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();

                        ParaLabel.Text = Convert.ToString(Convert.ToInt32(ParaLabel.Text) - dusulecekpara);

                        //Kullanıcının Satın Alma İşlemini Kayıt Altına Alıyoruz
                        komut = new SqlCommand("insert into AlimKayitTablosu(KullaniciID,Tarih,UrunID,Miktar,AlimTutari,UygulamaKomisyonu)" + "values(@p0,@p1,@p2,@p3,@p4,@p5)", baglanti.baglanti());
                        komut.Parameters.AddWithValue("@p0", Login.UserId);
                        komut.Parameters.AddWithValue("@p1", DateTime.Now.ToShortDateString());
                        komut.Parameters.AddWithValue("@p2", UrunID);
                        komut.Parameters.AddWithValue("@p3", MiktarKG);
                        komut.Parameters.AddWithValue("@p4", Fiyat);
                        komut.Parameters.AddWithValue("@p5", komisyon);
                        komut.ExecuteNonQuery();
                        baglanti.baglanti().Close();

                        MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Talebiniz Hakkında Dönüş Sağlayacağız.");

                        if (KullaniciID == Login.UserId)
                        {
                            MessageBox.Show("Talep Ettiginiz Urun Sisteme Eklendi. Isleminiz otomatik olarak gerçekleştirildi.");
                        }
                    }
                }
                KUoku.Close();
                komut.ExecuteNonQuery();
                baglanti.baglanti().Close();
            }
            oku.Close();
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
        }
        */
    }
}