using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    /// <summary>
    /// Classe représantant une formule à emporter qui hérite de Formule
    /// </summary>
    class FormuleEmporter : Formule
    {
        /// <summary>
        /// Ce constructeur va prendre les même paramètre que le constructeur de la classe <see cref="Formule"/>Formule</see>
        /// </summary>
        public FormuleEmporter(String nomFormule, DateTime dureePresence, DateTime dureePreparation, double prix, int ressource) : base(nomFormule, dureePresence, dureePreparation, prix, ressource) { }

        /// <summary>
        /// Fonction surchargée s'occupant de l'affichage d'une formule
        /// </summary>
        /// <returns>Une chaîne de caractère décrivant la formule</returns>
        public override string ToString()
        {
            string ch = "";
            ch += "Formule à emporter :" + base.ToString();
            return ch;
        }
    }
}
