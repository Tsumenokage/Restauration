using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    /// <summary>
    /// Classe représantant une formule Gastronomique qui hérite de Formule
    /// </summary>
    class FormuleGastronomique : Formule
    {        
        /// <summary>
        /// Ce constructeur va prendre les même paramètres que le constructeur de la classe <see cref="Formule"/>Formule</see>
        /// </summary>
        public FormuleGastronomique(String nomFormule, DateTime dureePresence, DateTime dureePreparation, double prix, int ressource) : base(nomFormule, dureePresence, dureePreparation, prix, ressource) { }

        /// <summary>
        /// Fonction surchargée s'occupant de l'affichage d'une formule
        /// </summary>
        /// <returns>Une chaîne de caractère décrivant la formule</returns>
        public override string ToString()
        {
            string ch = "";
            ch += "Formule gastronomique :" + base.ToString();
            return ch;
        }
    }
}
    