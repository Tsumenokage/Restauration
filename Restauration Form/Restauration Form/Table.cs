using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration_Form
{
    // création de la classe abstraite table
    abstract class Table
    {
        //champs nécessaires à la création d'une classe table
        protected int _numTable { get; set; } //numéro de la table
        protected int _nbPlacesMax { get; set; } //nombre de place maximum de la table
        protected bool _jumelage { get; set; } //O ou N en fonction de si la table peut être jumelée ou non
        public Table(int numTable, int nbPlaceMax, bool jumelage)//contructeur de la classe table
        {
            _numTable = numTable;
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
