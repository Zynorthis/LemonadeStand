using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public double money;
        public string userInput;

        public Player(double money, string userInput)
        {
            this.money = money;
            this.userInput = userInput;
        }

        public int IntInputTest()
        {
            userInput = Console.ReadLine();
            int testedUserInput;
            try
            {
                testedUserInput = Convert.ToInt32(userInput);
                return testedUserInput;
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid Numarical Input: try again");
                Console.ResetColor();
                Console.ReadKey();
                return testedUserInput = 0;
            }
        }

        public double DoubleInputTest()
        {
            userInput = Console.ReadLine();
            double testedUserInput;
            try
            {
                testedUserInput = Convert.ToDouble(userInput);
                return testedUserInput;
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid Numarical Input: try again");
                Console.ResetColor();
                Console.ReadKey();
                return testedUserInput = 0;
            }
        }

        public string StringInputTest()
        {
            try
            {
                userInput = Console.ReadLine().ToLower();
                return userInput;
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid Text Input: try again");
                Console.ResetColor();
                Console.ReadKey();
                return userInput = "Error";
            }
        }
    }
}
