using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap
{
    public class KullaniciUrun
    {
        public KullaniciUrun() { 
        }
        public KullaniciUrun(int Id, int UrunId, double MiktarKG, double Fiyat, int KullaniciId)
        {
            this.Id = Id;
            this.KullaniciId = KullaniciId;
            this.UrunId = UrunId;
            this.MiktarKG = MiktarKG;
            this.Fiyat = Fiyat;
        }

        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int UrunId { get; set; }
        public double MiktarKG { get; set; }
        public double Fiyat { get; set; }
        
    }
}
