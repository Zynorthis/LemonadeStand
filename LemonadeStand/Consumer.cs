﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Consumer
    {
        public double maxExpectedPrice;
        public double temptation;

        public Consumer(double maxExpectedPrice, double temptation)
        {
            this.maxExpectedPrice = maxExpectedPrice;
            this.temptation = temptation;
        }

        public abstract void Creation(Weather weather);
    }
}
