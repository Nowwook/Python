using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern_3
{
    internal class FactoryMethods
    {
    }
    public abstract class PizzaStore
    {
        protected abstract Pizza CreatePizza(string item);

        public Pizza OrderPizza(string type,int n)
        {
            Pizza pizza = CreatePizza(type);
            Console.WriteLine("--- " + pizza.Name + " ---\n");
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut(n);
            pizza.Box();
            return pizza;
        }
    }
    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string item)
        {
            Pizza pizza = null;
            IPizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientFactory();

            switch (item)
            {
                case "cheese":
                    pizza = new CheesePizza(ingredientFactory) { Name = "Chicago Style Cheese Pizza" };
                    break;
                case "veggie":
                    pizza = new VeggiePizza(ingredientFactory) { Name = "Chicago Style Veggie Pizza" };
                    break;
                case "clam":
                    pizza = new ClamPizza(ingredientFactory) { Name = "Chicago Style Clam Pizza" };
                    break;
                case "pepperoni":
                    pizza = new PepperoniPizza(ingredientFactory) { Name = "Chicago Style Pepperoni Pizza" };
                    break;
            }

            return pizza;
        }
    }
    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string item)
        {
            Pizza pizza = null;
            IPizzaIngredientFactory ingredientFactory = new NYPizzaIngredientFactory();

            switch (item)
            {
                case "cheese":
                    pizza = new CheesePizza(ingredientFactory) { Name = "New York Style Cheese Pizza" };
                    break;
                case "veggie":
                    pizza = new VeggiePizza(ingredientFactory) { Name = "New York Style Veggie Pizza" };
                    break;
                case "clam":
                    pizza = new ClamPizza(ingredientFactory) { Name = "New York Style Clam Pizza" };
                    break;
                case "pepperoni":
                    pizza = new PepperoniPizza(ingredientFactory) { Name = "New York Style Pepperoni Pizza" };
                    break;
            }

            return pizza;
        }
    }
}
