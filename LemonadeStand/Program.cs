using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game gameObject = new Game(0, 0, 0, 20, 0, "Error, Invalid Input: ");
            Inventory inventory = new Inventory(0, 0, 0, 0);
            Player player = gameObject.Setup();
            gameObject.InitializeDay(player, inventory);
        }
    }
}
