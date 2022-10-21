using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderSimple_ex3
{
    class Park_A : HouseBuilder
    {
        public Park_A()
        {
            house = new House("Park_A");
        }
        public override void Garage()
        {
            house["G"] = "yes";
        }
        public override void SwimmingPool()
        {
            house["S"] = "yes";
        }
        public override void Windows()
        {
            house["W"] = "6";
        }
        public override void Garden()
        {
            house["Garden"] = "yes";
        }
    }
}
