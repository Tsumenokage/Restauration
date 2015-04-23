using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class Salarie
    {
        protected int _ressource { get; set; }
        public Salarie (int ressource)
        {
            _ressource = ressource;
        }
        public override string ToString()
        {
            string ch = "";
            ch += "utilise "+ _ressource +" ressources";
            return ch;
        }
    }
}
