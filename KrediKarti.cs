using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class KrediKarti : Odeme
    {
        public short TaksitSayisi { get; set; }

        public override void Ode()
        {
            base.Ode();
            OdemeTutari = ToplamTutar / TaksitSayisi;
        }
    }
}
