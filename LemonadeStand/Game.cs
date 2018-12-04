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
        public Weather weather;
        public Player player;
        public Store store;
        public Customer customer;
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
            customer = new Customer(0, 0);
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
            GUI.BeginningReport(weather, player, inventory, dayCounter, yesterdayStartValue);
            int userInput = GUI.MainMenu(errorMessage, player);
            switch (userInput)
            {
                case 1: // displays all information that the player needs about weather/inventory/
                    GUI.BeginningReport(weather, player, inventory, dayCounter, yesterdayStartValue);
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
                    string playerInput = Console.ReadLine().ToLower();
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
                    DayLoop(inventory, customer, weather);
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
                        userInput = player.InputTest();
                        if (inventory.lemons < userInput)
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
                        userInput = player.InputTest();
                        if (inventory.lemons < userInput)
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
                        userInput = player.InputTest();
                        if (inventory.lemons < userInput)
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

        public void DayLoop(Inventory inventory, Customer customer, Weather weather)
        {
            // loop each customer object through a sales calculation that determines if they buy lemonade or not
            Console.Clear();
            Console.WriteLine("How much would you like to sell each cup for?");
            lemonadePrice = player.InputTest();
            if (lemonadePrice == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage + "Please enter in a valid price");
                Console.ReadLine();
                Console.ResetColor();
                DayLoop(inventory, customer, weather);
            }
            else
            {
                customer.Creation(weather);
            }
        }
    }
}