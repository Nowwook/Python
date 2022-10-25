using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern_3
{
    internal class Ingredients
    {
    }
    public interface ICheese
    {
        string ToString();
    }
    public interface IClams
    {
        string ToString();
    }
    public interface IDough
    {
        string ToString();
    }
    public interface IPepperoni
    {
        string ToString();
    }
    public interface ISauce
    {
        string ToString();
    }
    public interface IVeggies
    {
        string ToString();
    }
    public class MarinaraSauce : ISauce
    {
        string ISauce.ToString()
        {
            return "Marinara Sauce";
        }
    }
    public class Eggplant : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Eggplant";
        }
    }
    public class FreshClams : IClams
    {
        string IClams.ToString()
        {
            return "Fresh Clams from Long Island Sound";
        }
    }
    public class MozzarellaCheese : ICheese
    {
        string ICheese.ToString()
        {
            return "MozzarellaCheese";
        }
    }
    public class Onion : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Onion";
        }
    }
    public class SlicedPepperoni : IPepperoni
    {
        string IPepperoni.ToString()
        {
            return "Sliced Pepperoni";
        }
    }
    public class ThinCrustDough : IDough
    {
        string IDough.ToString()
        {
            return "Thin Crust Dough";
        }
    }
    public class PlumTomatoSauce : ISauce
    {
        string ISauce.ToString()
        {
            return "Tomato sauce with plum tomatoes";
        }
    }
    public class ThickCrustDough : IDough
    {
        string IDough.ToString()
        {
            return "ThickCrust style extra thick crust dough";
        }
    }
    public class Spinach : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Spinach";
        }
    }
    public class ReggianoCheese : ICheese
    {
        string ICheese.ToString()
        {
            return "Reggiano Cheese";
        }
    }
    public class Garlic : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Garlic";
        }
    }
    public class RedPepper : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Red Pepper";
        }

    }
}
