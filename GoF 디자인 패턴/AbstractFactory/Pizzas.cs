using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern_3
{
    public abstract class Pizza
    {
        public string Name { get; set; }

        public IDough Dough { get; protected set; }
        public ISauce Sauce { get; protected set; }
        public IVeggies[] Veggies { get; protected set; }
        public ICheese Cheese { get; protected set; }
        public IPepperoni Pepperoni { get; protected set; }
        public IClams Clam { get; protected set; }

        public abstract void Prepare();

        public virtual void Bake()
        {
            Console.WriteLine("350도 에서 25분 굽기");
        }

        public virtual void Cut(int n)
        {
            Console.WriteLine($"{n} 조각 Cutting");
        }

        public virtual void Box()
        {
            Console.WriteLine("박스 포장");
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("++");
            if (Dough != null)
            {
                result.AppendLine(Dough.ToString());
            }
            if (Sauce != null)
            {
                result.AppendLine(Sauce.ToString());
            }
            if (Cheese != null)
            {
                result.AppendLine(Cheese.ToString());
            }
            if (Veggies != null)
            {
                for (int i = 0; i < Veggies.Length; i++)
                {
                    result.Append(Veggies[i].ToString());
                    if (i < Veggies.Length - 1)
                    {
                        result.Append(", ");
                    }
                }
                result.Append("\n");
            }
            if (Clam != null)
            {
                result.AppendLine(Clam.ToString());
            }
            if (Pepperoni != null)
            {
                result.AppendLine(Pepperoni.ToString());
            }

            return result.ToString();
        }
    }
    public class CheesePizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
        }
    }
    public class ClamPizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public ClamPizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
            Clam = _ingredientFactory.CreateClam();
        }
    }
    public class PepperoniPizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
            Veggies = _ingredientFactory.CreateVeggies();
            Pepperoni = _ingredientFactory.CreatePepperoni();
        }
    }
    public class VeggiePizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
            Veggies = _ingredientFactory.CreateVeggies();
        }
    }
}
