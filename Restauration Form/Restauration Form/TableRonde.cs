using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration_Form
{
    // création de la class table ronde qui hérite de la class table
    class TableRonde : Table
    {
        public TableRonde(int numTable, int nbPlacesMax, bool jumelage) 
            : base(numTable, nbPlacesMax, jumelage)//appel au constructeur de la classe Table
        {
        }
        public override string ToString()
        {
            string ch = "";
            ch += "Table ronde :" + base.ToString();
            return ch;
        }
    }
}
