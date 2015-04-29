﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Restauration
{
    // création de la classe abstraite table
    abstract class Table
    {
        //champs nécessaires à la création d'une classe table
        public int _numTable { get; protected set; } //numéro de la table
        protected static int _numTotale;
        protected int _nbPlacesMax { get; set; } //nombre de place maximum de la table
        protected bool _jumelage { get; set; } //O ou N en fonction de si la table peut être jumelée ou non
        public Table(int nbPlaceMax, bool jumelage)//contructeur de la classe table
        {
            _numTable = _numTotale + 1;
            _numTotale++;
            _nbPlacesMax = nbPlaceMax;
            _jumelage = jumelage;
        }
        public override string ToString()
        {
            string ch = "";
            ch += "Numero:" + _numTable + "     nbPlaceMax:" + _nbPlacesMax +"     Jumelage:" + _jumelage;
            return ch;
        }

        public void sauvegardeTable(XmlDocument saveRestau, XmlNode listeTables)
        {
            //On crée un noeud racine qui correspondra à une table
            XmlNode rootTable = saveRestau.CreateElement("table");
            //On définie un attribut permettant de distinguer le type de table
            XmlAttribute typeTable = saveRestau.CreateAttribute("typeTable");
            typeTable.Value = this.GetType().ToString();
            rootTable.Attributes.Append(typeTable);

            //On enregistre les différentes informations de la table dans le noeud racine
            XmlNode numTable = saveRestau.CreateElement("NumeroTable");
            XmlNode nbPlaceTable = saveRestau.CreateElement("CapaciteTable");
            XmlNode jumelable = saveRestau.CreateElement("Jumelable");

            numTable.InnerText = this._numTable.ToString();
            nbPlaceTable.InnerText = this._nbPlacesMax.ToString();
            jumelable.InnerText = this._jumelage.ToString();

            rootTable.AppendChild(numTable);
            rootTable.AppendChild(nbPlaceTable);
            rootTable.AppendChild(jumelable);


            //On ajoute ce nouveau noeud au noeud qui contiendra la liste des tables
            listeTables.AppendChild(rootTable);
        }
    }
}
