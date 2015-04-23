using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleGastronomique : Formule
    {
        public FormuleGastronomique(String nomFormule, DateTime dureePresence, DateTime dureePreparation, double prix, int ressource) : base(nomFormule, dureePresence, dureePreparation, prix, ressource) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule gastronomique :" + base.ToString();
            return ch;
        }
    }
}
    