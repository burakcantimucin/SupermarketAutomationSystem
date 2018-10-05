using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class UrunTanimi
    {
        public int Kod { get; set; }
        public string Katalog { get; set; }
        public string AltKatalog { get; set; }
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Adet { get; set; }
        public string Agirlik { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime AlisTarihi { get; set; }
        public string Tanim { get; set; }

        public UrunTanimi()
        {
            this.Kod = Kod;
            this.Katalog = Katalog;
            this.AltKatalog = AltKatalog;
            this.Ad = Ad;
            this.Tur = Tur;
            this.Adet = Adet;
            this.Agirlik = Agirlik;
            this.Fiyat = Fiyat;
            this.AlisTarihi = AlisTarihi;
            this.Tanim = Tanim;
        }
    }
}
