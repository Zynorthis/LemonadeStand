using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GUI
    {
        public static string[,] startReportUI; // report at the start of a day
        public static string[,] storeUI; // store interface
        public static string[,] endReportUI; // end of the day report (game over will be a cw after this!) netProfit, dailyProfit, yesterdayStartValue

        public static void BeginningReport(Weather weather, Game gameObject, Player player, Inventory inventory)
        {
            Console.Clear();
            startReportUI = new string[,] {
                { "|-------------------------------------------|" },
                { "  Day: " + Convert.ToString(gameObject.dayCounter) },
                { "|-------------------------------------------|" },
                { "  Today's Weather: " + weather.actualWeather + " " + Convert.ToString(weather.actualTemperature) + " " + "°F" },
                { "  Tomorrow's Weather: " + weather.forcastWeather + " " + Convert.ToString(weather.forcastTemperature) + " " + "°F" },
                { "      Current Money: $" + player.money},
                { "      Day to Day Profit: $" + (gameObject.yesterdayStartValue - player.money)},
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
            Console.ReadLine();
        }

        public static int MainMenu(Game gameObject)
        {
            string mainMenu;

            Console.Clear();

            mainMenu = "|-------------------------------------------| \n";
            mainMenu += "  What would you like to do? \n";
            mainMenu += "\n";
            mainMenu += "   1) Display Today's Info. \n";
            mainMenu += "   2) Go to the store. \n";
            mainMenu += "   3) Open the stand up for buisness! \n";
            mainMenu += "|-------------------------------------------|";

            Console.WriteLine(mainMenu);
            int userInput = 1;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine(gameObject.errorMessage + "Please enter 1, 2, or 3 (Not Bananna...)");
            }
            
            return userInput;
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
                { " Lemons............." + "100..............." + "(" + prices[0] + ")"},
                { " Ice Cubes.........." + "100..............." + "(" + prices[1] + ")"},
                { " Sugar.............." + "100..............." + "(" + prices[2] + ")"},
                { " Cups..............." + "100..............." + "(" + prices[3] + ")"},
                { "|-------------------------------------------|" },
            };
            foreach (var item in storeUI)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
