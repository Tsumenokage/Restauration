using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    abstract class Formule
    {
        public String _nomFormule { get; protected set; }
        public int _numFormule { get; protected set; } //numéro de la formule
        protected static int _numTotale;
        protected DateTime _dureePresence { get; set; }
        protected DateTime _dureePreparation { get; set; }
        protected double _prix { get; set; }
        protected int _ressource { get; set; }
        public Formule(String nomFormule, DateTime dureePresence, DateTime dureePreparation, double prix, int ressource)
        {
            _numFormule = _numTotale + 1;
            _numTotale++;
            _nomFormule = nomFormule;
            _dureePresence = dureePresence;
            _dureePreparation = dureePreparation;
            _prix = prix;
            _ressource = ressource;
        }
        public override string ToString()
        {
            string ch = "";
            ch += "    Numéro : "+ _numFormule +"     Présence:" + _dureePresence.TimeOfDay + "     temps de préparation:" + _dureePreparation.TimeOfDay + "     Prix:" + _prix +"euros";
            return ch;
        }
    }
}
