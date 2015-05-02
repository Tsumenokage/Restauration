using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class Salarie
    {
        public int _numSalarie { get; protected set; } //numéro de la formule
        protected static int _numTotale;
        protected int _ressource { get; set; }
        public Salarie (int ressource)
        {
            _numSalarie = _numTotale + 1;
            _numTotale++;
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
