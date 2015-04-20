using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration_Form
{
    class FormuleConsommation : Formule
    {
        public FormuleConsommation(String nomFormule, double dureePresence, double dureePreparation, double prix) : base(nomFormule, dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule consommation :" + base.ToString();
            return ch;
        }
    }
}
