using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class TableRectangulaire : Table
    {
        public TableRectangulaire(int nbPlacesMin, int nbPlacesMax, string jumelage) : base(nbPlacesMin, nbPlacesMax, jumelage)
        {
        }
    }
}
