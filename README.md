# SWAP - *C# ve SQL İle Tarım İle Elde Edilen Ürünlerin Genel Pazar İçerisinde Teklif Üzerine Satış Platformu Projesi*

*Aşama 1 >> Gerçekleştirilmesi İstenilen 4 User Story*
* User Story-1
  a. Sisteme Kayıt (Kullanıcılar aşağıdaki bilgileri yazılıma girerek sisteme kayıt olacaklardır.)
  b. (Kullanıcı Bilgilerinin sisteme eklenmesi [Ad, Soyad, Kullanıcı Adı, Password, TC Kimlik No, Telefon, Email, Adres] )
* User Story-2
  c. Satıcının sahip oldukları ürünleri Admin onayı ile sisteme eklemesi (ürün tipleri [buğday,arpa,yulaf,petrol,pamuk,…] ve miktar (100 kg, 50 kg,vb) bilgilerinin sisteme eklenmesi.)
* User Story-3
  d. Alıcının sahip olduğu paranın Admin onayı ile sisteme eklenmesi (para tipi TL)
* User Story-4
  e. Fiyatın oluşması ile alıcının hesabına parasının olması ve satıcının hesabına ise ürünün olması lazım. Eğer alıcının almak istediği ürün var ise otomatik olarak alım işleminin gerçekleşmesi lazım.
<br/>
*Aşama 2 >> Gerçekleştirilmesi İstenilen 4 User Story*
* User Story-1
  a. Alıcı bir fiyat belirleyebilecek eğer istediği fiyattan satan kişi olmaz ise işlem gerçekleşmeyecek. İşlem ancak alıcının verdiği fiyattan ürün satan bir kişi olana kadar bekleyecek.)
* User Story-2
  b.Kullanıcı seçtiği tarih aralığında yaptığı alış ve/veya satışlara ilişkin bir rapor oluşturabilecek (Oluşturulan rapor [.csv yada .xlsx yada .dat yada.pdf] uzantılı bir formatta dönüştürülecek.)
* User Story-3
  c.(Alıcı sisteme sadece TL değil farklı para tiplerinden de yükleme yapabilecek. Yüklenen bu tutar adminin onay verdiği tarihteki döviz kuru üzerinden Tl’ye çevrilerek sisteme aktarılacak.) 
  (.Json/.Xml/vb bir yerden veri seçilebilir.) En az 3 para birimi sistem tarafından kabul edilsin (Örnek sterlin, İsviçre frank, Euro).
* User Story-4
  d.Muhasebe_kullanıcısı aracılık ücreti yüzde 1 olsun ve bu tutar alıcıdan tahsil edilsin.

*#Yazılımın Bulundurduğu Ekranlar<br/>*
1>Login<br/> 2>Kayıt Ol<br/> 3>Ana Menü<br/> 4>Admin<br/>

* 1> Login<br/>
  Login içerisinden Kullanıcı Adı, Şifre, Kullanıcı Tipi(Admin, Kullanıcı) bilgilerinin kontrolü gerçekleştirilir. Bunun doğrultusunda form geçişi sağlanır. <br/>
  Bunun yanı sıra "Giriş Yap" butonunun altında "Kayıt Ol" butonu yer almaktadır.<br/>
* 2> Kayıt Ol<br/>
  Kayıt olma ekranı içerisinde genel kullanıcı bilgileri alınarak sisteme eklenir. Bilgiler de herhangi bir şekilde "Null" değer girilemez.<br/>
* 3> Ana Menü<br/>
  Genel anlamda ilk gelişinde "Bakiye" bilgisi sol yanda yer alır,bunun yanı sıra  Hesap, Ürün Satın Al butonları da bu kısımda yer alır.<br/>
  Seçilen işleme göre bileşenlerin görünürlüğü değişmektedir. "Hesap" butonuna tıklandığında sisteme onay başvuruları ile ilgili bileşenler görünürlük kazanır. <br/>
  Ve yapılabilecek olan "Para Ekle" ve "Ürün Ekle" başvuruları yapılabilir.<br/>
  "Ürün Satın Al" butonu ile ise ürün seçimine göre genel ürün fiyatlarını görüntüleyebileceğimiz ve ayrıca altında satın alma işlemi gerçekleştirebileceğimiz bir ekran bizleri karşılar.<br/>
* 4> Admin<br/>
  Onay başvurusu yapılan değerler ve kullanıcıların verileri tablo aracılığıyla görüntülenir. Alttaki tablolar yardımı ile istenirse kullanıcıların ürünleri ve para miktarları değiştirilebilir.<br/>
  
  *Yararlanılan Kaynaklar:<br/>*
  *Yararlanılan Aşama 1 Kaynaklar:<br/>*
  Murat Yücedağ C# Eğitim Kitabı<br/>
  Murat Yücedağ SQL Ders Videoları >> https://www.youtube.com/playlist?list=PLKnjBHu2xXNP6Qa6u8GLawPnzo1brHZPP<br/>
  Temel SQL Komutları >> http://www.oguzhantas.com/sql-server/295-sql-nedir-temel-sql-komutlari-nelerdir.html<br/>
                      >> https://www.bilgigunlugum.net/dbase/sql/sql_komut<br/>
  Önceden Yapmış Olduğum Satış Projem >> https://github.com/KaganCanSit/MarketManagementSoftware-FirstTry<br/><br/>
  *Yararlanılan Aşama 2 Kaynaklar:<br/>*
  >> https://www.yazilimkodlama.com/programlama/c-verilen-iki-tarih-arasindaki-kayitlari-datagridview-de-goruntuleme/<br/>
  >> https://caylakyazilimci.com/post/tarih-ve-saat-islemleri<br/>
  >> https://mustafabukulmez.com/2018/08/30/sql-where-komutu-sartli-veri-listeleme/<br/>
  >> https://www.frmtr.com/c-/4273270-sqlden-veri-cekip-onu-bir-degiskene-atama.html <br/>
  >> https://www.mustafabugra.com/development/veritabanindan-veri-cekmek-ve-formatli-bicimde-yazdirmak/<br/>
  >> https://www.yazilimkodlama.com/sql-server-2/sql-birden-fazla-kosula-gore-sorgulama-and-or-kullanimi/<br/>
  >> https://www.yazilimkodlama.com/programlama/c-sleep-komutu-ile-bekleme-yapma/<br/>
  >> https://www.furkanpezek.com.tr/2017/09/sql-yedek-alma-geri-yukleme/<br/>
  >> https://social.msdn.microsoft.com/Forums/tr-TR/2db3d002-22f2-458d-a695-65b60ea1e3ea/c-sqlden-birok-verileri-deikene-atamak?forum=csharptr<br/>
  >> https://social.msdn.microsoft.com/Forums/tr-TR/ad1a7d02-9b5a-4265-ab03-cbb626677269/sql-2-tarih-arasi-sorgu?forum=sqlservertr<br/>
  >> http://www.omercebi.com/IcerikDetay-cSharp-ile-pdf-dosyasi-olusturmak-(creating-pdf-with-cSharp-)-107.aspx<br/>