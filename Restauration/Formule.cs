using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Restauration
{
    /// <summary>
    /// Classe abstraite dont vont hériter les différentes classes qui correspondront aux formules de notre restaurant.
    /// </summary>
    abstract class Formule
    {
        public String _nomFormule { get; protected set; }
        public int _numFormule { get; protected set; } //numéro de la formule
        protected static int _numTotale;
        public DateTime _dureePresence { get; protected set; }
        public DateTime _dureePreparation { get; protected set; }
        protected double _prix { get; set; }
        public int _ressource { get; protected set; }

        /// <summary>
        /// Constructeur de la classe formule
        /// </summary>
        /// <param name="nomFormule">Nom de la formule</param>
        /// <param name="dureePresence">Durée de présence nécessaire pour la totalité du repas
        /// en incluant le temps de préparation</param>
        /// <param name="dureePreparation">Temps nécessaire à la réalisation du menu en cuisine</param>
        /// <param name="prix">Prix du menu</param>
        /// <param name="ressource">Ressource nécessaire afin de préparer le menu en cuisine</param>
        public Formule(String nomFormule, DateTime dureePresence, DateTime dureePreparation, double prix, int ressource)
        {
            _numFormule = _numTotale + 1;
            _numTotale++;
            _nomFormule = nomFormule;
            _dureePresence = dureePresence;
            _dureePreparation = dureePreparation;
            _prix = prix;
            _ressource = ressource;
        }
        
        /// <summary>
        /// Fonction surchargée s'occupant de l'affichage d'une formule
        /// </summary>
        /// <returns>Une chaîne de caractère décrivant la formule</returns>
        public override string ToString()
        {
            string ch = "";
            ch += "    Numéro : "+ _numFormule +"     Présence:" + _dureePresence.TimeOfDay + "     temps de préparation:" + _dureePreparation.TimeOfDay + "     Prix:" + _prix +"euros";
            return ch;
        }

        /// <summary>
        /// Cette fonction va permettre d'enregistrer dans un XmlDocument les différents Noeud Xml qui caractériseront un menu
        /// ainsi que la valeur de ces noeuds
        /// </summary>
        /// <param name="saveRestau">Un XmlDocument qui représente le document Xml qui sera sauvegardé</param>
        /// <param name="listeFormules">Un XmlNode représentant une listes de formules dans notre fichiers Xml</param>
        public void sauvegardeFormule(XmlDocument saveRestau, XmlNode listeFormules)
        {
            //On crée un noeud racine qui correspondra à une formule
            XmlNode rootFormule = saveRestau.CreateElement("formule");
            //On définie un attribut permettant de distinguer le type de formule
            XmlAttribute typeFormule = saveRestau.CreateAttribute("typeFormule");
            typeFormule.Value = this.GetType().ToString();
            rootFormule.Attributes.Append(typeFormule);

            //On enregistre les différentes informations de la formule dans le noeud racine
            XmlNode numFormule = saveRestau.CreateElement("numeroFormule");
            XmlNode nomFormule = saveRestau.CreateElement("nomFormule");
            XmlNode dureePresence = saveRestau.CreateElement("dureePresence");
            XmlNode dureePreparation = saveRestau.CreateElement("dureePreparation");
            XmlNode prix = saveRestau.CreateElement("prix");
            XmlNode ressource = saveRestau.CreateElement("ressource");

            //On indique les différentes valeurs de chaque Noeud
            numFormule.InnerText = this._numFormule.ToString(); ;
            nomFormule.InnerText = this._nomFormule;
            dureePresence.InnerText = this._dureePresence.ToShortTimeString();
            dureePreparation.InnerText = this._dureePreparation.ToShortTimeString();
            prix.InnerText = this._prix.ToString();
            ressource.InnerText = this._ressource.ToString();

            //On ajoute chacun de ces noeuds au noeud formule
            rootFormule.AppendChild(numFormule);
            rootFormule.AppendChild(nomFormule);
            rootFormule.AppendChild(dureePresence);
            rootFormule.AppendChild(dureePreparation);
            rootFormule.AppendChild(prix);
            rootFormule.AppendChild(ressource);




            //On ajoute ce nouveau noeud au noeud qui contiendra la liste des formules
            listeFormules.AppendChild(rootFormule);
        }

    }
}
