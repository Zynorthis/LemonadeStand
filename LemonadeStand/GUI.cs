using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class GUI
    {
        public static string[,] startReportUI; // report at the start of a day
        public static string[,] storeUI; // store interface
        public static string[,] endReportUI; // end of the day report (game over will be a cw after this!) netProfit, dailyProfit, yesterdayStartValue
        public static string[,] purchaseUI;
        public static string[,] confirmationUI;


        public static void BeginningReport(Weather weather, Player player, Inventory inventory, int dayCounter, double netProfit)
        {
            Console.Clear();
            startReportUI = new string[,] {
                { "|-------------------------------------------|" },
                { "  Day: " + Convert.ToString(dayCounter) },
                { "|-------------------------------------------|" },
                { "  Today's Weather: " + weather.actualWeather + " " + Convert.ToString(weather.actualTemperature) + " " + "°F" },
                { "  Tomorrow's Weather: " + weather.forcastWeather + " " + Convert.ToString(weather.forcastTemperature) + " " + "°F" },
                { "      Current Money: $" + player.money},
                { "      Day to Day Profit: $" + netProfit},
                { "      Net Profit: $" + (player.money - 20)},
                { "|-------------------------------------------|" },
                { "  Inventory" },
                { "      Lemons: " + inventory.lemons},
                { "      Ice Cubes: " + inventory.iceCubes},
                { "      Sugar: " + inventory.sugar},
                { "      Cups: " + inventory.cups},
                { "|-------------------------------------------|" }
            };
            foreach (var item in startReportUI)
            {
                Console.WriteLine(item);
            }
        }

        public static void MainMenu(string errorMessage)
        {
            string mainMenu; 

            Console.Clear();
            // this was another idea I have done in the past to print "GUI" elements to a console
            // which can be slightly simpler to pull off (imo) but doesn't offer as much control overall.
            mainMenu = "|-------------------------------------------| \n";
            mainMenu += "  What would you like to do? \n";
            mainMenu += "\n";
            mainMenu += "   1) Display Today's Info. \n";
            mainMenu += "   2) Go to the store. \n";
            mainMenu += "   3) Setup the recipe for your lemonade. \n";
            mainMenu += "   4) Open the stand up for buisness! \n";
            mainMenu += "|-------------------------------------------|";

            Console.WriteLine(mainMenu);
        }

        public static void StoreGUI(Inventory inventory, Player player, double[] prices)
        {
            Console.Clear();
            storeUI = new string[,] {
                { "|-------------------------------------------|" },
                { "                    Store                    " },
                { "|-------------------------------------------|" },
                { "  Current Money: $" + player.money},
                { "  Inventory" },
                { "      Lemons: " + inventory.lemons},
                { "      Ice Cubes: " + inventory.iceCubes},
                { "      Sugar: " + inventory.sugar},
                { "      Cups: " + inventory.cups},
                { "|-------------------------------------------|" },
                { " Item             Quantity             Price " },
                { " Lemons............." + "1................." + "(" + prices[0] + ")"},
                { " Ice Cubes.........." + "50................" + "(" + prices[1] + ")"},
                { " Sugar.............." + "1................." + "(" + prices[2] + ")"},
                { " Cups..............." + "100..............." + "(" + prices[3] + ")"},
                { "|-------------------------------------------|" },
                { "\n" },
                { "What would you like to buy?" }
            };
            foreach (var item in storeUI)
            {
                Console.WriteLine(item);
            }
        }

        public static void PurchaseMenu(string itemString)
        {
            Console.Clear();
            purchaseUI = new string[,]
            {
                { "|-------------------------------------------|" },
                { "                 Check Out                   " },
                { "|-------------------------------------------|" },
                { "    How many " + itemString + " would you like to buy?    " },
                { "|-------------------------------------------|" }
            };
            foreach (var item in purchaseUI)
            {
                Console.WriteLine(item);
            }
        }

        public static void ConfirmationScreen(int UserInput, double subTotal)
        {
            Console.Clear();
            confirmationUI = new string[,]
            {
                { "|-------------------------------------------|" },
                { "                 Check Out                   " },
                { "|-------------------------------------------|" },
                { "    You are about to buy " + UserInput + " for " + subTotal + "."  },
                { "              Is this correct?               " },
                { "|-------------------------------------------|" }
            };
            foreach (var item in confirmationUI)
            {
                Console.WriteLine(item);
            }
        }

        public static void RecipeScreen(Inventory inventory, string currentItem)
        {
            Console.Clear();
            string recipeMenu;

            recipeMenu = "|-------------------------------------------| \n";
            recipeMenu += "     1 Pitcher = 10 glasses of Lemonade \n";
            recipeMenu += "|-------------------------------------------| \n";
            recipeMenu += "                Recipe Setup\n";
            recipeMenu += "|-------------------------------------------| \n";
            recipeMenu += " Current Inventory: \n";
            recipeMenu += "      Lemons - " + inventory.lemons + "\n";
            recipeMenu += "      Ice Cubes - " + inventory.iceCubes + "\n";
            recipeMenu += "      Sugar - " + inventory.sugar + "\n";
            recipeMenu += "      Cups - " + inventory.cups + "\n";
            recipeMenu += "|-------------------------------------------| \n";
            recipeMenu += " \n";
            recipeMenu += " How many " + currentItem + " would you like to use (per pitcher)? \n";

            Console.WriteLine(recipeMenu);
        }

        public static void RecipeConfirmation(Inventory inventory)
        {
            Console.Clear();
            string recipeConfirmScreen;

            recipeConfirmScreen = "|-------------------------------------------| \n";
            recipeConfirmScreen += "            Recipe Confirmation \n";
            recipeConfirmScreen += "|-------------------------------------------| \n";
            recipeConfirmScreen += "  You Currently have:\n";
            recipeConfirmScreen += "       Lemons - " + inventory.lemons + "\n";
            recipeConfirmScreen += "       Ice Cubes - " + inventory.iceCubes + "\n";
            recipeConfirmScreen += "       Sugar - " + inventory.sugar + "\n";
            recipeConfirmScreen += "  being added per pitcher of lemonade. \n";
            recipeConfirmScreen += "|-------------------------------------------| \n";
            recipeConfirmScreen += "           Is this what you want? \n";
            recipeConfirmScreen += "|-------------------------------------------| \n";

            Console.WriteLine(recipeConfirmScreen);
        }
        public static void EndOfDayReport(Inventory inventory, int salesCounter, double lemonadePrice, double netLoss)
        {
            Console.Clear();
            endReportUI = new string[,]
            {
                { "|-------------------------------------------|" },
                { "              End of Day Report              " },
                { "|-------------------------------------------|" },
                { "  Lemonade sold: " + salesCounter },
                { "  Profit made/lost today: " + ((salesCounter * lemonadePrice) - netLoss) },
                { "|-------------------------------------------|" }
            };
            foreach (var item in endReportUI)
            {
                Console.WriteLine(item);
            }
        }
    }
}
