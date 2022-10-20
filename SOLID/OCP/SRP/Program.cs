using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_SRP_1
{
    internal class Program
    {
        // SRP
        static void Main(string[] args)
        {
            // Bad ex
            BadOrderService badOrder = new BadOrderService();
            badOrder.CreateOrder("1");

            // Good ex
            GoodOrderService goodOrder = new GoodOrderService();
            string s = goodOrder.CreateOrder("주문");
            System.Console.WriteLine(s);
            GoodPaymentService goodPayment = new GoodPaymentService();
            goodPayment.Payment("3");
        }
    }
}
