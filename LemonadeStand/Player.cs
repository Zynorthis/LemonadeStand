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

        public int InputTest()
        {
            string userInput = Console.ReadLine();
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
                Console.WriteLine("Error: Invalid Input: try again");
                Console.ResetColor();
                Console.ReadLine();
                return testedUserInput = 0;
            }
        }
    }
}
