using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method_pattern_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.OrderPizza("cheese",8);
            Console.WriteLine("Ethan 커스텀 내역 \n" + pizza + "\n");

            pizza = chicagoStore.OrderPizza("cheese",4);
            Console.WriteLine("Joel 커스텀 내역 \n" + pizza + "\n");

            pizza = nyStore.OrderPizza("clam",6);
            Console.WriteLine("Ethan 커스텀 내역 \n" + pizza + "\n");

            pizza = chicagoStore.OrderPizza("clam",7);
            Console.WriteLine("Joel 커스텀 내역 \n" + pizza + "\n");

            pizza = nyStore.OrderPizza("pepperoni",10);
            Console.WriteLine("Ethan 커스텀 내역 \n" + pizza + "\n");

            pizza = chicagoStore.OrderPizza("pepperoni",100);
            Console.WriteLine("Joel 커스텀 내역 \n" + pizza + "\n");

            pizza = nyStore.OrderPizza("veggie",2);
            Console.WriteLine("Ethan 커스텀 내역 \n" + pizza + "\n");

            pizza = chicagoStore.OrderPizza("veggie",1);
            Console.WriteLine("Joel 커스텀 내역 \n" + pizza + "\n");
        }
    }
}
