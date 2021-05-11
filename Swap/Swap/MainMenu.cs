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
        

        //Görünebilirlik Ayarı
        private void HesapButton_Click(object sender, EventArgs e)
        {
            MoneyGB.Visible = true;
            UrunEkleGB.Visible = true;
            BilgiLabel.Visible = true;
            FinanceGroupBox.Visible = false;
            BuyProductGroupBox.Visible = false;
        }
        private void BuyButton_Click(object sender, EventArgs e)
        {
            FinanceGroupBox.Visible = true;
            BuyProductGroupBox.Visible = true;
            MoneyGB.Visible = false;
            UrunEkleGB.Visible = false;
            BilgiLabel.Visible = false;
            
        }

        SQLBaglantisi baglanti = new SQLBaglantisi();

        //Hesap >> Para Ekleme Onay Başvurusu
        private void ParaEkleButton_Click(object sender, EventArgs e)
        {
            //Değerlerin Boş Girilmesi Durumunda Uyarı Vermesini Sağlıyoruz.
            if (ParaEkleTB.Text == "")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into ParaOnay(KullaniciID, ParaMiktari)" + "values(@p0, @p1)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p0", Login.UserId);
                komut.Parameters.AddWithValue("@p1", ParaEkleTB.Text);
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
        
        private void SatinAlButton_Click(object sender, EventArgs e)
        {
            int UrunId = Convert.ToInt32(UrunSecimiComboBox.Text);
            double Miktar = Convert.ToDouble(UrunMiktariTextBox.Text);
            double Para = Convert.ToDouble(ParaLabel.Text);

        

            Dictionary<int, double> Urunler = ProductList(UrunId);
            string sonuc = "";
            double tutar= 0;
            foreach (var item in Urunler)
            {
                if (Miktar >= item.Value)
                {
                    tutar = (Convert.ToDouble(item.Value.ToString()) *Convert.ToDouble(item.Key.ToString()));
                    Console.WriteLine(item.Value.ToString());
                    Console.WriteLine(item.Key.ToString());
                    Console.WriteLine(tutar.ToString());
                    if (Para >= tutar)
                    {
                        Para -= tutar;
                        Miktar -= item.Value;
                        sonuc += item.Key.ToString() + ',';
                    }
                    else
                    {
                        MessageBox.Show("Yeteri kadar paranız yoktur.");
                    }

                }
                
            }


            //if (Miktar == 0) MessageBox.Show("Tüm ürünler Alındı. Idleri:" + sonuc.ToString());
            //else if (Miktar > 0) MessageBox.Show("Yeteri kadar ürünümüz yoktur.Eksik ürün sayısı :"+Miktar.ToString());
            //DialogResult dialogResult = new DialogResult();
            //dialogResult = MessageBox.Show("Yine de ürünleri satın almak istiyor musunuz?", "Yetersiz Ürün Miktarı", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    MessageBox.Show("Tüm ürünler Alındı. Idleri:" + sonuc.ToString());
            //}

            
        }

        private Dictionary<int,double> ProductList(int UrunId) {
            Dictionary<int, double> Urunler = new Dictionary<int, double>();
            SqlCommand komut = new SqlCommand("SELECT   Id, MiktarKG From KullaniciUrun Where UrunID=@p1 order by Fiyat ", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", UrunId);

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
                Urunler.Add(int.Parse(dr[0].ToString()), double.Parse(dr[1].ToString()));
            dr.Close();
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            return Urunler;
        }
        
    }
}
