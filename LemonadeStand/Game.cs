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
        Player player;
        Weather weather;
        Inventory inventory;
        public string errorMessage;

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
            Player player = new Player(0);
            weather = new Weather("none", "none", 0, 0, true);
            player.money = startMoney;
            weather.Forcast();
            weather.SetActualWeather();
            return player;
        }

        public void InitializeDay(Player player, Inventory inventory, Game gameObject)
        {
            if (gameObject.yesterdayStartValue == 0)
            {
                gameObject.yesterdayStartValue = 20.00;
            }
            GUI.BeginningReport(weather, gameObject, player, inventory);
            int userInput = GUI.MainMenu(gameObject);
            switch (userInput)
            {
                case 1:
                    GUI.BeginningReport(weather, gameObject, player, inventory);
                    InitializeDay(player, inventory, gameObject);
                    break;
                case 2:
                    Store.StoreMainMenu(player, inventory);
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine(errorMessage + "Please try again");
                    InitializeDay(player, inventory, gameObject);
                    break;
            }
        }
    }
}