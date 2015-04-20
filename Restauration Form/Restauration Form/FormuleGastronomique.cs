using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration_Form
{
    class FormuleGastronomique : Formule
    {
        public FormuleGastronomique(String nomFormule, double dureePresence, double dureePreparation, double prix) : base(nomFormule, dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule gastronomique :" + base.ToString();
            return ch;
        }
    }
}
