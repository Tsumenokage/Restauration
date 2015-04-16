using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    abstract class Formule
    {
        protected double _dureePresence { get; set; }
        protected double _dureePreparation { get; set; }
        protected double _prix { get; set; }
        public Formule(double dureePresence, double dureePreparation, double prix)
        {
            _dureePresence = dureePresence;
            _dureePreparation = dureePreparation;
            _prix = prix;
        }
        public override string ToString()
        {
            string ch = "";
            ch += "     Présence:" + _dureePresence + "     temps de préparation:" + _dureePreparation + "     Prix:" + _prix;
            return ch;
        }
    }
}
