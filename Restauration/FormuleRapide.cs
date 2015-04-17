using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleRapide : Formule
    {
        public FormuleRapide(double dureePresence, double dureePreparation, double prix) : base(dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule rapide :" + base.ToString();
            return ch;
        }
    }
}
