using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public string forcastWeather; // weather is the type of day (ex. Sunny, Cloudy, Windy)
        public string actualWeather;
        public int forcastTemperature; // Temperature refers to the actual degree it is that day
        public int actualTemperature;

        public Weather(string forcastWeather, string actualWeather, int forcastTemperature, int actualTemperature)
        {
            this.forcastWeather = forcastWeather;
            this.actualWeather = actualWeather;
            this.forcastTemperature = forcastTemperature;
            this.actualTemperature = actualTemperature;
        }

        public void Forcast()
        {
            // decides weather type for the day
            Random rngWeather = new Random();
            int weatherRoll = rngWeather.Next(1, 5);
            Console.WriteLine("(devTesting) Weather Roll: " + weatherRoll);
            switch (weatherRoll)
            {
                case 1:
                    forcastWeather = "Sunny";
                    break;
                case 2:
                    forcastWeather = "Partly Cloudy";
                    break;
                case 3:
                    forcastWeather = "Cloudy";
                    break;
                case 4:
                    forcastWeather = "Foggy";
                    break;
                default:
                    Console.WriteLine("Something Went Horribly Wrong...");
                    Console.WriteLine("Invalid Weather Roll");
                    Forcast();
                    break;
            }

            // decides the temperature for the day
            if (forcastWeather == "Sunny" || forcastWeather == "Partly Cloudy")
            {
                Random rngHotTemperature = new Random();
                int temperatureRoll = rngHotTemperature.Next(75, 96);
                Console.WriteLine("(devTesting) Temperature Roll: " + temperatureRoll);
                forcastTemperature = temperatureRoll;
            }
            else if (forcastWeather == "Cloudy" || forcastWeather == "Foggy")
            {
                Random rngColdTemperature = new Random();
                int temperatureRoll = rngColdTemperature.Next(55, 75);
                Console.WriteLine("(devTesting) Temperature Roll: " + temperatureRoll);
                forcastTemperature = temperatureRoll;
            }
            else
            {
                Console.WriteLine("Something Went Horribly Wrong...");
                Console.WriteLine("Invalid Temperature");
                Forcast();
            }
        }

        public void SetActualWeather()
        {
            actualWeather = forcastWeather;
            actualTemperature = forcastTemperature;
            System.Threading.Thread.Sleep(20);
            Forcast();
        }
    }
}
