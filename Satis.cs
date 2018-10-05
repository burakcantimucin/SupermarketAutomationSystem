using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class Satis
    {
        public Terminal Terminal { get; set; }
        public Musteri Musteri { get; set; }
        public Odeme Odeme { get; set; }
        public DateTime Tarih { get; set; }
        public SatisKalemi SatisKalemi { get; set; }
        private List<UrunTanimi> SatisListe { get; set; }

        private decimal tutar;

        public decimal Tutar
        {
            get
            {
                TutarHesapla(SatisKalemi.Miktar, SatisKalemi.UrunTanimi.Fiyat);
                return tutar;
            }
        }

        public Satis()
        {
            this.Terminal = new Terminal();
            this.Musteri = new Musteri();
            this.SatisKalemi = new SatisKalemi();
            this.SatisListe = new List<UrunTanimi>();
        }

        public void SatilanUrunuEkle(UrunTanimi ut)
        {
            SatisListe.Add(ut);
        }

        public decimal TutarHesapla(int miktar, decimal fiyat)
        {
            this.SatisKalemi.Miktar = miktar;
            this.SatisKalemi.UrunTanimi.Fiyat = fiyat;
            tutar = this.SatisKalemi.Miktar * this.SatisKalemi.UrunTanimi.Fiyat;
            return tutar;
        }
    }
}
