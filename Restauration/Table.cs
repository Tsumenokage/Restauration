using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    // création de la classe abstraite table
    abstract class Table
    {
        //champs nécessaires à la création d'une classe table
        public int _numTable { get; protected set; } //numéro de la table
        protected static int _numTotale;
        protected int _nbPlacesMax { get; set; } //nombre de place maximum de la table
        protected bool _jumelage { get; set; } //O ou N en fonction de si la table peut être jumelée ou non
        public Table(int nbPlaceMax, bool jumelage)//contructeur de la classe table
        {
            _numTable = _numTotale + 1;
            _numTotale++;
            _nbPlacesMax = nbPlaceMax;
            _jumelage = jumelage;
        }
        public override string ToString()
        {
            string ch = "";
            ch += "Numero:" + _numTable + "     nbPlaceMax:" + _nbPlacesMax +"     Jumelage:" + _jumelage;
            return ch;
        }

    }
}
