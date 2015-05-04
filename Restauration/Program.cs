using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class Program
    {
        static void Main(string[] args)
        {
            bool premierChoix = MenuBase();
            bool quitteLogiciel = false;
            Restaurant restaurant = null;

            if (premierChoix)
                restaurant = nouveauRestaurant();
            else
            {
                //Procédure de chargement de fichier XML à mettre en place
            }

            while (!quitteLogiciel)
            {
                int choix = choixMenuPrincipal(restaurant); 
                switch (choix)
                {
                    case 1:
                        int choixReservation = choixMenuReservation(restaurant);
                        switch (choixReservation)
	                    {
                            case 1:
                                restaurant.listeReservation();
                                break;
                            case 2 :
                                restaurant.AjoutReservation();
                                break;
                            case 3 :
                                restaurant.supprimerReservation();
                                break;
                            case 4 :
                                restaurant.rechercheReservationNom();
                                break;
		                    default:
                                break;
	                    }
                        break;
                    case 2:
                        int choixTable = choixMenuTable(restaurant);
                        switch (choixTable)
                        {
                            case 1:
                                restaurant.listeTables();
                                break;
                            case 2:
                                restaurant.AjoutTable();
                                break;
                            case 3:
                                restaurant.SupprimerTable();
                                break;
                        }
                        break;
                    case 3:
                        int choixFormule = choixMenuFormule(restaurant);
                        switch (choixFormule)
	                    {
                            case 1 :
                                restaurant.listeFormules();
                                break;
                            case 2 :
                                restaurant.AjoutFormule();
                                break;
                            case 3 :
                                restaurant.supprimerFormule();
                                break;
	                    }
                        break;
                    case 4:
                        int choixSalarie = choixMenuSalarie(restaurant);
                        switch (choixSalarie)
                        {
                            case 1:
                                restaurant.listeSalarie();
                                break;
                            case 2:
                                restaurant.AjoutSalarie();
                                break;
                            case 3:
                                restaurant.supprimerSalarie();
                                break;
                        }
                        break;
                    case 5:
                        restaurant.sauvegardeRestaurant();
                        break;
                    case 6:
                        quitteLogiciel = true;
                        break;
                }

            }

            Console.WriteLine("Merci d'avoir utilisé notre logiciel");
            Console.ReadLine();
        }

        static bool MenuBase()
        {
            while(true)
            {
                Console.WriteLine("Veuillez sélectionner une action :");
                Console.WriteLine("[1] Créer un nouveau restaurant");
                Console.WriteLine("[2] Charger un fichier existant");
                int choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        return true;
                    case 2:
                        Console.WriteLine("WIP");
                        break;
                    default:
                        Console.WriteLine("Erreur dans le choix");
                        break;
                }
            }
        }

        static Restaurant nouveauRestaurant()
        {
            Console.WriteLine("Veuillez renseigner le nom de votre restaurant");
            String nomRestaurant = Console.ReadLine();
            
            Restaurant restaurant = new Restaurant(nomRestaurant);

            return restaurant;
        }

        public static int choixMenuPrincipal(Restaurant restaurant)
        {
            int choix;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(restaurant._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Veuillez sélectionner une action à effectuer");
                Console.WriteLine("[1] Gestion des reservation");
                Console.WriteLine("[2] Gestion des tables");
                Console.WriteLine("[3] Gestion des formules");
                Console.WriteLine("[4] Gestion des salariés");
                Console.WriteLine("[5] Sauvegarder les informations");
                Console.WriteLine("[6] Quitter le logiciel");
            } while (!int.TryParse(Console.ReadLine(), out choix) || choix > 6 || choix < 0);
            return choix;
        }

        public static int choixMenuTable(Restaurant restaurant)
        {
            int choixTable;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(restaurant._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Veuillez sélectionner une action à effectuer");
                Console.WriteLine("[1] Tables existantes");
                Console.WriteLine("[2] Ajout de tables");
                Console.WriteLine("[3] Supression de table");
                Console.WriteLine("[4] Retour au menu principal");
            } while (!int.TryParse(Console.ReadLine(), out choixTable) || choixTable > 4 || choixTable < 0);
            return choixTable;
        }

        public static int choixMenuFormule(Restaurant restaurant)
        {
            int choixFormule;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(restaurant._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Veuillez sélectionner une action à effectuer");
                Console.WriteLine("[1] Formules existantes");
                Console.WriteLine("[2] Ajout de formules");
                Console.WriteLine("[3] Supression de formules");
                Console.WriteLine("[4] Retour au menu principal");
            } while (!int.TryParse(Console.ReadLine(), out choixFormule) || choixFormule > 4 || choixFormule < 0);
            return choixFormule;
        }

        public static int choixMenuSalarie(Restaurant restaurant)
        {
            int choixSalarie;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(restaurant._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Veuillez sélectionner une action à effectuer");
                Console.WriteLine("[1] Salariés existants");
                Console.WriteLine("[2] Ajout de salariés");
                Console.WriteLine("[3] Supression de salariés");
                Console.WriteLine("[4] Retour au menu principal");
            } while (!int.TryParse(Console.ReadLine(), out choixSalarie) || choixSalarie > 4 || choixSalarie < 0);
            return choixSalarie;
        }

        public static int choixMenuReservation(Restaurant restaurant)
        {
            int choixReservation;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(restaurant._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Veuillez sélectionner une action à effectuer");
                Console.WriteLine("[1] Reservation existantes");
                Console.WriteLine("[2] Ajouter une reservation");
                Console.WriteLine("[3] Supression de reservation");
                Console.WriteLine("[4] Recherchee une reservation");
                Console.WriteLine("[5] Retour au menu principal");
            } while (!int.TryParse(Console.ReadLine(), out choixReservation) || choixReservation > 4 || choixReservation < 0);
            return choixReservation;
        }
    }
}
