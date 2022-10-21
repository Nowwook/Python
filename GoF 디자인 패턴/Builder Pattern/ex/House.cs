using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderSimple_ex3
{
    // 결과, 출력용
    class House
    {
        // 이름 접근한정, 프로퍼티
        private string name;
        public House(string name)
        {
            this.name = name;
        }

        // 옵션 접근한정, Dictionary 값으로 , 프로퍼티
        private Dictionary<string, string> houses = new Dictionary<string, string>();
        public string this[string key]
        {
            get { return houses[key]; }
            set { houses[key] = value; }
        }

        // 출력
        public void Show()
        {
            Console.WriteLine("Name         :{0}", name);
            Console.WriteLine("SwimmingPool :{0}", houses["S"]);
            Console.WriteLine("Windows      :{0}", houses["G"]);
            Console.WriteLine("Garden       :{0}", houses["W"]);
            Console.WriteLine("Garage       :{0}", houses["Garden"]);
            Console.WriteLine("\n");
        }
    }
}
