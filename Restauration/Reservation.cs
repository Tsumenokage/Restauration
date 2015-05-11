using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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
        public List<Table> _listeTablesReserve { get; set; }

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

        public Reservation(int _numeroReservation, String _nomClient, String _numeroTelephone,
            DateTime _dateReservation, int _nbConvives, String _formuleRetenue, List<Table> _listeTablesReserve)
        {
            this._numeroReservation = _numeroReservation;
            _numTotal++;
            this._nomClient = _nomClient;
            this._numeroTelephone = _numeroTelephone;
            this._dateReservation = _dateReservation;
            this._nbConvives = _nbConvives;
            this._formuleRetenue = _formuleRetenue;
            this._listeTablesReserve = _listeTablesReserve;
            
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
            foreach (Table t in _listeTablesReserve)
            {
                res += "   Table réservée : " + t + "\n";
            }

            return res;
        }

        public bool GestionReservation (string nomFormule, int nbConvives, DateTime dateReservation, Restaurant R)
        {
            Console.WriteLine("gestionreservation");
            List<Table> tablesLibre;


            //On vérifie qu'il y a bien assez de ressources en cuisine
            if (!verificationCuisine(nomFormule, nbConvives, dateReservation, R))
            {
                Console.WriteLine("Les ressources en cuisine ne sont pas suffisantes pour assurer cette réservation");
                Console.ReadLine();
                return false;
            }

            tablesLibre = rechercheTableLibre(nbConvives, R, dateReservation,nomFormule);
            Console.WriteLine("Nombre de table libre " + tablesLibre.Count);

            foreach (Table table in tablesLibre)
            {
                Console.WriteLine(table.ToString()); 
            }
            Console.ReadLine();


            if(tablesLibre.Count == 0)
            {
                Console.WriteLine("Aucun tables n'est disponible pour cette horaire");
                Console.ReadLine();
                return false;
            }

            this._listeTablesReserve = rechercheTableReservation(nbConvives, tablesLibre);

            return true;
        }

        //Cette fonction va vérifier si le personnel peut prendre en compte la commande
        public bool verificationCuisine(string nomFormule, int nbConvives, DateTime dateReservation, Restaurant R)
        {
            int ressourcePreparation = 0;
            int ressourceSalarie = 0;
            int ressourceNecessairePreparation = 0;
            DateTime finPreparation = new DateTime();

            foreach (Salarie S in R._listeSalaries)
            {
                ressourceSalarie += S._ressource;
            }
            Console.WriteLine("Ressource totale du restaurant : " + ressourceSalarie);


            Formule form;

            foreach (Formule Fo in R._listeFormules)
            {
                form = R._listeFormules.Find(x => x._nomFormule == nomFormule);
                ressourceNecessairePreparation = ressourceNecessairePreparation + form._ressource * nbConvives;
            }

            Console.WriteLine(ressourceNecessairePreparation);
            Console.ReadLine();

            foreach (Reservation Reserve in R._listeReservations)
            {
                form = R._listeFormules.Find(x => x._nomFormule == this._formuleRetenue);
                finPreparation = Reserve._dateReservation;
                finPreparation.AddHours(form._dureePreparation.Hour);
                finPreparation.AddMinutes(form._dureePreparation.Minute);
                if (dateReservation < finPreparation && dateReservation > Reserve._dateReservation)
                {
                    ressourcePreparation += form._ressource * Reserve._nbConvives;
                }
            }

            Console.WriteLine(ressourcePreparation);

            if (ressourceNecessairePreparation > (ressourceSalarie - ressourcePreparation))
            {
                return false;
            }
            else
                return true;
        }

        //Cette fonction va retourner la listes des tables libre à la période de la reservation
        public List<Table> rechercheTableLibre(int nbConvives, Restaurant R, DateTime dateReservation, String nomFormule)
        {
            List<Table> tableReserves = new List<Table>();
            List<Table> tableLibre = new List<Table>();
            DateTime finReservationEnCoursEnregistrement = dateReservation;
            Formule formuleReservationEnCoursEnregistrement = R._listeFormules.Find(x => x._nomFormule == nomFormule);
            finReservationEnCoursEnregistrement =  finReservationEnCoursEnregistrement.AddHours(formuleReservationEnCoursEnregistrement._dureePresence.Hour);
            finReservationEnCoursEnregistrement = finReservationEnCoursEnregistrement.AddMinutes(formuleReservationEnCoursEnregistrement._dureePresence.Minute);


            //Dans un premier temps on récupère les tables non utilisées
            foreach (Reservation reserv in R._listeReservations)
            {
                //On calcule la date de Fin de chaque reservation
                DateTime finPresenceClientDejaReserve = reserv._dateReservation;
                Formule formuleReservation = R._listeFormules.Find( x => x._nomFormule == reserv._formuleRetenue);
                finPresenceClientDejaReserve = reserv._dateReservation.AddHours(formuleReservation._dureePresence.Hour);
                finPresenceClientDejaReserve = reserv._dateReservation.AddMinutes(+formuleReservation._dureePresence.Minute);

                //Si le début de la réservation en cours d'enregistrement 
                //empiète sur une autre reservation, on enregistre les tables déjà reservé
                if (dateReservation <= finPresenceClientDejaReserve)
                {
                    foreach (Table table in reserv._listeTablesReserve)
                    {
                        if(table.GetType().ToString() != "Restauration.TableRonde" )
                            tableReserves.Add(table);
                        else
                        {
                            if (table._nbPlacesMax >= nbConvives)
                                tableReserves.Add(table);
                        }
                    }
                }
                
                //Si la fin de la reservation empiète sur une autre reservation
                if (finReservationEnCoursEnregistrement > reserv._dateReservation)
                {
                    foreach (Table table in reserv._listeTablesReserve)
                    {
                        if (table.GetType().ToString() != "Restauration.TableRonde")
                            tableReserves.Add(table);
                        else
                        {
                            if (table._nbPlacesMax >= nbConvives)
                                tableReserves.Add(table);
                        }
                    }
                }
            }

            //On crée ensuite la liste des tables libre
            foreach (Table table in R._listeTables)
            {
                //Si la table courante n'est pas dans la listes des tables reservés
                if(!tableReserves.Contains(table))
                {
                    //On ajoute la table dans la liste des tables libre
                    tableLibre.Add(table);
                }
            }
            return tableLibre;

        }

        public List<Table> rechercheTableReservation(int nbConvive, List<Table> tablesLibre)
        {
            List<Table> tablesReservations = new List<Table>();
            bool numOk = false;
            int numeroTable = -1;
            int nbPlaceCarreeTotale = 0;
            int nbPlaceRectangulaireTotale = 0;

            foreach (Table table in tablesLibre)
            {
                if (table.GetType().ToString() == "Restauration.TableCarree")
                    nbPlaceCarreeTotale += table._nbPlacesMax;
            }

            if (nbPlaceCarreeTotale < nbConvive)
            {
                tablesReservations.RemoveAll(x => x.GetType().ToString() == "Restauration.TableCarree");
            }


            foreach (Table table in tablesLibre)
            {
                if (table.GetType().ToString() == "Restauration.TableRectangulaire")
                    nbPlaceRectangulaireTotale += table._nbPlacesMax;
            }

            if (nbPlaceRectangulaireTotale < nbConvive)
            {
                tablesReservations.RemoveAll(x => x.GetType().ToString() == "Restauration.TableRectangulaire");
            }

            if (tablesLibre.Count == 0)
                return tablesReservations;

            Console.WriteLine("Voici la listes des tables disponibles : ");
            foreach (Table table in tablesLibre)
            {
                Console.WriteLine(table.ToString()); 
            }

            
            while (!numOk)
            {
                Console.WriteLine("Entrez le numéro de la table que vous souhaitez utiliser");
                numOk = int.TryParse(Console.ReadLine(), out numeroTable);
                tablesReservations.Add(tablesLibre.Find(x => x._numTable == numeroTable));
                if(tablesReservations.Count == 0)
                    numOk = false;
            }



            //On retire des tables libres celle ne disposant pas du même types que la première table choisis
            tablesLibre.RemoveAll(x => x.GetType() != tablesReservations[0].GetType());
            //On retire des tables libres la tables que l'on vient de choisir
            tablesLibre.RemoveAll(x => x._numTable == numeroTable);

            while (tablesReservations.Sum(x => x._nbPlacesMax) < nbConvive)
            {
                numOk = false;
                Console.WriteLine("Nombre de place insuffisant, veuillez selectionner une table à jumeler");
                foreach (Table table in tablesLibre)
                {
                    if(table.GetType() == tablesReservations[0].GetType())
                    {
                        Console.WriteLine(table.ToString()); 
                    }
                }

                int oldCount = tablesReservations.Count;
                while (!numOk)
                {
                    int numeroTableJumelable;
                    Console.WriteLine("Entrez le numéro de la table que vous souhaitez utiliser");
                    numOk = int.TryParse(Console.ReadLine(), out numeroTableJumelable);
                    tablesReservations.Add(tablesLibre.Find(x => x._numTable == numeroTableJumelable));
                    if (tablesReservations.Count == oldCount)
                        numOk = false;
                }
                tablesLibre.RemoveAll(x => x._numTable == numeroTable);
            }

            return tablesReservations;
        }

        public void sauvegardeReservation(XmlDocument saveRestau, XmlNode listeReservations)
        {
            //On crée un noeud racine qui correspondra à une reservation
            XmlNode rootReservation = saveRestau.CreateElement("reservation");

            //On enregistre les différentes informations de la table dans le noeud racine
            XmlNode numResa = saveRestau.CreateElement("NumeroReservation");
            XmlNode nomClient = saveRestau.CreateElement("nomClient");
            XmlNode numeroTelephone = saveRestau.CreateElement("NumeroTelephones");
            XmlNode dateReservation = saveRestau.CreateElement("dateReservation");
            XmlNode nbConvives = saveRestau.CreateElement("NombreConvives");
            XmlNode formuleRetenue = saveRestau.CreateElement("formuleRetenue");

            //On crée un noeud qui correspondra à la listes des tables utilisé par la réservation
            XmlNode tableReserve = saveRestau.CreateElement("tablesReservees");

            foreach (Table table in _listeTablesReserve)
            {
                XmlNode numTable = saveRestau.CreateElement("NumeroTableReservee");
                numTable.InnerText = table._numTable.ToString();
                tableReserve.AppendChild(numTable);

            }

            numResa.InnerText = this._numeroReservation.ToString();
            nomClient.InnerText = this._nomClient.ToString();
            numeroTelephone.InnerText = this._numeroTelephone.ToString();
            dateReservation.InnerText = this._dateReservation.ToString();
            nbConvives.InnerText = this._nbConvives.ToString();
            formuleRetenue.InnerText = this._formuleRetenue.ToString();
            



            rootReservation.AppendChild(numResa);
            rootReservation.AppendChild(nomClient);
            rootReservation.AppendChild(numeroTelephone);
            rootReservation.AppendChild(dateReservation);
            rootReservation.AppendChild(nbConvives);
            rootReservation.AppendChild(formuleRetenue);
            rootReservation.AppendChild(tableReserve);

            //On ajoute le noeud qui contiendra les informations de la reservations.
            listeReservations.AppendChild(rootReservation);

        }
    }
}
