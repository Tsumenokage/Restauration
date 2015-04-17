using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleNormale : Formule
    {
        public FormuleNormale(String nomFormule, double dureePresence, double dureePreparation, double prix) : base(nomFormule, dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule normale:" + base.ToString();
            return ch;
        }
    }
}
