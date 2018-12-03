using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer : Consumer
    {
        public Customer(double minExpectedPrice, double temptation)
            :base(minExpectedPrice, temptation)
        {
            this.minExpectedPrice = minExpectedPrice;
            this.temptation = temptation;
        }

        public override void Creation(Weather weather)
        {
            // creation logic here
            minExpectedPrice = 0.25;
            temptation = 15.00;

            if (weather.actualTemperature >= 72)
            {
                // roll a check to raise minExpectedPrice
            }
            else if (weather.actualTemperature <= 65)
            {
                // roll a check to lower minExpectedPrice
            }
            else
            {
                // do nothing
            }

            if (weather.actualWeather == "Sunny" || weather.actualWeather == "Partly Cloudy")
            {
                temptation = temptation + 10.00;
            }
            else if (weather.actualWeather == "Cloudy" || weather.actualWeather == "Foggy")
            {
                temptation = temptation - 5.00;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something has gone horribly wrong: Could not alter temptation successfully.");
                Console.ReadLine();
            }
        }
    }
}
