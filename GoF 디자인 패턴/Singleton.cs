using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2번 호출
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            // 2번 다 같은 _instance 호출
            if (s1 == s2)
            {
                Console.WriteLine("같다");
            }
            else
            {
                Console.WriteLine("다르다");
            }
        }
    }
    public class Singleton
    {
        // 객체 선언 못 하게
        private Singleton() { }
        private static Singleton _instance;

        // 
        private static readonly object _lock = new object();

        // _instance 를 사용할 수 있는 method 를 만든다
        public static Singleton GetInstance()
        {
            // Thread in safe
            if(_instance == null)
            {
                lock(_lock)
                {
                    _instance = new Singleton();
                }
            }
            return _instance;
        }
    }
}
