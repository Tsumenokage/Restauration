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
        private enum _typeTable
        { 
            Carre , 
            Ronde,
            Rectangulaire
        };

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
            Console.WriteLine("Gestion des tables : Ajout de tables");
            Console.WriteLine("Voulez-vous continuer une table carrée(c), ronde(n) ou rectangulaire(r) ?");
            ConsoleKeyInfo saisie = Console.ReadKey(true);
            if (saisie.Key == ConsoleKey.C)//ne distingue pas les majuscules ou minuscules...
            {
                Console.WriteLine("Vous avez selectionné une table carrée");
                questionnaireAjoutTable(_typeTable.Carre);
            }
            else if (saisie.Key == ConsoleKey.N)
            {
                Console.WriteLine("Vous avez sélectionné une table ronde");
                questionnaireAjoutTable(_typeTable.Ronde);
            }
            else if (saisie.Key == ConsoleKey.R)
            {
                Console.WriteLine("Vous avez sélectionné une table rectangulaire");
                questionnaireAjoutTable(_typeTable.Rectangulaire);
            }
            else
            {
                Console.Clear();
                this.AjoutTable();
            }
            Console.ReadLine();
        }

        private void questionnaireAjoutTable(_typeTable typeTable)
        {
            Console.Clear();
            int nbPlace = 0;
            bool jumelable = false;
            String reponseJumelable;
            bool nbplaceOK = false;
            bool jumelableOK = false;
            Table nouvelleTable;

            while (!nbplaceOK)
            {
                Console.WriteLine("Combien de place maximum doit comporter cette table ?");
                nbplaceOK = int.TryParse(Console.ReadLine(), out nbPlace);               
            }

            if(typeTable != _typeTable.Ronde)
            {
                while (!jumelableOK)
                {
                    Console.WriteLine("La table est-elle jumelable ? (oui ou non)");
                    reponseJumelable = Console.ReadLine();

                    if (reponseJumelable =="o" || reponseJumelable =="oui")
                    {
                        jumelable = true;
                        jumelableOK = true;
                    }
                    else if(reponseJumelable == "n" || reponseJumelable == "non")
                    {
                        jumelable = false;
                        jumelableOK = true;
                    }

                }

            }

            if (typeTable == _typeTable.Carre)
                nouvelleTable = new TableCarree(nbPlace, jumelable);
            else if (typeTable == _typeTable.Rectangulaire)
                nouvelleTable = new TableRectangulaire(nbPlace, jumelable);
            else
                nouvelleTable = new TableRonde(nbPlace, false);

            this._listeTables.Add(nouvelleTable);

            
        }

        public void SupprimerTable()
        {
            bool numOk = false;
            int numeroSuppresion = 0;
            Table tableASupprimer;

            while(!numOk)
            {
                Console.WriteLine("Veuillez renseigner le numéro de Table à supprimer : ");
                numOk = int.TryParse(Console.ReadLine(), out numeroSuppresion);
            }

            
            tableASupprimer = _listeTables.Find(x => x._numTable == numeroSuppresion);

            if (tableASupprimer != null)
                _listeTables.Remove(tableASupprimer);
            else
            {
                Console.WriteLine("Aucune table ne porte ce numéro");
                Console.ReadLine();
            }



            _listeTables.Remove(tableASupprimer);
        }

        public void listeTables()
        {
            Console.WriteLine("Liste des tables du restaurant : ");
            foreach (var table in _listeTables)
            {
                Console.WriteLine(table);
            }
            Console.ReadLine();
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
