using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class KasaGorevlisi : Kisi
    {
        public List<KasaGorevlisi> KasiyerListe { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }

        public KasaGorevlisi()
        {
            this.KasiyerListe = new List<KasaGorevlisi>();
        }

        public KasaGorevlisi(string Ad, string Soyad, string TCKimlikNo, string TelefonNo, string Adres, string KullaniciAdi, string Parola)
        {
            this.Ad = Ad;
            this.Soyad = Soyad;
            this.TCKimlikNo = TCKimlikNo;
            this.Adres = Adres;
            this.TelefonNo = TelefonNo;
            this.KullaniciAdi = KullaniciAdi;
            this.Parola = Parola;
        }
        public void KasiyerEkle(KasaGorevlisi kg)
        {
            KasiyerListe.Add(kg);
        }
    }
}
