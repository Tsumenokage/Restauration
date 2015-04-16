using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    abstract class Formule
    {
        protected string _type {get; set;}
        protected double _dureePresence { get; set; }
        protected double _dureePreparation { get; set; }
        protected double _prix { get; set; }
        public override string ToString()
        {
            string ch = "";
            ch += "Type:" + _type + "     Présence:" + _dureePresence + "     temps de préparation:" + _dureePreparation + "     Prix:" + _prix;
            return ch;
        }
    }
}
