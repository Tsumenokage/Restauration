﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    // création de la class table ronde qui hérite de la class table
    class TableRonde : Table
    {
        public TableRonde(int nbPlacesMin, int nbPlacesMax, string jumelage) 
            : base(nbPlacesMin,nbPlacesMax, jumelage)//appel au constructeur de la classe Table
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
