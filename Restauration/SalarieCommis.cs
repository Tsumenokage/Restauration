using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class SalarieCommis : Salarie
    {
        public SalarieCommis (int ressource) : base(ressource){}
        public override string ToString()
        {
            string ch = "";
            ch += "L'employé est un commis "+base.ToString();
            return ch;
        }
    }
}
