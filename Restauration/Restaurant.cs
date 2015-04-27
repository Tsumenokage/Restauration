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
            //Console.Clear();
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

            if(validationOperation())
                this._listeTables.Add(nouvelleTable);
            else
                Console.WriteLine("Annulation de l'ajout de la table");

            
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

        public void AjoutFormule()
        {
            bool verification = false;
            string nomFormule = "";
            DateTime dureePreparation = new DateTime();
            DateTime dureePresence = new DateTime();
            double prix;
            int ressource;
            ConsoleKeyInfo saisie;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(this._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Gestion des formules : Ajout d'une formule");
                Console.WriteLine("Voulez-vous ajouter une formule consommation(c), à emporter(a), gastronomique(g), normale(n) ou rapide(r) ?");
                saisie = Console.ReadKey(true);
                if (saisie.Key == ConsoleKey.C || saisie.Key == ConsoleKey.A || saisie.Key == ConsoleKey.G || saisie.Key == ConsoleKey.N || saisie.Key == ConsoleKey.R)
                    verification = true;
            } while (verification == false);
            if (saisie.Key == ConsoleKey.C)//ne distingue pas les majuscules ou minuscules...
            {
                Console.WriteLine("Vous avez selectionné une formule consommation");
                nomFormule = "consommation";
            }
            else if (saisie.Key == ConsoleKey.A)
            {
                Console.WriteLine("Vous avez sélectionné une formule à emporter");
                nomFormule = "à emporter";
            }
            else if (saisie.Key == ConsoleKey.G)
            {
                Console.WriteLine("Vous avez sélectionné une formule gastronomique");
                nomFormule = "gastronomique";
            }
            else if (saisie.Key == ConsoleKey.N)
            {
                Console.WriteLine("Vous avez sélectionné une formule normale");
                nomFormule = "normale";
            }
            else if (saisie.Key == ConsoleKey.R)
            {
                Console.WriteLine("Vous avez sélectionné une formule rapide");
                nomFormule = "rapide";
            }

            dureePreparation = this.tempsPreparation();
            dureePresence = this.tempsPresence();
            prix = this.prixFormule();
            ressource = this.ressourceFormule();

            Formule formuleAjoutee = null;

            switch (nomFormule)
	{
                case "consommation" : 
                    formuleAjoutee = new FormuleConsommation(nomFormule,dureePresence,dureePreparation,prix,ressource);
                    break;
                case "à emporter" : 
                    formuleAjoutee = new FormuleEmporter(nomFormule,dureePresence,dureePreparation,prix,ressource);
                    break;
                case "gastronomique" : 
                    formuleAjoutee = new FormuleGastronomique(nomFormule,dureePresence,dureePreparation,prix,ressource);
                    break;
                case "normale" :
                    formuleAjoutee = new FormuleNormale(nomFormule,dureePresence,dureePreparation,prix,ressource);
                    break;
                case "rapide" : 
                    formuleAjoutee = new FormuleRapide(nomFormule,dureePresence,dureePreparation,prix,ressource);
                    break;
		        default:
                break;
	}

            if (validationOperation())
                _listeFormules.Add(formuleAjoutee);
            else
                Console.WriteLine("Annulation de l'ajout de la formule");

        }

        public void supprimerFormule()
        {
            bool numOk = false;
            int numeroSuppresion = 0;
            Table formuleASupprimer;

            while (!numOk)
            {
                Console.WriteLine("Veuillez renseigner le numéro de Formule à supprimer : ");
                numOk = int.TryParse(Console.ReadLine(), out numeroSuppresion);
            }


            formuleASupprimer = _listeTables.Find(x => x._numTable == numeroSuppresion);

            if (formuleASupprimer != null)
                _listeTables.Remove(formuleASupprimer);
            else
            {
                Console.WriteLine("Aucune formule ne porte ce numéro");
                Console.ReadLine();
            }



            _listeTables.Remove(formuleASupprimer);
        }

        public void listeFormules()
        {
            Console.Clear();
            Console.WriteLine("Liste des formules du restaurant : ");
            foreach (var formule in _listeFormules)
            {
                Console.WriteLine(formule);
            }
            Console.ReadLine();
        }

        public DateTime tempsPreparation()
        {
            DateTime dureePreparation = new DateTime();
            int minutes;
            do
            {
                Console.WriteLine("Choisir le temps de préparation en minute");
            } while (!int.TryParse(Console.ReadLine(), out minutes) || minutes < 0 || minutes > 60);
            dureePreparation = dureePreparation.AddMinutes(minutes);
            return dureePreparation;
        }

        public DateTime tempsPresence()
        {
            DateTime dureePresence = new DateTime();
            int minutes;
            int heures;
            do
            {
                Console.WriteLine("Choisir le temps de présence en heure");
            } while (!int.TryParse(Console.ReadLine(), out  heures) || heures < 0 || heures > 60);
            dureePresence = dureePresence.AddHours(heures);
            do
            {
                Console.WriteLine("Choisir le temps de présence en minute");
            } while (!int.TryParse(Console.ReadLine(), out  minutes) || minutes < 0 || minutes > 60);
            dureePresence = dureePresence.AddMinutes(minutes);
            return dureePresence;
        }

        public double prixFormule()
        {
            double price;
            bool prixOk = false;
            Console.WriteLine("Entrez le prix de la formule.");
            do
            {
                string txtPrice = Console.ReadLine();
                if (Double.TryParse(txtPrice, out price))
                {
                    prixOk = true;
                }
            } while (!prixOk);

            return price;    

        }

        public int ressourceFormule()
        {
            int ressource;
            do
            {
                Console.WriteLine("Choisir le coût en ressource de la formule");
            } while (!int.TryParse(Console.ReadLine(), out ressource) || ressource < 0);
            return ressource;
        }

        public void AjoutReservation(Reservation R)
        {
            _listeReservations.Add(R);
        }

        public void SupprimerReservation(Reservation R)
        {
            _listeReservations.Remove(R);
        }


        public bool validationOperation()
        {
            bool saisieOk = false;

            while (!saisieOk)
            {
                Console.WriteLine("Validez vous l'opération que vous venez d'effectuer ? (o ou n)");
                ConsoleKeyInfo saisie = Console.ReadKey(true);
                if (saisie.Key == ConsoleKey.O)
                    return true;
                else if (saisie.Key == ConsoleKey.N)
                    return false;
            }
            return false;

        }
    }
}
