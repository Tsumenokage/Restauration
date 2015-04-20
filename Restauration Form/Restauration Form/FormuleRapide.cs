using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration_Form
{
    class FormuleRapide : Formule
    {
        public FormuleRapide(String nomFormule, double dureePresence, double dureePreparation, double prix) : base(nomFormule, dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule rapide :" + base.ToString();
            return ch;
        }
    }
}
