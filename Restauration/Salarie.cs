using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Restauration
{
    class Salarie
    {
        public int _numSalarie { get; protected set; } //numéro de la formule
        protected static int _numTotale;
        protected int _ressource { get; set; }
        public Salarie (int ressource)
        {
            _numSalarie = _numTotale + 1;
            _numTotale++;
            _ressource = ressource;
        }
        public override string ToString()
        {
            string ch = "";
            ch += "utilise "+ _ressource +" ressources";
            return ch;
        }
        public void sauvegardeSalarie(XmlDocument saveRestau, XmlNode listeSalaries)
        {
            //On crée un noeud racine qui correspondra à un salarié
            XmlNode rootSalarie = saveRestau.CreateElement("salarié");
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
