using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class SalarieChefCuisine : Salarie
    {
        public SalarieChefCuisine () : base(150){}

        public SalarieChefCuisine(int numero, int ressource) : base(numero, ressource) { }

        public override string ToString()
        {
            string ch = "";
            ch += "L'employé est un chef cuisinier "+base.ToString();
            return ch;
        }
    }
}
