using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Restauration
{

    /// <summary>
    /// Classe abstraite dont vont hériter les différentes classes qui correspondront aux salariés de notre restaurant.
    /// </summary>
    class Salarie
    {
        public int _numSalarie { get; protected set; } //numéro de la formule
        protected static int _numTotale;
        public int _ressource { get; protected set; }

        /// <summary>
        /// Constructeur de salarié
        /// </summary>
        /// <param name="ressource">Les ressource en cuisine du salarié</param>
        public Salarie (int ressource)
        {
            _numSalarie = _numTotale + 1;
            _numTotale++;
            _ressource = ressource;
        }

        /// <summary>
        /// Constructeur de salarié essentiellement utilisé dans le chargement
        /// </summary>
        public Salarie(int numero, int ressource)
        {
            _numSalarie = numero;
            _numTotale++;
            _ressource = ressource;
        }

        /// <summary>
        /// Cette fonction va afficher les informations d'un salarié
        /// </summary>
        /// <returns>Chaîne caractérisant un salarié</returns>
        public override string ToString()
        {
            string ch = "";
            ch += "utilise "+ _ressource +" ressources";
            return ch;
        }

        /// <summary>
        /// Cette fonction va permettre d'enregistrer dans un XmlDocument les différents Noeud Xml qui caractériseront un salarie
        /// ainsi que la valeur de ces noeuds
        /// </summary>
        /// <param name="saveRestau">Un XmlDocument qui représente le document Xml qui sera sauvegardé</param>
        /// <param name="listeSalaries">Un XmlNode représentant une liste de salariés dans notre fichier Xml</param>
        public void sauvegardeSalarie(XmlDocument saveRestau, XmlNode listeSalaries)
        {
            //On crée un noeud racine qui correspondra à un salarié
            XmlNode rootSalarie = saveRestau.CreateElement("salarie");
            //On définie un attribut permettant de distinguer le type de formule
            XmlAttribute typeSalarie = saveRestau.CreateAttribute("typeSalarie");
            typeSalarie.Value = this.GetType().ToString();
            rootSalarie.Attributes.Append(typeSalarie);

            //On enregistre les différentes informations de la formule dans le noeud racine
            XmlNode numSalarie = saveRestau.CreateElement("numeroSalarie");
            XmlNode ressourceSalarie = saveRestau.CreateElement("ressourceSalarie");

            numSalarie.InnerText = this._numSalarie.ToString(); ;
            ressourceSalarie.InnerText = this._ressource.ToString();

            rootSalarie.AppendChild(numSalarie);
            rootSalarie.AppendChild(ressourceSalarie);

            //On ajoute ce nouveau noeud au noeud qui contiendra la liste des formules
            listeSalaries.AppendChild(rootSalarie);
        }
    }
}
