using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Consumer
    {
        public double minExpectedPrice;
        public double temptation;

        public Consumer(double minExpectedPrice, double temptation)
        {
            this.minExpectedPrice = minExpectedPrice;
            this.temptation = temptation;
        }

        public abstract void Creation(Weather weather);
    }
}
