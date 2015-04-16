using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    // création de la class table rectangulaire qui hérite de la class table
    class TableRectangulaire : Table
    {
        public TableRectangulaire(int nbPlacesMin, int nbPlacesMax, string jumelage)
            : base(nbPlacesMin, nbPlacesMax, jumelage)//appel au constructeur de la classe Table
        {
        }
        public override string ToString()
        {
            string ch = "";
            ch += "Table rectangulaire :" + base.ToString();
            return ch;
        }
    }
}
