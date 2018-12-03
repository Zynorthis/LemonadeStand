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
        public string currentSelectedItem;


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
                    currentSelectedItem = "lemons";
                    GUI.PurchaseMenu(currentSelectedItem);
                    storeUserInput = player.InputTest();
                    StoreCalculations(storeUserInput, prices[0], player);
                    return subTotal;
                case "ice cubes":
                    currentSelectedItem = "ice cubes";
                    GUI.PurchaseMenu(currentSelectedItem);
                    storeUserInput = player.InputTest();
                    StoreCalculations(storeUserInput, prices[1], player);
                    return subTotal;
                case "sugar":
                    currentSelectedItem = "sugar";
                    GUI.PurchaseMenu(currentSelectedItem);
                    storeUserInput = player.InputTest();
                    StoreCalculations(storeUserInput, prices[2], player);
                    return subTotal;
                case "cups":
                    currentSelectedItem = "cups";
                    GUI.PurchaseMenu(currentSelectedItem);
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
                try {
                    switch (Console.ReadLine().ToLower())
                    {
                        case "yes":
                            player.money = (player.money - subTotal);
                            switch (currentSelectedItem)
                            {
                                case "lemons":
                                    inventory.lemons = (inventory.lemons + storeUserInput);
                                    break;
                                case "ice cubes":
                                    inventory.iceCubes = (inventory.iceCubes + storeUserInput);
                                    break;
                                case "sugar":
                                    inventory.sugar = (inventory.sugar + storeUserInput);
                                    break;
                                case "cups":
                                    inventory.cups = (inventory.cups + storeUserInput);
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Error, Failed to add items to players inventory. Please try again.");
                                    break;
                            }
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
                catch
                {
                    Console.WriteLine("Error, invalid input (Expected Input: String). Please try again.");
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
