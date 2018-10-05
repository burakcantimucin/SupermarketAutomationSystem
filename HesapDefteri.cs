using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class HesapDefteri
    {
        public Satis Satis { get; set; }
        public List<Satis> HasilatListe { get; set; }
        public decimal ToplamHasilat { get; set; }

        public decimal ToplamHasilatHesapla(decimal alisverisTutari)
        {
            ToplamHasilat += alisverisTutari;
            return ToplamHasilat;
        }
    }
}
