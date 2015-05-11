using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    /// <summary>
    /// Fonction principale du programme qui contiendra le Main ainsi que les affichages des menus et autres informations
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            ///On lance la fonction Menubase afin de savoir ce que désire l'utilisateur
            ///Cette fonction retourna true si l'on crée un nouveau restaurant et retournera false si 
            ///on désie en chargé un
            bool premierChoix = MenuBase();
            bool quitteLogiciel = false;
            Restaurant restaurant = null;

            ///On regarde le premier choix de l'utilisateur
            if (premierChoix)
                restaurant = nouveauRestaurant();
            else
            {
                restaurant = chargementRestaurant();
            }

            ///On rentre dans la boucle de Menu que l'on ne quittera que lorsque l'on quittera le programme
            while (!quitteLogiciel)
            {
                ///On récupère un entier correspondant au choix de l'utilisateur
                int choix = choixMenuPrincipal(restaurant);
                ///L'on effectue un switch sur ce choix,
                ///si le choix necessite l'ouvertur d'un nouveau menu,
                ///on l'affichera et on fera un nouveau switch sur le choix
                ///de l'utilisateur
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

        /// <summary>
        /// Fonction qui va afficher le premier menu du programme
        /// </summary>
        /// <returns>True si l'on crée un nouveau restaurant, false si l'on souhaite en charger un</returns>
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
                        return false;
                    default:
                        Console.WriteLine("Erreur dans le choix");
                        break;
                }
            }
        }


        /// <summary>
        /// Menu de création d'un nouveau restaurant
        /// </summary>
        /// <returns>le restaurant nouvellement crée</returns>
        static Restaurant nouveauRestaurant()
        {
            Console.WriteLine("Veuillez renseigner le nom de votre restaurant");
            String nomRestaurant = Console.ReadLine();
            
            Restaurant restaurant = new Restaurant(nomRestaurant);

            return restaurant;
        }

        /// <summary>
        /// Menu de Chargement de Restaurant
        /// </summary>
        /// <returns>Le Restaurant chargé</returns>
        public static Restaurant chargementRestaurant()
        {
            String nomRestaurant;
            Restaurant restaurantCharge;
            do
            {
                Console.WriteLine("Veuillez indiquer le nom du restaurant à charger");
                nomRestaurant = Console.ReadLine();
                restaurantCharge = new Restaurant(nomRestaurant);
            } while (!restaurantCharge.ChargementRestaurant());

            

            return restaurantCharge;


        }
        
        /// <summary>
        /// Affichage du Menu principale
        /// </summary>
        /// <param name="restaurant">Le restaurant concerné par l'application</param>
        /// <returns>un entier symbolisant le choix de l'utilisateur</returns>
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

        /// <summary>
        /// Affichage du menu de choix d'actions sur les tables
        /// </summary>
        /// <param name="restaurant">Le restaurant concerné par l'application</param>
        /// <returns>un entier symbolisant le choix de l'utilisateur</returns>
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

        /// <summary>
        /// Affichage du menu de choix d'actions sur les formules
        /// </summary>
        /// <param name="restaurant">Le restaurant concerné par l'application</param>
        /// <returns>un entier symbolisant le choix de l'utilisateur</returns>
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

        /// <summary>
        /// Affichage du menu de choix d'actions sur les salariés
        /// </summary>
        /// <param name="restaurant">Le restaurant concerné par l'application</param>
        /// <returns>un entier symbolisant le choix de l'utilisateur</returns>
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

        /// <summary>
        /// Affichage du menu de choix d'actions sur les reservations
        /// </summary>
        /// <param name="restaurant">Le restaurant concerné par l'application</param>
        /// <returns>un entier symbolisant le choix de l'utilisateur</returns>
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
