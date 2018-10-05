using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public abstract class Odeme
    {
        public decimal OdemeTutari { get; set; }
        public decimal ToplamTutar { get; set; }

        public virtual void Ode()
        {
            OdemeTutari = 0;
        }
    }
}
