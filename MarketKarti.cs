using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class MarketKarti : Odeme
    {
        private const decimal IndirimKatsayisi = 0.1M;
        public decimal BonusPuan { get; private set; }
        public override void Ode()
        {
            base.Ode();
            BonusPuan = IndirimKatsayisi * ToplamTutar;
        }
    }
}
