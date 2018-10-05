using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public class Nakit : Odeme
    {
        public override void Ode()
        {
            base.Ode();
            OdemeTutari = ToplamTutar;
        }
    }
}
