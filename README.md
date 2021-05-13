## SWAP
 C# İle Tarım İle Elde Edilen Ürünlerin Genel Pazar İçerisinde Teklif Üzerine Satış Platformu Projesi

Gerçekleştirilmesi İstenilen 4 User Story
* User Story-1
  a. Sisteme Kayıt (Kullanıcılar aşağıdaki bilgileri yazılıma girerek sisteme kayıt olacaklardır.)
  b. (Kullanıcı Bilgilerinin sisteme eklenmesi [Ad, Soyad, Kullanıcı Adı, Password, TC Kimlik No, Telefon, Email, Adres] )
* User Story-2
  c. Satıcının sahip oldukları ürünleri Admin onayı ile sisteme eklemesi (ürün tipleri [buğday,arpa,yulaf,petrol,pamuk,…] ve miktar (100 kg, 50 kg,vb) bilgilerinin sisteme eklenmesi.)
* User Story-3
  d. Alıcının sahip olduğu paranın Admin onayı ile sisteme eklenmesi (para tipi TL)
* User Story-4
  e. Fiyatın oluşması ile alıcının hesabına parasının olması ve satıcının hesabına ise ürünün olması lazım. Eğer alıcının almak istediği ürün var ise otomatik olarak alım işleminin gerçekleşmesi lazım.


#Yazılımın Bulundurduğu Ekranlar
1>Login 2>Kayıt Ol 3>Ana Menü 4>Admin

* 1> Login
  Login içerisinden Kullanıcı Adı, Şifre, Kullanıcı Tipi(Admin, Kullanıcı) bilgilerinin kontrolü gerçekleştirilir. Bunun doğrultusunda form geçişi sağlanır. Bunun yanı sıra "Giriş Yap" butonunun altında "Kayıt Ol" butonu yer almaktadır.
* 2> Kayıt Ol
  Kayıt olma ekranı içerisinde genel kullanıcı bilgileri alınarak sisteme eklenir. Bilgiler de herhangi bir şekilde "Null" değer girilemez.
* 3> Ana Menü
  Genel anlamda ilk gelişinde "Bakiye" bilgisi sol yanda yer alır,bunun yanı sıra  Hesap, Ürün Satın Al butonları da bu kısımda yer alır.
  Seçilen işleme göre bileşenlerin görünürlüğü değişmektedir. "Hesap" butonuna tıklandığında sisteme onay başvuruları ile ilgili bileşenler görünürlük kazanır. Ve yapılabilecek olan "Para Ekle" ve "Ürün Ekle" başvuruları yapılabilir.
  "Ürün Satın Al" butonu ile ise ürün seçimine göre genel ürün fiyatlarını görüntüleyebileceğimiz ve ayrıca altında satın alma işlemi gerçekleştirebileceğimiz bir ekran bizleri karşılar.
* 4> Admin
  Onay başvurusu yapılan değerler ve kullanıcıların verileri tablo aracılığıyla görüntülenir. Alttaki tablolar yardımı ile istenirse kullanıcıların ürünleri ve para miktarları değiştirilebilir.
  
  Yararlanılan Kaynaklar:<br/>
  Murat Yücedağ C# Eğitim Kitabı<br/>
  Murat Yücedağ SQL Ders Videoları >> https://www.youtube.com/playlist?list=PLKnjBHu2xXNP6Qa6u8GLawPnzo1brHZPP<br/>
  Temel SQL Komutları >> http://www.oguzhantas.com/sql-server/295-sql-nedir-temel-sql-komutlari-nelerdir.html<br/>
                      >> https://www.bilgigunlugum.net/dbase/sql/sql_komut<br/>
  Önceden Yapmış Olduğum Satış Projem >> https://github.com/KaganCanSit/MarketManagementSoftware-FirstTry<br/>
  
