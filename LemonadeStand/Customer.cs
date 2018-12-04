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
                Console.WriteLine("(devTesting) ExpectedPriceRoll: " + priceRoll);
                System.Threading.Thread.Sleep(20);
                if (priceRoll >= 90)
                {
                    maxExpectedPrice = maxExpectedPrice - 0.10;
                }
                else if (priceRoll >= 70 && priceRoll < 90)
                {
                    maxExpectedPrice = maxExpectedPrice - 0.05;
                }
                else if (priceRoll >= 50 && priceRoll < 70)
                {
                    // (do nothing / keep the same)
                }
                else if (priceRoll >= 25 && priceRoll < 50)
                {
                    maxExpectedPrice = maxExpectedPrice + 0.05;
                }
                else if (priceRoll >= 0 && priceRoll < 25)
                {
                    maxExpectedPrice = maxExpectedPrice + 0.05;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something has gone horribly wrong: ExpectedPriceRoll Exception.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            else if (weather.actualTemperature < 72)
            {
                Random rngExpectedPrice = new Random();
                int priceRoll = rngExpectedPrice.Next(1, 101);
                Console.WriteLine("(devTesting) ExpectedPriceRoll: " + priceRoll);
                System.Threading.Thread.Sleep(20);
                if (priceRoll >= 90)
                {
                    maxExpectedPrice = maxExpectedPrice - 0.10;
                }
                else if (priceRoll >= 80 && priceRoll < 90)
                {
                    maxExpectedPrice = maxExpectedPrice - 0.05;
                }
                else if (priceRoll >= 65 && priceRoll < 80)
                {
                    // (do nothing / keep the same)
                }
                else if (priceRoll >= 45 && priceRoll < 65)
                {
                    maxExpectedPrice = maxExpectedPrice + 0.05;
                }
                else if (priceRoll >= 0 && priceRoll < 45)
                {
                    maxExpectedPrice = maxExpectedPrice + 0.10;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something has gone horribly wrong: ExpectedPriceRoll Exception.");
                    Console.ResetColor();
                    Console.ReadLine();
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
