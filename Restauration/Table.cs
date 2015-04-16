using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    abstract class Table
    {
        protected static int _numTableTotal = 0;
        protected int _numTable;
        protected int _nbPlacesMin;
        protected int _nbPlacesMax;
        protected string _jumelage;
        public Table(int nbPlaceMin, int nbPlaceMax, string jumelage)
        {
            _numTableTotal++;
            _numTable = _numTableTotal;
            _nbPlacesMin = nbPlaceMin;
            _nbPlacesMax = nbPlaceMax;
            _jumelage = jumelage;
        }
        abstract public int getnbPlaces();
        abstract public int getnumTable();
    }
}
