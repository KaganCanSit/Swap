using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

/*  
 *  SqlBaglantisi sınıfı oluşturduk. Bu sınıfın içine bir tane bağlanti metodu tanımladık. Amacımız bu sınıf üzerinden nesneler oluşturarak.
 *   Bağlantı  adreslerini hafızaya alabilmek.
*/

namespace Swap
{
    class SQLBaglantisi
    {
        //Metodumuzun public tanımlanmasının nedeni tüm uygulama üzerinde sorunsuz kısıtlama olmadan erişebilmek.
        /*
         * Metoda dair:
         * SqlBaglantisi = Sınıfımızın Adı
         * Metomuzun Adı = Metodumuzun Adı
         * Baglan = Metodumuz aracılığı ile ulaşacağımız SQL bağlantılı nesnemizin adı
         */
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-A47I2NU\KAGANCANSIT;Initial Catalog = Swap; Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
