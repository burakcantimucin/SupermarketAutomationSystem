using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class SatisKalemi
    {
        public int Miktar { get; set; }
        private List<Urun> UrunListe { get; set; }

        public UrunTanimi UrunTanimi;
        public Urun Urun = new Urun();

        public SatisKalemi()
        { 
            this.UrunTanimi = new UrunTanimi();
            this.Urun.UrunSepetiListe = new List<UrunTanimi>();
            this.Urun.AnlikSatisListe = new List<UrunTanimi>();
        }

        public void SepeteUrunEkle(UrunTanimi ut)
        {
            Urun.UrunSepetiListe.Add(ut);
        }

        public void SepettenUrunCikar(UrunTanimi ut)
        {
            Urun.UrunSepetiListe.Remove(ut);
        }

        public void AnlikSatisGoster(UrunTanimi ut)
        {
            Urun.AnlikSatisListe.Add(ut);
        }
    }
}
