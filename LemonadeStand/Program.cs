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
            Game gameObject = new Game();
            gameObject.Setup();
            gameObject.InitializeDay();
        }
    }
}
