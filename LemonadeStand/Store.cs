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

        public void StoreMainMenu(Player player, Inventory inventory)
        {
            prices = new double[4];
                prices[0] = 0.25; // Lemon
                prices[1] = 0.50; // Ice Cubes
                prices[2] = 0.20; // Sugar
                prices[3] = 0.50; // Cups

            GUI.StoreGUI(inventory, player, prices);
            string userInput = player.StringInputTest();
            switch (userInput)
            {
                case "lemons":
                    currentSelectedItem = "lemons";
                    GUI.PurchaseMenu(currentSelectedItem);
                    storeUserInput = player.IntInputTest();
                    StoreCalculations(storeUserInput, prices[0], player);
                    break;
                case "ice cubes":
                    currentSelectedItem = "ice cubes (x50)";
                    GUI.PurchaseMenu(currentSelectedItem);
                    storeUserInput = player.IntInputTest();
                    StoreCalculations(storeUserInput, prices[1], player);
                    break;
                case "sugar":
                    currentSelectedItem = "sugar";
                    GUI.PurchaseMenu(currentSelectedItem);
                    storeUserInput = player.IntInputTest();
                    StoreCalculations(storeUserInput, prices[2], player);
                    break;
                case "cups":
                    currentSelectedItem = "cups (x100)";
                    GUI.PurchaseMenu(currentSelectedItem);
                    storeUserInput = player.IntInputTest();
                    StoreCalculations(storeUserInput, prices[3], player);
                    break;
                case "bananna":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("BANANNA IS NO INGREDIANT ON MY LIST NEVIN!");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid option, check spelling and please try again");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
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
                                case "ice cubes (x50)":
                                    inventory.iceCubes = (inventory.iceCubes + (storeUserInput * 50));
                                    break;
                                case "sugar":
                                    inventory.sugar = (inventory.sugar + storeUserInput);
                                    break;
                                case "cups (x100)":
                                    inventory.cups = (inventory.cups + (storeUserInput * 100));
                                    break;
                                default:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error, Failed to add items to players inventory. Please try again.");
                                    Console.ResetColor();
                                    Console.ReadKey();
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
                            Console.ReadKey();
                            StoreMainMenu(player, inventory);
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error, Invalid Input, check spelling and try again.");
                            Console.ResetColor();
                            Console.ReadKey();
                            StoreMainMenu(player, inventory);
                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, invalid input (Expected Input: String). Please try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
        public double StoreCalculations(int storeUserInput, double itemPrice, Player player)
        {
            if ((storeUserInput * itemPrice) > player.money)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have enough money to cover the expenses");
                Console.ResetColor();
                Console.ReadKey();
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
