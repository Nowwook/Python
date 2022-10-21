using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderSimple_ex3
{
    abstract class HouseBuilder
    {
        // House
        protected House house;
        public House House
        {
            get { return house; }
        }

        public abstract void Garage();
        public abstract void SwimmingPool();
        public abstract void Windows();
        public abstract void Garden();
    }
}
