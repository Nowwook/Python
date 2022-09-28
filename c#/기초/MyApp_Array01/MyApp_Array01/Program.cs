using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_Array01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int product1 = 1;
            int product2 = 2;
            int product3 = 3;
            int product4 = 4;
            int product5 = 5;

            int[] product = new int[5]; //배열선언
            /*
            product[0] = 1;
            product[1] = 2;
            product[2] = 3;
            product[3] = 4;
            product[4] = 5;
            
            Console.WriteLine(product[0]);
            */
            for (int i = 0; i < 5; i++)
            {
                product[i] = i+1;  // 메모리
                Console.WriteLine(product[i]); //출력
            }
            int[] products = new int[3];

            products[0] = 100;
            products[1] = 200;

            int book = products[0];
            int sum = products[0] + products[1];

            Console.WriteLine(sum);
            ///////////
            int[] cats = new int[5] {1,2,3,4,5}; // 직접 선언 가능
            Console.WriteLine(cats[4]);

        }
    }
}
