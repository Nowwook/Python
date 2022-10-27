using System;

namespace Decorator_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            Console.WriteLine("주문 1 " + beverage.Description + "\n$" + beverage.Cost() + "\n");

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine("주문 2 " + beverage2.Description + "\n$" + beverage2.Cost() + "\n");

            Beverage beverage3 = new HouseBlend();
            beverage3 = new Soy(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Whip(beverage3);
            Console.WriteLine("주문 3 " + beverage3.Description + "\n$" + beverage3.Cost() + "\n");
        }
    }
    public abstract class Beverage
    {
        public virtual string Description { get; protected set; } = "Unknown Beverage";

        public abstract double Cost();
    }
    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            Description = "Dark Roast Coffee";
        }

        public override double Cost()
        {
            return .99;
        }
    }
    public class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
        }

        public override double Cost()
        {
            return .89;
        }
    }
    public abstract class CondimentDecorator : Beverage
    {
        public abstract override string Description { get; }
    }
    public class Mocha : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string Description => _beverage.Description + "\tMocha";

        public override double Cost()
        {
            return .20 + _beverage.Cost();
        }
    }
    public class Soy : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return .15 + _beverage.Cost();
        }

        public override string Description => _beverage.Description + "\tSoy";
    }
    public class Whip : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return .10 + _beverage.Cost();
        }

        public override string Description => _beverage.Description + "\tWhip";
    }
}
