﻿using System;
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

        //Oluşturduğumuz Database Sınıfı Aracılığıyla Database'den Veri Alıyoruz.
        SQLBaglantisi baglanti = new SQLBaglantisi();
        SqlCommand komut;

        //Kullanıcının Adı, Soyadı, Kullanıcı Tipi Kontrolü Ve Girişi
        private void LoginButton_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("Select * From Kullanicilar where KullaniciTuru=@p3 and KullaniciAdi=@p4 and Şifre=@p5", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p3", UserTypeComboBox.Text);
            komut.Parameters.AddWithValue("@p4", NameTextBox.Text);
            komut.Parameters.AddWithValue("@p5", PassTextBox.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                //Kullanıcı Girişi Yetkisine Göre İşlem Yapacağı Forma İletiyoruz. 
                if (UserTypeComboBox.Text == "Kullanici")
                {
                    MainMenu MainMenu = new MainMenu();
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
    }
}

