﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration_Form
{
    // création de la class table rectangulaire qui hérite de la class table
    class TableRectangulaire : Table
    {
        public TableRectangulaire(int numTable, int nbPlacesMax, bool jumelage)
            : base(numTable, nbPlacesMax, jumelage)//appel au constructeur de la classe Table
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
