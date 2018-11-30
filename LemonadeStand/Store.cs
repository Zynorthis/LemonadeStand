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
        public int storeUserInput;


        public Store(double subTotal, int storeUserInput)
        {
            this.subTotal = subTotal;
            this.storeUserInput = storeUserInput;
        }

        public double StoreMainMenu(Player player, Inventory inventory)
        {
            double subTotal = 0;
            prices = new double[4];
                prices[0] = .25; // Lemon
                prices[1] = .5; // Ice Cubes
                prices[2] = .20; // Sugar
                prices[3] = .50; // Cups

            GUI.StoreGUI(inventory, player, prices);
            switch (Console.ReadLine().ToLower())
            {
                case "lemons":
                    string x = "lemons";
                    GUI.PurchaseMenu(x);
                    storeUserInput = player.InputTest();
                    StoreCalculations(storeUserInput, prices[0], player);
                    return subTotal;
                case "ice cubes":
                    string y = "ice cubes";
                    GUI.PurchaseMenu(y);
                    storeUserInput = player.InputTest();
                    StoreCalculations(storeUserInput, prices[1], player);
                    return subTotal;
                case "sugar":
                    string z = "sugar";
                    GUI.PurchaseMenu(z);
                    storeUserInput = player.InputTest();
                    StoreCalculations(storeUserInput, prices[2], player);
                    return subTotal;
                case "cups":
                    string a = "cups";
                    GUI.PurchaseMenu(a);
                    storeUserInput = player.InputTest();
                    StoreCalculations(storeUserInput, prices[3], player);
                    return subTotal;
                case "bananna":
                    Console.WriteLine("BANANNA IS NO INGREDIANT ON MY LIST NEVIN!");
                    Console.ReadLine();
                    return 0;
                default:
                    Console.WriteLine("That is not a valid option, check spelling and please try again");
                    Console.ReadLine();
                    return 0;
            }
        }
        public void Confirmation(Player player, Inventory inventory) {
            if (storeUserInput == 0)
            {
                StoreMainMenu(player, inventory);
            }
            else
            {
                GUI.ConfirmationScreen(storeUserInput, subTotal);
                switch (Console.ReadLine().ToLower())
                {
                    case "yes":
                        player.money = (player.money - subTotal);
                        inventory.
                        break;
                    case "no":
                        Console.Clear();
                        StoreMainMenu(player, inventory);
                        break;
                    case "bananna":
                        Console.Clear();
                        Console.WriteLine("You can stop with all the banannas now...");
                        Console.ReadLine();
                        StoreMainMenu(player, inventory);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Error, Invalid Input, check spelling and try again.");
                        Console.ReadLine();
                        StoreMainMenu(player, inventory);
                        break;
                }
            }
        }
        public double StoreCalculations(int storeUserInput, double itemPrice, Player player)
        {
            if ((storeUserInput * itemPrice) > player.money)
            {
                Console.Clear();
                Console.WriteLine("You don't have enough money to cover the expenses");
                Console.ReadLine();
                subTotal = 0;
                return subTotal;
            }
            else
            {
                subTotal = (storeUserInput * itemPrice);
                return subTotal;
            }
        }
    }
}
