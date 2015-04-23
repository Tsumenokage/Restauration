using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleRapide : Formule
    {
        public FormuleRapide(String nomFormule, DateTime dureePresence, DateTime dureePreparation, double prix, int ressource) : base(nomFormule, dureePresence, dureePreparation, prix, ressource) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule rapide :" + base.ToString();
            return ch;
        }
    }
}
