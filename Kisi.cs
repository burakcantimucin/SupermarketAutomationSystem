using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjesi
{
    public abstract class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        protected string TelefonNo { get; set; }
        protected string TCKimlikNo { get; set; }
        protected string Adres { get; set; }
    }
}
