using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    /// <summary>
    /// Classe représantant un chef de cuisine qui hérite de Salarie
    /// </summary>
    class SalarieChefCuisine : Salarie
    {
        /// <summary>
        /// Ce constructeur va prendre les même paramètre que le constructeur de la classe <see cref="Formule"/>Salarie</see>
        /// </summary>
        public SalarieChefCuisine () : base(150){}

        public SalarieChefCuisine(int numero, int ressource) : base(numero, ressource) { }


        /// <summary>
        /// Cette fonction va afficher les informations d'un chef cuisine
        /// </summary>
        /// <returns>Chaîne caractérisant un chef cuisine</returns>
        public override string ToString()
        {
            string ch = "";
            ch += "L'employé est un chef cuisinier "+base.ToString();
            return ch;
        }
    }
}
