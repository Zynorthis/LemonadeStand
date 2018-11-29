using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        public static double[] prices;
        public double subTotal;
        
        public Store(double[] prices, double subTotal)
        {
            this.subTotal = subTotal;
        }

        public static void StoreMainMenu(Player player, Inventory inventory)
        {
            double subTotal = 0;
            double[] prices = new double[4];
                prices[0] = .25; // Lemon
                prices[1] = .5; // Ice Cubes
                prices[2] = .20; // Sugar
                prices[3] = .50; // Cups

            Store store = new Store(prices, subTotal);
            GUI.StoreGUI(inventory, player, prices);
        }
    }
}
