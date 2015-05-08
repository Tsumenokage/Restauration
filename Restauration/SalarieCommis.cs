﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class SalarieCommis : Salarie
    {
        public SalarieCommis () : base(50){}

        public SalarieCommis(int numero, int ressource) : base(numero, ressource) { }


        public override string ToString()
        {
            string ch = "";
            ch += "L'employé est un commis "+base.ToString();
            return ch;
        }
    }
}
