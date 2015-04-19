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
                        Console.WriteLine("WIP");
                        break;
                    case 2:
                        int choixTable = choixMenuTable(restaurant);
                        switch (choixTable)
                        {
                            case 21:
                                Console.WriteLine("WIP");
                                break;
                            case 22:
                                AjouterTable(restaurant);
                                break;
                            case 23:
                                Console.WriteLine("WIP");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("WIP");
                        break;
                    case 4:
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
                Console.WriteLine("[3] Gestion des des formules");
                Console.WriteLine("[4] Quitter le logiciel");
            } while (!int.TryParse(Console.ReadLine(), out choix) || choix > 4 || choix < 0);
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
                Console.WriteLine("[21] Tables existantes");
                Console.WriteLine("[22] Ajout de tables");
                Console.WriteLine("[23] Supression de table");
                Console.WriteLine("[24] Retour au menu principal");
            } while (!int.TryParse(Console.ReadLine(), out choixTable) || choixTable > 24 || choixTable < 20);
            return choixTable;
        }
        public static void AjouterTable(Restaurant R)
        {
            Console.WriteLine("Voulez-vous continuer une table carrée(C), ronde(O) ou rectangulaire(R) ?");
            ConsoleKeyInfo saisie = Console.ReadKey(true);
            if (saisie.Key == ConsoleKey.C || saisie.Key == ConsoleKey.R)//ne distingue pas les majuscules ou minuscules...
            {
                Console.WriteLine("On continue ...");
            }
            else
            {
                Console.WriteLine("On s'arrête ...");
            }
            Console.ReadLine();
        }
    }
}
