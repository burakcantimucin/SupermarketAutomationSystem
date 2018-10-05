using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class UrunKatalogu
    {
        private List<UrunTanimi> UrunListe { get; set; }
        public List<Dukkan> DukkanListe { get; set; }
        public UrunKatalogu()
        {
            this.UrunListe = new List<UrunTanimi>();
        }


    }
}
