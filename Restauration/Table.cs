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
        protected static int _numTableTotal = 0; //numéro total de table dans le restaurant
        protected int _numTable; //numéro de la table
        protected int _nbPlacesMin; //nombre de place minimum de la table
        protected int _nbPlacesMax; //nombre de place maximum de la table
        protected string _jumelage; //O ou N en fonction de si la table peut être jumelée ou non
        public Table(int nbPlaceMin, int nbPlaceMax, string jumelage)//contructeur de la classe table
        {
            //le numéro de la table est automatiquement attribué
            _numTableTotal++;
            _numTable = _numTableTotal;
            _nbPlacesMin = nbPlaceMin;
            _nbPlacesMax = nbPlaceMax;
            _jumelage = jumelage;
        }
        public int getnbPlacesMin()// permet de récupérer le nombre de place minimum de la table
        {
            return _nbPlacesMin;
        }
        public int getnbPlacesMax()// permet de récupérer le nombre de place maximum de la table
        {
            return _nbPlacesMax;
        }
        public int getnumTable() // permet de récupérer le numéro de la table
        {
            return _numTable;
        }
        public string getJumelage() // permet de savoir si la table est jumelable
        {
            return _jumelage;
        }
        public override string ToString()
        {
            string ch = "";
            ch += "Numero:" + _numTable + "     nbPlaceMax:" + _nbPlacesMax + "     nbPlaceMin:" + _nbPlacesMin + "     Jumelage" + _jumelage;
            return ch;
        }

    }
}
