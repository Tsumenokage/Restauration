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
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine(restaurant._nomRestaurant);
                Console.WriteLine("******************************************");
                Console.WriteLine("Veuillez sélectionner une action à effectuer");
                Console.WriteLine("[1] Gestion des reservation");
                Console.WriteLine("[2] Gstion des tables");
                Console.WriteLine("[3] Gestion des des formules");
                Console.WriteLine("[4] Quitter le logiciel");

                int choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        Console.WriteLine("WIP");
                        break;
                    case 2:
                        Console.WriteLine("WIP");
                        break;
                    case 3:
                        Console.WriteLine("WIP");
                        break;
                    case 4:
                        quitteLogiciel = true;
                        break;
                    default:
                        Console.WriteLine("Erreur dans le choix");
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
    }
}
