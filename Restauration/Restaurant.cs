using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace Restauration
{
    /// <summary>
    /// Classe principale est unique, il n'y aura qu'une seule instance de la classe restaurant sur laquelle on travaillera 
    /// pendant l'utilisation du programme
    /// </summary>
    class Restaurant
    {
        public String _nomRestaurant { get; private set; }
        public List<Table> _listeTables { get; private set; }
        public List<Formule> _listeFormules { get; private set; }
        public List<Reservation> _listeReservations { get; private set; }
        public List<Salarie> _listeSalaries { get; private set; }
        private enum _typeTable
        { 
            Carre , 
            Ronde,
            Rectangulaire
        };

        /// <summary>
        /// Constructeur de Restaurant
        /// </summary>
        /// <param name="_nomRestaurant">String représant le nom du Restaurant</param>
        public Restaurant(String _nomRestaurant)
        {
            this._nomRestaurant = _nomRestaurant;
            _listeTables        = new List<Table>();
            _listeFormules      = new List<Formule>();
            _listeReservations  = new List<Reservation>();
            _listeSalaries      = new List<Salarie>();
        }   

        /// <summary>
        /// Cette fonction va intégagir avec l'utilisateur afin de créer une nouvelle Table
        /// </summary>
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
        }
 
        /// <summary>
        /// Cette fonction va afficher le questionnaire afin de créer une table
        /// </summary>
        /// <param name="typeTable">Le type de table voulu par l'utilisateur</param>
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

        /// <summary>
        /// Cette fonction va intéragir avec l'utilisateur afin de supprimer une table
        /// </summary>
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

        /// <summary>
        /// Cette fonction va lister l'ensemble des tables de Restaurant
        /// </summary>
        public void listeTables()
        {
            Console.WriteLine("Liste des tables du restaurant : ");
            foreach (var table in _listeTables)
            {
                Console.WriteLine(table);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Cette fonction va intéragir aveck'utilisateur afin de créer une nouvelle formule
        /// </summary>
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

        /// <summary>
        /// Cette fonction va intéragir avec l'utilisateur afin de supprimer une formule
        /// </summary>
        public void supprimerFormule()
        {
            bool numOk = false;
            int numeroSuppresion = 0;
            Formule formuleASupprimer;

            while (!numOk)
            {
                Console.WriteLine("Veuillez renseigner le numéro de Formule à supprimer : ");
                numOk = int.TryParse(Console.ReadLine(), out numeroSuppresion);
            }


            formuleASupprimer = _listeFormules.Find(x => x._numFormule == numeroSuppresion);

            if (formuleASupprimer != null)
                this._listeFormules.Remove(formuleASupprimer);
            else
            {
                Console.WriteLine("Aucune formule ne porte ce numéro");
                Console.ReadLine();
            }



            this._listeFormules.Remove(formuleASupprimer);
        }

        /// <summary>
        /// Cette fonction va afficher toutes les formules de restaurant
        /// </summary>
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

        /// <summary>
        ///Cette fonction va questionner l'utilisateur sur le temps de préparation d'une formule
        /// </summary>
        /// <returns>Un DateTime représantant le temps de préparation</returns>
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

        /// <summary>
        ///Cette fonction va questionner l'utilisateur sur le temps de présence d'une formule
        /// </summary>
        /// <returns>Un DateTime représantant le temps de présence</returns>
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

        /// <summary>
        /// Cette fonction va quesitonner l'utilisateur sur le prix d'une formule
        /// </summary>
        /// <returns>Le prix de la formule en double</returns>
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

        /// <summary>
        /// Va questionner l'utilisateur sur les ressources nécessaires
        /// à la préparation d'une formule
        /// </summary>
        /// <returns></returns>
        public int ressourceFormule()
        {
            int ressource;
            do
            {
                Console.WriteLine("Choisir le coût en ressource de la formule");
            } while (!int.TryParse(Console.ReadLine(), out ressource) || ressource < 0);
            return ressource;
        }

        /// <summary>
        /// Cette fonction va gérere l'ajout de réservations
        /// </summary>
        public void AjoutReservation()
        {
            String nomClient;
            String numTelephone;
            DateTime dateReservationClient;
            int nbConvive;
            string nomFormule = "";
            bool verification = false;
            ConsoleKeyInfo saisie;

            System.Text.RegularExpressions.Regex myRegexTelephone = new Regex(@"0[1-9][0-9]{8}");



            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine(this._nomRestaurant);
            Console.WriteLine("******************************************");
            Console.WriteLine("Ajout d'une reservation");
            Console.WriteLine("Entrer le nom du client :");
            nomClient = Console.ReadLine();
            do
            {
                Console.WriteLine("Entrer son numéro de téléphone : ");
                numTelephone = Console.ReadLine();
            } while (!myRegexTelephone.IsMatch(numTelephone));
            dateReservationClient = dateReservation();

            do
            {
                Console.WriteLine("Nombre de convives :");
            } while (!int.TryParse(Console.ReadLine(), out nbConvive));

            bool formuleExiste = false;
            while(!formuleExiste)
            {
                do
                {
                    Console.WriteLine("Type de formule retenue ?  (formule consommation(c), à emporter(a), gastronomique(g), normale(n) ou rapide(r))");
                    saisie = Console.ReadKey(true);
                    if (saisie.Key == ConsoleKey.C || saisie.Key == ConsoleKey.A || saisie.Key == ConsoleKey.G || saisie.Key == ConsoleKey.N || saisie.Key == ConsoleKey.R)
                        verification = true;
                } while (verification == false);
                if (saisie.Key == ConsoleKey.C)//ne distingue pas les majuscules ou minuscules...
                {
                    nomFormule = "consommation";
                }
                else if (saisie.Key == ConsoleKey.A)
                {
                    nomFormule = "à emporter";
                }
                else if (saisie.Key == ConsoleKey.G)
                {
                    nomFormule = "gastronomique";
                }
                else if (saisie.Key == ConsoleKey.N)
                {
                    nomFormule = "normale";
                }
                else if (saisie.Key == ConsoleKey.R)
                {
                    nomFormule = "rapide";
                }

                Formule existe = this._listeFormules.Find(x => x._nomFormule == nomFormule);

                if (existe != null)
                    formuleExiste = true;
            }



            Reservation nouvelleReservation = new Reservation(nomClient, numTelephone, dateReservationClient, nbConvive, nomFormule);
            bool reservationOk = nouvelleReservation.GestionReservation(nomFormule, nbConvive, dateReservationClient, this);

            if (reservationOk)
            {
                if (validationOperation())
                {
                    _listeReservations.Add(nouvelleReservation);
                    _listeReservations = _listeReservations.OrderBy(o => o._dateReservation).ToList();
                }
                else
                    Console.WriteLine("Annulation de l'ajout de la reservation");                
            }
        }

        /// <summary>
        /// Cette fonction va questionner l'utilisateur sur la date et heure de la reservation à ajouter
        /// </summary>
        /// <returns></returns>
        public DateTime dateReservation()
        {
            ///Ces expression régulière sont là pour vérifier ques les dates et les heures sont rentrés au bons format
            ///jj/mm/aaaa pour la date et hh:mm pour l'heure
            System.Text.RegularExpressions.Regex myRegexDate = new Regex(@"^\d{1,2}\/\d{1,2}\/\d{4}$");
            System.Text.RegularExpressions.Regex myRegexHeure = new Regex(@"([0-1][0-9]|2[0-3]):[0-5][0-9]");
            DateTime dateReservation;

            String date = "";
            String heure = "";

            do
            {
                do
                {
                    Console.WriteLine("Date de la reservation : (format jj/mm/aaaa)");
                    date = Console.ReadLine();
                } while (!myRegexDate.IsMatch(date));


                do
                {
                    Console.WriteLine("Heure de la reservation : (format hh:mm)");
                    heure = Console.ReadLine();
                } while (!myRegexHeure.IsMatch(heure));

                date += " " + heure;
                dateReservation = Convert.ToDateTime(date);
            } while (dateReservation < DateTime.Now);

            return dateReservation;
        }

        /// <summary>
        /// Cette fonction va s'occuper dela suppression d'une reservation
        /// </summary>
        public void supprimerReservation()
        {
            bool numOk = false;
            int numeroSuppresion = 0;
            Reservation reservationASupprimer;

            while (!numOk)
            {
                Console.WriteLine("Veuillez renseigner le numéro de reservation à supprimer : ");
                numOk = int.TryParse(Console.ReadLine(), out numeroSuppresion);
            }


            reservationASupprimer = this._listeReservations.Find(x => x._numeroReservation == numeroSuppresion);

            if (reservationASupprimer != null)
                this._listeReservations.Remove(reservationASupprimer);
            else
            {
                Console.WriteLine("Aucune reservation ne porte ce numéro");
                Console.ReadLine();
            }



            this._listeReservations.Remove(reservationASupprimer);
        }

        /// <summary>
        /// Cette fonction va lister l'ensemble des reservations 
        /// </summary>
        public void listeReservation()
        {
            Console.Clear();
            Console.WriteLine("Liste des reservations du restaurant : ");
            foreach (var reservation in _listeReservations)
            {
                if(reservation._dateReservation >= DateTime.Now)
                    Console.WriteLine(reservation);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Cette fonction va rechercher une reservation qui à pour nom de client celui rechercher par l'utilisateur
        /// </summary>
        public void rechercheReservationNom()
        {
            String nomReservation;
            List<Reservation> resRecherche = new List<Reservation>();

            Console.WriteLine("Entrer le nom ou une partie du nom voulu");
            nomReservation = Console.ReadLine();

            resRecherche = this._listeReservations.FindAll( x => x._nomClient.Contains(nomReservation));

            Console.Clear();
            Console.WriteLine("Resultat de la recherche : ");
            foreach (var reservation in resRecherche)
            {
                if(reservation._dateReservation >= DateTime.Now)
                    Console.WriteLine(reservation);
            }
            Console.ReadLine();


        }

        /// <summary>
        /// Cette fonction va intéragir avec un utilisateur pour ajouter un salarié
        /// </summary>
        public void AjoutSalarie()
        {
            bool verification = false;
            ConsoleKeyInfo saisie;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(this._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Gestion des salariés : Ajout d'un salarié");
                Console.WriteLine("Voulez-vous ajouter un chef de cuisine(c), un chef de partie(p), ou un commis(o) ?");
                saisie = Console.ReadKey(true);
                if (saisie.Key == ConsoleKey.C || saisie.Key == ConsoleKey.P || saisie.Key == ConsoleKey.O)
                    verification = true;
            } while (verification == false);
            Salarie salarieAjoute = null;
            if (saisie.Key == ConsoleKey.C)//ne distingue pas les majuscules ou minuscules...
            {
                Console.WriteLine("Vous avez selectionné un chef de cuisine");
                salarieAjoute = new SalarieChefCuisine();
            }
            else if (saisie.Key == ConsoleKey.P)
            {
                Console.WriteLine("Vous avez sélectionné un chef de partie");
                salarieAjoute = new SalarieChefPartie();
            }
            else if (saisie.Key == ConsoleKey.O)
            {
                Console.WriteLine("Vous avez sélectionné un commis");
                salarieAjoute = new SalarieCommis();
            }
            if (validationOperation())
                _listeSalaries.Add(salarieAjoute);
            else
                Console.WriteLine("Annulation de l'ajout du salarié");

        }

        /// <summary>
        /// Cette fonction va permmetre la suppression d'un salarié
        /// </summary>
        public void supprimerSalarie()
        {
            bool numOk = false;
            int numeroSuppresion = 0;
            Salarie salarieASupprimer;

            while (!numOk)
            {
                Console.WriteLine("Veuillez renseigner le numéro du salarié à supprimer : ");
                numOk = int.TryParse(Console.ReadLine(), out numeroSuppresion);
            }


            salarieASupprimer = _listeSalaries.Find(x => x._numSalarie == numeroSuppresion);

            if (salarieASupprimer != null)
                this._listeSalaries.Remove(salarieASupprimer);
            else
            {
                Console.WriteLine("Aucun Salarié ne porte ce numéro");
                Console.ReadLine();
            }



            this._listeSalaries.Remove(salarieASupprimer);
        }

        /// <summary>
        /// Cette fonction va lister tous les salariés de Restaurant
        /// </summary>
        public void listeSalarie()
        {
            Console.Clear();
            Console.WriteLine("Liste des salarié du restaurant : ");
            foreach (var salarie in _listeSalaries)
            {
                Console.WriteLine(salarie);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Cette fonction va demander à l'utilisateur de confirmer une action
        /// </summary>
        /// <returns>true si l'utilisateur valide l'action et false sinon</returns>
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

        /// <summary>
        /// Cette fonction va sauvegarder les informations du estaurant courant au format Xml
        /// </summary>
        public void sauvegardeRestaurant()
        {
            XmlDocument saveRestau = new XmlDocument();

            XmlNode restaurantNode = saveRestau.CreateElement("restaurant");
            saveRestau.AppendChild(restaurantNode);
            XmlNode nomRestaurant = saveRestau.CreateElement("nomRestaurant");
            nomRestaurant.InnerText = this._nomRestaurant;
            restaurantNode.AppendChild(nomRestaurant);

            //Sauvegarde de la liste des tables
            XmlNode listesTables = saveRestau.CreateElement("listeTables");
            foreach (var table in _listeTables)
            {
                table.sauvegardeTable(saveRestau, listesTables);
            }
            restaurantNode.AppendChild(listesTables);

            //Sauvegarde de la liste des formules
            XmlNode listeFormules = saveRestau.CreateElement("listesFormules");
            foreach (var formule in _listeFormules)
            {
                formule.sauvegardeFormule(saveRestau, listeFormules);
            }

            restaurantNode.AppendChild(listeFormules);

            //Sauvegarde de la listes des employés
            XmlNode listeSalaries = saveRestau.CreateElement("listesSalaries");
            foreach (var salarie in _listeSalaries)
            {
                salarie.sauvegardeSalarie(saveRestau, listeSalaries);
            }

            restaurantNode.AppendChild(listeSalaries);


            //Sauvegarde de la liste des reservations
            XmlNode listeReservations = saveRestau.CreateElement("listeReservations");
            foreach (Reservation reserv in this._listeReservations)
            {
                reserv.sauvegardeReservation(saveRestau, listeReservations);
            }

            restaurantNode.AppendChild(listeReservations);

            saveRestau.Save(this._nomRestaurant + ".xml");

        }

        /// <summary>
        /// Cette fonction va charger un fichier Xml correspondant à un restaurant
        /// </summary>
        /// <returns>un bool indiquant si le chargement est un succès ou un échèque</returns>
        public bool ChargementRestaurant()
        {
            XmlDocument xmlDoc = new XmlDocument();

           ///On essaie d'ouvrir le fichier xml et si l'on ne peut aps on lève une Exception
            try
            {
                xmlDoc.Load(this._nomRestaurant + ".xml");
            }
            catch(Exception e)
            {
                Console.WriteLine("Fichier Xml inexistant");
                return false;
            }


            XmlNode noeud = xmlDoc.DocumentElement;
            Console.WriteLine(noeud.ToString());


            try
            {
                XmlNodeList noeudRestaurant = noeud.SelectNodes("nomRestaurant");
                this._nomRestaurant = noeudRestaurant[0].InnerText;
            }
            catch (Exception)
            {

                return false;
            }

            XmlNode noeudTables = noeud.SelectSingleNode("listeTables");
            XmlNodeList tablesEnregistree = noeudTables.SelectNodes("table");

            foreach (XmlNode table in tablesEnregistree)
            {
                Table tableAjoutee;
                String typeTable = table.Attributes[0].Value;
                int numTable = int.Parse(table.SelectSingleNode("NumeroTable").InnerText);
                int nbPlaceMax = int.Parse(table.SelectSingleNode("CapaciteTable").InnerText);
                bool jumelable = bool.Parse(table.SelectSingleNode("Jumelable").InnerText);


                if (typeTable == "Restauration.TableRonde")
                    tableAjoutee = new TableRonde(numTable,nbPlaceMax,jumelable);
                else if (typeTable == "Restauration.TableCarree")
                    tableAjoutee = new TableCarree(numTable, nbPlaceMax, jumelable);
                else
                    tableAjoutee = new TableRectangulaire(numTable, nbPlaceMax, jumelable);

                this._listeTables.Add(tableAjoutee);
                   
            }
   

            XmlNode noeudFormules = noeud.SelectSingleNode("listesFormules");
            XmlNodeList formulesEnregistree = noeudFormules.SelectNodes("formule");

            foreach (XmlNode formule in formulesEnregistree)
            {
                Formule formuleAjoutee;
                String typeFormule = formule.Attributes[0].Value;

                int numeroFormule = int.Parse(formule.SelectSingleNode("numeroFormule").InnerText);

                String nomFormule = formule.SelectSingleNode("nomFormule").InnerText;

                String dureePresence = "01/01/2000 ";
                dureePresence += formule.SelectSingleNode("dureePresence").InnerText;
                DateTime Presence = Convert.ToDateTime(dureePresence);

                String dureePreparation = "01/01/2000 ";
                dureePreparation += formule.SelectSingleNode("dureePreparation").InnerText;
                DateTime Preparation = Convert.ToDateTime(dureePreparation);

                int prix = int.Parse(formule.SelectSingleNode("prix").InnerText);
                    
                int ressource = int.Parse(formule.SelectSingleNode("ressource").InnerText);

                if (typeFormule == "Restauration.FormuleConsommation")
                    formuleAjoutee = new FormuleConsommation(nomFormule, Presence, Preparation, prix, ressource);
                else if (typeFormule == "Restauration.FormuleEmporter")
                    formuleAjoutee = new FormuleEmporter(nomFormule, Presence, Preparation, prix, ressource);
                else if (typeFormule == "Restauration.FormuleGastronomique")
                    formuleAjoutee = new FormuleGastronomique(nomFormule, Presence, Preparation, prix, ressource);
                else if (typeFormule == "Restauration.FormuleNormale")
                    formuleAjoutee = new FormuleNormale(nomFormule, Presence, Preparation, prix, ressource);
                else
                    formuleAjoutee = new FormuleRapide(nomFormule, Presence, Preparation, prix, ressource);


                this._listeFormules.Add(formuleAjoutee);
                   
            }


            XmlNode noeudSalarie = noeud.SelectSingleNode("listesSalaries");
            XmlNodeList salariesEnregistree = noeudSalarie.SelectNodes("salarie");

            foreach (XmlNode salarie in salariesEnregistree)
            {
                Salarie salarieAjoute;
                String typeTable = salarie.Attributes[0].Value;
                int numero = int.Parse(salarie.SelectSingleNode("numeroSalarie").InnerText);
                int ressource = int.Parse(salarie.SelectSingleNode("ressourceSalarie").InnerText);
                
                if (typeTable == "Restauration.SalarieChefCuisine")
                    salarieAjoute = new SalarieChefCuisine(numero, ressource);
                else if (typeTable == "Restauration.SalarieChefPartie")
                    salarieAjoute = new SalarieChefPartie(numero, ressource);
                else
                    salarieAjoute = new SalarieCommis(numero, ressource);

                this._listeSalaries.Add(salarieAjoute);

            }

            XmlNode noeudFormule = noeud.SelectSingleNode("listeReservations");
            XmlNodeList reservationEnregistree = noeudFormule.SelectNodes("reservation");

            foreach (XmlNode reservation in reservationEnregistree)
            {
                Reservation reservationAjout;
                int numeroReservation = int.Parse(reservation.SelectSingleNode("NumeroReservation").InnerText);
                String nomClient = reservation.SelectSingleNode("NumeroTelephones").InnerText;
                String numeroClient = reservation.SelectSingleNode("nomClient").InnerText;
                DateTime dateReservation = Convert.ToDateTime(reservation.SelectSingleNode("dateReservation").InnerText);
                int nombreConvives = int.Parse(reservation.SelectSingleNode("NombreConvives").InnerText);
                String formuleRetenue = reservation.SelectSingleNode("formuleRetenue").InnerText;

                //On s'occupe des tables utilisées par la reservations
                List<Table> tablesReservee = new List<Table>();

                XmlNodeList tablesReservations = reservation.SelectNodes("tablesReservees");

                foreach (XmlNode table in tablesReservations)
                {
                    //On ajoute chaque table utilisée par la resevation dans la listes.
                    tablesReservee.Add(_listeTables.Find(x => x._numTable == int.Parse(table.InnerText)));
                }

                reservationAjout = new Reservation(numeroReservation, nomClient, numeroClient, dateReservation, nombreConvives, formuleRetenue, tablesReservee);
                Console.WriteLine(reservationAjout);
                Console.ReadLine();
                this._listeReservations.Add(reservationAjout);

            }

            return true;
        }
    }
}
