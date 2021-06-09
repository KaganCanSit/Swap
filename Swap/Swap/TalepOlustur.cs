using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap
{
    class TalepOlustur
    {
        public int TalepID { get; set; }
        public int KullaniciID { get; set; }
        public int UrunID { get; set; }
        public int MiktarKG { get; set; }
        public int Fiyat { get; set; }
        public int isActive { get; set; }

        public TalepOlustur()
        {

        }
        public TalepOlustur(int TalepID, int KullaniciID, int UrunID, int MiktarKg, int Fiyat,int isActive)
        {
            this.TalepID = TalepID;
            this.KullaniciID = KullaniciID;
            this.UrunID = UrunID;
            this.MiktarKG = MiktarKg;
            this.Fiyat = Fiyat;
            this.isActive = isActive;
        }
    }
}
