using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ch = 'A';
            char ch1 = '\t'; // 4칸 띄우기
            char ch2 = '\n'; //엔터
            char ch3 = 'o';

            string str1 = "\tABC\n";

            Console.WriteLine(ch);
            Console.WriteLine(ch1);
            Console.WriteLine(ch2);
            Console.WriteLine(ch3);
            Console.WriteLine(str1);
        }
    }
}
