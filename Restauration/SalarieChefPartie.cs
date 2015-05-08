using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class SalarieChefPartie : Salarie
    {
        public SalarieChefPartie () : base(100){}

        public SalarieChefPartie(int numero, int ressource) : base(numero, ressource) { }

        public override string ToString()
        {
            string ch = "";
            ch += "L'employé est un chef de partie "+base.ToString();
            return ch;
        }
    }
}
