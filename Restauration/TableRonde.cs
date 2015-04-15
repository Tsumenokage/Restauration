using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class TableRonde : Table
    {
        public TableRonde(int nbPlacesMin, int nbPlacesMax, string jumelage) : base(nbPlacesMin,nbPlacesMax, jumelage)
        {
        }
    }
}
