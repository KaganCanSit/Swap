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

        private void HesapButton_Click(object sender, EventArgs e)
        {
            MoneyGB.Visible = true;
            UrunEkleGB.Visible = true;
            BilgiLabel.Visible = true;
            FinanceGroupBox.Visible = false;
            UrunSatinAlGB.Visible = false;
        }

        SQLBaglantisi baglanti = new SQLBaglantisi();
        private void ParaEkleButton_Click(object sender, EventArgs e)
        {
            //Değerlerin Boş Girilmesi Durumunda Uyarı Vermesini Sağlıyoruz.
            if (ParaEkleTB.Text == "" )
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into ParaOnay(ParaMiktari)" + "values(@p1)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", ParaEkleTB.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Onaylacağız.");
                baglanti.baglanti().Close();
            }
        }

        private void UrunEkleButton_Click(object sender, EventArgs e)
        {
            if (UrunlerCB.Text == "" || UrunMiktariTB.Text == "" || SatisTutariTB.Text == "")
            {
                MessageBox.Show("Değerlerden Birini Veya Birkaçı Boş Bıraktınız. Kontrol Ediniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into UrunOnay(UrunID,Miktar(kg),SatisFiyati)" + "values(@p1,@p2,@p3)", baglanti.baglanti());
                komut.Parameters.AddWithValue("@p1", UrunlerCB.Text);
                komut.Parameters.AddWithValue("@p2", UrunMiktariTB.Text);
                komut.Parameters.AddWithValue("@p3", SatisTutariTB.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("İşleminiz Başarıyla Gerçekleşti. Verdiğiniz Bilgiler İçin Teşekkür Ederiz." + Environment.NewLine + "En Kısa Sürede Onaylacağız.");
                baglanti.baglanti().Close();
            }
        }

        public int urunsecim; 
        void UrunListele()
        {
            SqlCommand komut = new SqlCommand("Select * From KullaniciUrun Where UrunID=" + urunsecim, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FinanceDataGrid.DataSource = dt;
        }

        private void GoruntuleButton_Click(object sender, EventArgs e)
        {
            if(UrunCB.Text== "Armut")
            {
                urunsecim = 1;
                UrunListele();
            }
            else if(UrunCB.Text=="Elma")
            {
                urunsecim = 2;
                UrunListele();
            }
            else if(UrunCB.Text=="Muz")
            {
                urunsecim = 3;
                UrunListele();
            }
            else if(UrunCB.Text== "Çilek")
            {
                urunsecim = 4;
                UrunListele();
            }
            else
            {
                MessageBox.Show("Ürün Seçimini Boş Bıraktınız." + Environment.NewLine + "Yeniden Deneyiniz.");
            }
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            FinanceGroupBox.Visible = true;
            UrunSatinAlGB.Visible = true;
            MoneyGB.Visible = false;
            UrunEkleGB.Visible = false;
            BilgiLabel.Visible = false;
        }

        private void SatinAlBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
