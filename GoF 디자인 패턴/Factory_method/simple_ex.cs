using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimplePizzaFactory factory = new SimplePizzaFactory();
            PizzaStore store = new PizzaStore(factory);

            Pizza pizza = store.OrderPizza("cheese",7,"yes");
            Console.WriteLine( pizza.ToString() + "주문 완료\n");

            pizza = store.OrderPizza("pepperoni",8,"no");
            Console.WriteLine( pizza.ToString() + "주문 완료\n");
        }
    }
    public class PizzaStore
    {
        private readonly SimplePizzaFactory _factory;

        public PizzaStore(SimplePizzaFactory factory)
        {
            _factory = factory;
        }

        public Pizza OrderPizza(string type,int cnt, string yes_no)
        {
            Pizza pizza = _factory.CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut(cnt);
            pizza.Box(yes_no);
            pizza.ToString();

            return pizza;
        }
    }
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string item)
        {
            Pizza pizza = null;
            switch (item)
            {
                case "cheese":
                    pizza = new CheesePizza();
                    break;
                case "veggie":
                    pizza = new VeggiePizza();
                    break;
                case "pepperoni":
                    pizza = new PepperoniPizza();
                    break;
            }

            return pizza;
        }
    }
    public abstract class Pizza
    {
        public string Name { get; protected set; }
        public string Dough { get; protected set; }
        public string Sauce { get; protected set; }
        public List<string> Toppings { get; protected set; } = new List<string>();

        public virtual void Prepare()
        {
            Console.WriteLine(Name + "준비 중");
        }

        public virtual void Bake()
        {
            Console.WriteLine("350도 에서 25분 굽기");
        }

        public virtual void Cut(int cnt)
        {
            Console.WriteLine($"{cnt}등분");
        }

        public virtual void Box(string Y_N)
        {
            if (Y_N == "yes")
            {
                Console.WriteLine("포장 O");
            }
            else
            {
                Console.WriteLine("포장 X");
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("---- " + Name + " ----");
            result.AppendLine(Dough);
            result.AppendLine(Sauce);
            foreach (var topping in Toppings)
            {
                result.AppendLine(topping);
            }

            return result.ToString();
        }
    }
    public class CheesePizza : Pizza
    {
        public CheesePizza()
        {
            Name = "Cheese Pizza";
            Dough = "Regular Crust";
            Sauce = "Marinara Pizza Sauce";

            Toppings.Add("Fresh Mozzarella");
            Toppings.Add("Parmesan");
        }
    }
    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza()
        {
            Name = "Pepperoni Pizza";
            Dough = "Crust";
            Sauce = "Marinara sauce";

            Toppings.Add("Sliced Pepperoni");
            Toppings.Add("Sliced Onion");
            Toppings.Add("Grated parmesan cheese");
        }
    }
    public class VeggiePizza : Pizza
    {
        public VeggiePizza()
        {
            Name = "Veggie Pizza";
            Dough = "Crust";
            Sauce = "Marinara sauce";

            Toppings.Add("Shredded mozzarella");
            Toppings.Add("Grated parmesan");
            Toppings.Add("Diced onion");
            Toppings.Add("Sliced red pepper");
            Toppings.Add("Sliced black olives");
        }
    }
}
