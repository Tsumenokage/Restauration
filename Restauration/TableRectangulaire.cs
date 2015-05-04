using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    // création de la class table rectangulaire qui hérite de la class table
    class TableRectangulaire : Table
    {
        public TableRectangulaire(int nbPlacesMax, bool jumelage)
            : base(nbPlacesMax, jumelage)//appel au constructeur de la classe Table
        {
        }


        public TableRectangulaire(int numTable, int nbPlaceMax, bool jumelage)
            :base(numTable,nbPlaceMax,jumelage)
        { }

        public override string ToString()
        {
            string ch = "";
            ch += "Table rectangulaire :" + base.ToString();
            return ch;
        }
    }
}
