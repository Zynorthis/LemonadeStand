using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        int dayCounter;
        Player player;
        Weather weather;

//        public Game(int dayCounter, Player player, Weather weather)
//        {
//            this.dayCounter = dayCounter;
//            this.player = player;
//            this.weather = weather;
//        }

        public void Setup()
        {
            dayCounter++;
            Player player = new Player(0);
            Weather weather = new Weather("none", "none", 0, 0, true);
            player.money += 20.00;
            weather.Forcast();
            weather.SetActualWeather();
        }

        public void InitializeDay()
        {
            // do the loop for the day
        }
    }
}
