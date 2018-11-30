using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        public static double[] prices;
        public double subTotal;
        
        public Store(double[] prices, double subTotal)
        {
            this.subTotal = subTotal;
        }

        public static void StoreMainMenu(Player player, Inventory inventory)
        {
            double subTotal = 0;
            double[] prices = new double[4];
                prices[0] = .25; // Lemon
                prices[1] = .5; // Ice Cubes
                prices[2] = .20; // Sugar
                prices[3] = .50; // Cups

            Store store = new Store(prices, subTotal);
            GUI.StoreGUI(inventory, player, prices);
            int userInput;
            switch (Console.ReadLine())
            {
                case "lemons":
                    string x = "lemons";
                    GUI.PurchaseMenu(x);
                    userInput = player.InputTest();
                    store.StoreCalculations(userInput, prices[0], player);
                    break;
                case "ice cubes":
                    string y = "ice cubes";
                    GUI.PurchaseMenu(y);
                    userInput = player.InputTest();
                    store.StoreCalculations(userInput, prices[0], player);
                    break;
                case "sugar":
                    string z = "sugar";
                    GUI.PurchaseMenu(z);
                    userInput = player.InputTest();
                    store.StoreCalculations(userInput, prices[0], player);
                    break;
                case "cups":
                    string a = "cups";
                    GUI.PurchaseMenu(a);
                    userInput = player.InputTest();
                    store.StoreCalculations(userInput, prices[0], player);
                    break;
                case "bananna":
                    Console.WriteLine("BANANNA IS NO INGREDIANT ON MY LIST NEVIN!");
                    StoreMainMenu(player, inventory);
                    break;
                default:
                    Console.WriteLine("That is not a valid option, check spelling and please try again");
                    StoreMainMenu(player, inventory);
                    break;
            }
            //GUI.ConfirmationScreen(userInput);
        }

        public double StoreCalculations(int userInput, double itemPrice, Player player)
        {
            if ((userInput * itemPrice) > player.money)
            {
                Console.WriteLine("You don't have enough money to cover the expenses");
                return subTotal = 0;
            }
            else
            {
                subTotal = (userInput * itemPrice);
                return subTotal;
            }
        }
    }
}
