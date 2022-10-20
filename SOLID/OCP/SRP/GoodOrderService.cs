using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_SRP_1
{
    public class GoodOrderService
    {
        private String name;
        // 생성자
        // 디폴트 생성자
        public string CreateOrder(string Order)
        {
            System.Console.WriteLine("좋은 예");
            string order = Order;

            return order;
        }
    }
}
