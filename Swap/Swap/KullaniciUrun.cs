using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap
{
    public class KullaniciUrun
    {
        //private int Id;
        //private int UrunId;
        //private double MiktarKG ;
        //private double Fiyat ;
        //private int KullaniciId;



        public KullaniciUrun() { 
        }
        public KullaniciUrun(int Id, int UrunId, double MiktarKG, double Fiyat, int KullaniciId)
        {
            this.Id = Id;
            this.UrunId = UrunId;
            this.MiktarKG = MiktarKG;
            this.Fiyat = Fiyat;
            this.KullaniciId = KullaniciId;
        }


        public int Id { get; set; }
        public int UrunId { get; set; }
        public double MiktarKG { get; set; }
        public double Fiyat { get; set; }
        public int KullaniciId { get; set; }
    }
}
