using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class Dukkan
    {
        public Urun Urun = new Urun();
        public HesapDefteri HesapDefteri { get; set; }
        private List<Terminal> TerminalBilgiListe { get; set; }

        public Dukkan()
        {
            this.Urun.UrunListe = new List<UrunTanimi>();
            this.TerminalBilgiListe = new List<Terminal>();
        }
        public void UrunEkle(UrunTanimi ut)
        {
            Urun.UrunListe.Add(ut);
        }

        public void UrunSil(UrunTanimi ut)
        {
            Urun.UrunListe.Remove(ut);
        }
        
        public void TerminalBilgiEkle(Terminal t)
        {
            TerminalBilgiListe.Add(t);
        }

        public string UrunListele()
        {
            string metin = "";
            foreach (UrunTanimi urunListele in Urun.UrunListe)
            {
                metin += "Ürün Kodu: " + urunListele.Kod + Environment.NewLine +
                         "Ürün Kataloğu: " + urunListele.Katalog + Environment.NewLine +
                         "Ürün Alt Kataloğu: " + urunListele.AltKatalog + Environment.NewLine +
                         "Ürün Adı: " + urunListele.Ad + Environment.NewLine +
                         "Ürün Türü: " + urunListele.Tur + Environment.NewLine +
                         "Ürün Adedi: " + urunListele.Adet + Environment.NewLine +
                         "Ürün Fiyatı: " + urunListele.Fiyat + " TL" + Environment.NewLine +
                         "Ürün Açıklaması: " + urunListele.Tanim;
            }
            return metin;
        }

        public string TerminalBilgiListele()
        {
            string metin = "";
            foreach (Terminal terminalListele in TerminalBilgiListe)
            {
                metin += "Satış Yapılan Kasa No: " + terminalListele.SeriNo + Environment.NewLine +
                          "Yapılan Kaçıncı Satış: " + terminalListele.SatisNo;
            }
            return metin;
        }
    }
}
