using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleNormale : Formule
    {
        public FormuleNormale(String nomFormule, DateTime dureePresence, DateTime dureePreparation, double prix, int ressource) : base(nomFormule, dureePresence, dureePreparation, prix, ressource) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule normale:" + base.ToString();
            return ch;
        }
    }
}
