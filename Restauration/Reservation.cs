using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class Reservation
    {
        public int _numeroReservation { get; private set; }
        private static int _numTotal;
        public String _nomClient { get; private set; }
        private String _numeroTelephone { get; set; }
        public DateTime _dateReservation { get; private set; }
        private int _nbConvives { get; set; }
        private String _formuleRetenue { get; set; }
        private List<Table> _listeTablesReserve { get; set; }

        public Reservation(String _nomClient, String _numeroTelephone,
            DateTime _dateReservation, int _nbConvives, String _formuleRetenue)
        {
            _numeroReservation = _numTotal + 1;
            _numTotal++;
            this._nomClient = _nomClient;
            this._numeroTelephone = _numeroTelephone;
            this._dateReservation = _dateReservation;
            this._nbConvives = _nbConvives;
            this._formuleRetenue = _formuleRetenue;
            this._listeTablesReserve = new List<Table>();
        }

        public override string ToString()
        {
            String res;

            res = "    Numéro de réservation : " + _numeroReservation +"\n";
            res += "    Nom du client : " + _nomClient + "\n";
            res += "    Numéro de téléphone : " + _numeroTelephone + "\n";
            res += "    Date de Résèrvation : " + _dateReservation.ToString("g") + "\n";
            res += "    Nombre de convives : " + _nbConvives + "\n";
            res += "    Formule retenue : " + _formuleRetenue + "\n";

            return res;
        }

        public void GestionReservation (string nomFormule, int nbConvives, DateTime dateReservation, Restaurant R)
        {
            int ressourceNecessairePreparation = 0;
            int ressourcePreparation = 0;
            int ressourceSalarie = 0;
            bool ressourceValidation = true;
            bool tableValidation = true;
            while (ressourceValidation != false || tableValidation != false)
            {
                foreach (Salarie S in R._listeSalaries)
                {
                    ressourceSalarie += S._ressource;
                }
                Formule form;
                foreach (Formule Fo in R._listeFormules)
                {
                    form = R._listeFormules.Find(x => x._nomFormule == nomFormule);
                    ressourceNecessairePreparation = ressourceNecessairePreparation + form._ressource * nbConvives;
                }
                foreach (Reservation Reserve in R._listeReservations)
                {
                    form = R._listeFormules.Find(x => x._nomFormule == this._formuleRetenue);
                    TimeSpan tempsPreparation = new TimeSpan(form._dureePreparation.Hour, form._dureePreparation.Minute, form._dureePreparation.Second);
                    DateTime finPreparation = Reserve._dateReservation + tempsPreparation;
                    if (dateReservation < finPreparation && dateReservation > Reserve._dateReservation)
                    {
                        ressourcePreparation += form._ressource * Reserve._nbConvives;
                    }
                }
                if (ressourceNecessairePreparation > (ressourceSalarie - ressourcePreparation))
                {
                    ressourceValidation = false;
                }
            }
            List<Table> tablesRestaurant = R._listeTables;
            foreach (Reservation Rest in R._listeReservations)
            {
                foreach (Table T in Rest._listeTablesReserve)
                {
                    if (tablesRestaurant.Contains(T))
                    {
                        tablesRestaurant.Remove(T);
                    }
                }
            }
            if (tablesRestaurant.Count == 0)
            {
                tableValidation = false;
            }
            else
            {
                chercheTable(tablesRestaurant, nbConvives, R);
            } 
        }
        public List<Table> chercheTable(List<Table> tablesRestaurant, int nbConvives, Restaurant R)
        {
            List<Table> tables = new List<Table>();
            foreach (Table T in tablesRestaurant)
            {
                if (T._nbPlacesMax == nbConvives & T._jumelage == false)
                {
                    tables.Add(T);
                    return tables;
                }
                return tables;
            }
        }
    }
}
