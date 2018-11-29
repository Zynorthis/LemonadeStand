using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public int lemons;
        public int sugar;
        public int iceCubes;
        public int cups;

        public Inventory(int lemons, int sugar, int iceCubes, int cups)
        {
            this.lemons = lemons;
            this.sugar = sugar;
            this.iceCubes = iceCubes;
            this.cups = cups;
        }
    }
    
}
