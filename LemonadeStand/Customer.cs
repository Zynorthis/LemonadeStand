using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer : Consumer
    {
        public Customer(double maxExpectedPrice, double temptation)
            :base(maxExpectedPrice, temptation)
        {
            this.maxExpectedPrice = maxExpectedPrice;
            this.temptation = temptation;
        }

        public override void Creation(Weather weather)
        {
            maxExpectedPrice = 0.25; // minimum price customer would by lemonade at
            temptation = 15.00; // percentage chance they will buy lemonade at even if over maxExpectedPrice

            if (weather.actualTemperature >= 72)
            {
                Random rngExpectedPrice = new Random();
                int priceRoll = rngExpectedPrice.Next(1,101);
                Console.WriteLine("(devTesting) ExpectedPriceRoll: " + rngExpectedPrice);
                if (priceRoll >= 50)
                {
                    maxExpectedPrice = maxExpectedPrice - 0.05;
                }
                else
                {
                    // (do nothing / keep the same)
                }
            }
            else if (weather.actualTemperature <= 65)
            {
                Random rngExpectedPrice = new Random();
                int priceRoll = rngExpectedPrice.Next(1, 101);
                Console.WriteLine("(devTesting) ExpectedPriceRoll: " + rngExpectedPrice);
                if (priceRoll >= 70)
                {
                    maxExpectedPrice = maxExpectedPrice - 0.05;
                }
                else
                {
                    maxExpectedPrice = maxExpectedPrice + 0.05;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something has gone horribly wrong: Could not alter Expected Minimum Price Value successfully.");
                Console.ResetColor();
                Console.ReadLine();
            }

            if (weather.actualWeather == "Sunny" || weather.actualWeather == "Partly Cloudy")
            {
                temptation = temptation + 5.00;
            }
            else if (weather.actualWeather == "Cloudy" || weather.actualWeather == "Foggy")
            {
                temptation = temptation - 5.00;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something has gone horribly wrong: Could not alter temptation successfully.");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}
