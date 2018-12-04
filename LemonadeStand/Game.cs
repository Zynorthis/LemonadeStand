using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        public int dayCounter;
        public double netProfit;
        public double dailyProfit;
        public double startMoney;
        public double yesterdayStartValue;
        public string errorMessage;
        public double lemonadePrice;
        public int salesCounter;
        public double netLoss;
        public Weather weather;
        public Player player;
        public Store store;
        public List<int> recipeList = new List<int>() { 0, 0, 0 };
        public List<Customer> customerList = new List<Customer>();

        public Game(int dayCounter, double netProfit, double dailyProfit, double startMoney, double yesterdayStartValue, string errorMessage)
        {
            this.netProfit = netProfit;
            this.dailyProfit = dailyProfit;
            this.dayCounter = dayCounter;
            this.startMoney = startMoney;
            this.yesterdayStartValue = yesterdayStartValue;
            this.errorMessage = errorMessage;
        }

        public Player Setup()
        {
            dayCounter++;
            player = new Player(0, "none");
            weather = new Weather("none", "none", 0, 0);
            store = new Store(0,0);
            player.money = startMoney;
            weather.Forcast();
            weather.SetActualWeather();
            return player;
        }

        public void InitializeDay(Player player, Inventory inventory)
        {
            if (yesterdayStartValue == 0)
            {
                yesterdayStartValue = 20.00;
            }
            GUI.BeginningReport(weather, player, inventory, dayCounter, netProfit);
            Console.WriteLine("\n" + "Press any key to continue.");
            Console.ReadLine();
            GUI.MainMenu(errorMessage);
            int userInput = player.IntInputTest();
            switch (userInput)
            {
                case 1: // displays all information that the player needs about weather/inventory/
                    InitializeDay(player, inventory);
                    break;
                case 2: // allows player to buy items from the store
                    store.StoreMainMenu(player, inventory);
                    store.Confirmation(player, inventory);
                    InitializeDay(player, inventory);
                    break;
                case 3: // allows player to set a recipe for how much ingrediants they want to use per pitcher of lemonade
                    RecipeSetup(inventory, player);
                    GUI.RecipeConfirmation(inventory);
                    string playerInput = player.StringInputTest();
                    if (playerInput == "yes")
                    {
                        Console.Clear();
                        Console.WriteLine("Recipe Set!");
                        Console.ReadLine();
                        InitializeDay(player, inventory);
                    }
                    else if (playerInput == "no")
                    {
                        Console.Clear();
                        Console.WriteLine("Recipe Setup Cancelled.");
                        Console.ReadLine();
                        InitializeDay(player, inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(errorMessage + "Recipe Setup Cancelled.");
                        Console.ReadLine();
                        Console.ResetColor();
                        InitializeDay(player, inventory);
                    }
                    break;
                case 4: // goes through a day of sales at the stand!
                    DayLoop(inventory, weather);
                    break;
                default:
                    Console.WriteLine(errorMessage + "Please try again");
                    InitializeDay(player, inventory);
                    break;
            }
        }

        public void RecipeSetup(Inventory inventory, Player player)
        {
            int i = 0;
            while (i <= 3)
            {
                i++;
                string itemReference;
                int userInput;
                switch (i)
                {
                    case 1:
                        itemReference = "lemons";
                        GUI.RecipeScreen(inventory, itemReference);
                        userInput = player.IntInputTest();
                        if (inventory.lemons < userInput || inventory.lemons == 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You don't have enough lemons to make even 1 pitcher!");
                            Console.WriteLine("You will have 0 per pitcher being added.");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else
                        {
                            recipeList[0] = userInput;
                        }
                        break;
                    case 2:
                        itemReference = "ice cubes";
                        GUI.RecipeScreen(inventory, itemReference);
                        userInput = player.IntInputTest();
                        if (inventory.iceCubes < userInput || inventory.iceCubes == 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You don't have enough ice cubes to make even 1 pitcher!");
                            Console.WriteLine("You will have 0 per pitcher being added.");
                            Console.ReadLine();
                            Console.ResetColor();
                        }
                        else
                        {
                            recipeList[1] = userInput;
                        }
                        break;
                    case 3:
                        itemReference = "sugar";
                        GUI.RecipeScreen(inventory, itemReference);
                        userInput = player.IntInputTest();
                        if (inventory.sugar < userInput || inventory.sugar == 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You don't have enough sugar to make even 1 pitcher!");
                            Console.WriteLine("You will have 0 per pitcher being added.");
                            Console.ReadLine();
                            Console.ResetColor();
                        }
                        else
                        {
                            recipeList[2] = userInput;
                        }
                        break;
                }
            }
        }

        public void DayLoop(Inventory inventory, Weather weather)
        {
            // loop each customer object through a sales calculation that determines if they buy lemonade or not
            Console.Clear();
            Console.WriteLine("How much would you like to sell each cup for?");
            lemonadePrice = player.DoubleInputTest();
            if (lemonadePrice == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage + "Please enter in a valid price");
                Console.ReadLine();
                Console.ResetColor();
                InitializeDay(player, inventory);
            }
            else if (recipeList[0] == 0 || recipeList[1] == 0 || recipeList[2] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage + "one or more ingrediants are not set.");
                Console.ReadLine();
                Console.ResetColor();
                DayLoop(inventory, weather);
            }
            else
            {
                Random rngCustomerCount = new Random();
                int customerCount = 0;
                if (weather.actualWeather == "Sunny" || weather.actualWeather == "Partly Cloudy")
                {
                    customerCount = rngCustomerCount.Next(50, 101);
                }
                else if (weather.actualWeather == "Cloudy" || weather.actualWeather == "Foggy")
                {
                    customerCount = rngCustomerCount.Next(30, 86);
                }
                while (customerCount >= customerList.Count)
                {
                    // building list of customers that will be check if they want to buy lemonade
                    Customer customer = new Customer(0, 0);
                    customer.Creation(weather);
                    customerList.Add(customer);
                }
                foreach (var item in customerList)
                {
                    if (item.maxExpectedPrice <= lemonadePrice)
                    {
                        salesCounter++;
                    }
                    else
                    {
                        if (salesCounter >= 15)
                        {
                            Random rngSaleOverride = new Random();
                            int SaleOverride = rngSaleOverride.Next(1, 101);
                            System.Threading.Thread.Sleep(20);
                            if (SaleOverride <= item.temptation)
                            {
                                salesCounter++;
                            }
                        }
                    }
                }
                // math below is calculating the netLoss based on ingrediants used during the day
                var pitchersMade = Math.Floor((Convert.ToDecimal(salesCounter)) / 10);
                double lemonsUsed;
                double iceCubesUsed;
                double sugarUsed;
                lemonsUsed = (recipeList[0] * Convert.ToInt32(pitchersMade));
                iceCubesUsed = (recipeList[1] * Convert.ToInt32(pitchersMade));
                sugarUsed = (recipeList[2] * Convert.ToInt32(pitchersMade));
                netLoss = ((lemonsUsed * 0.25) + (Convert.ToDouble(Math.Floor((Convert.ToDecimal(iceCubesUsed)) / 50)) * 0.50) + (sugarUsed * 0.20));
                netProfit = ((salesCounter * lemonadePrice) - netLoss);

                GUI.EndOfDayReport(inventory, salesCounter, lemonadePrice, netLoss);
                Console.WriteLine("\n" + "Press any key to continue.");
                Console.ReadLine();
            }
            dayCounter++;
            InitializeDay(player, inventory);
        }
    }
}