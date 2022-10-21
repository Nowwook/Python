using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderSimple_ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HouseBuilder house;
            Shop shop = new Shop();

            house = new Park_A();
            shop.Option(house);
            house.House.Show();
        }
    }
}
