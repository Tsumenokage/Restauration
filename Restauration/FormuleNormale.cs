using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleNormale : Formule
    {
        public FormuleNormale(double dureePresence, double dureePreparation, double prix) : base(dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule normale:" + base.ToString();
            return ch;
        }
    }
}
