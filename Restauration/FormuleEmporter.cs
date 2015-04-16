using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class FormuleEmporter
    {
        public FormuleEmporter(double dureePresence, double dureePreparation, double prix) : base(dureePresence, dureePreparation, prix) { }
        public override string ToString()
        {
            string ch = "";
            ch += "Formule à emporter :" + base.ToString();
            return ch;
        }
    }
}
