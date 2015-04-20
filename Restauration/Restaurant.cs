using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class Restaurant
    {
        public String _nomRestaurant { get; private set; }
        private List<Table> _listeTables { get; set; }
        private List<Formule> _listeFormules { get; set; }
        private List<Reservation> _listeReservations { get; set; }

        public Restaurant(String _nomRestaurant)
        {
            this._nomRestaurant = _nomRestaurant;
            _listeTables        = new List<Table>();
            _listeFormules      = new List<Formule>();
            _listeReservations  = new List<Reservation>();
        }
        public void AjoutTable()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine(this._nomRestaurant);
            Console.WriteLine("******************************************");
            Console.WriteLine("[2] Gestion des tables");
            Console.WriteLine("Voulez-vous continuer une table carrée(c), ronde(o) ou rectangulaire(r) ?");
            ConsoleKeyInfo saisie = Console.ReadKey(true);
            if (saisie.Key == ConsoleKey.C || saisie.Key == ConsoleKey.R || saisie.Key == ConsoleKey.O)//ne distingue pas les majuscules ou minuscules...
            {
                Console.WriteLine("On continue ...");
            }
            else
            {
                Console.Clear();
                this.AjoutTable();
            }
            Console.ReadLine();
        }
        public void SupprimerTable(Table T)
        {
            _listeTables.Remove(T);
        }
        public void AjoutFormule(Formule F)
        {
            _listeFormules.Add(F);
        }
        public void SupprimerFormule(Formule F)
        {
            _listeFormules.Remove(F);
        }
        public void AjoutReservation(Reservation R)
        {
            _listeReservations.Add(R);
        }
        public void SupprimerReservation(Reservation R)
        {
            _listeReservations.Remove(R);
        }
    }
}
