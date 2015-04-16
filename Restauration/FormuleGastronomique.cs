using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleGastronomique
    {
        public FormuleGastronomique(double dureePresence, double dureePreparation, double prix) : base(dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule gastronomique :" + base.ToString();
            return ch;
        }
    }
}
