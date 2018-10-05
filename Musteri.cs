using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class Musteri : Kisi
    {
        public int KacinciMusteri { get; set; }
        public int AldigiUrunMiktari { get; set; }
        public decimal OdedigiUcret { get; set; }
        public string OdemeTuru { get; set; }
        public List<Musteri> MusteriListe { get; set; }
        public Musteri()
        {
            this.MusteriListe = new List<Musteri>();
        }

        public Musteri(int KacinciMusteri, string Ad, string Soyad, string TCKimlikNo, string TelefonNo, string Adres, int AldigiUrunMiktari, decimal OdedigiUcret, string OdemeTuru)
        {
            this.KacinciMusteri = KacinciMusteri;
            this.Ad = Ad;
            this.Soyad = Soyad;
            this.TCKimlikNo = TCKimlikNo;
            this.Adres = Adres;
            this.TelefonNo = TelefonNo;
            this.AldigiUrunMiktari = AldigiUrunMiktari;
            this.OdedigiUcret = OdedigiUcret;
            this.OdemeTuru = OdemeTuru;
        }
        public void MusteriEkle(Musteri m)
        {
            MusteriListe.Add(m);
        }
    }
}
