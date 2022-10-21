using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderSimple_ex3
{
    class Shop
    {
        public void Option(HouseBuilder option)
        {
            option.Garage();
            option.SwimmingPool();
            option.Windows();
            option.Garden();
        }
    }
}
