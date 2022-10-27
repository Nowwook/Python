using System;

namespace Adapter_Pattern_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WildTurkey turkey = new WildTurkey();
            Console.WriteLine("칠면조는 ");
            turkey.Gobble();
            turkey.Fly();

            MallardDuck duck = new MallardDuck();
            Console.WriteLine("\n오리는 ");
            duck.Quack();
            duck.Fly();



            IDuck turkeyAdapter = new TurkeyAdapter(turkey);
            Console.WriteLine("\n칠면조 어댑터는 ");
            turkeyAdapter.Quack();
            turkeyAdapter.Fly();

            Console.WriteLine();

            ITurkey duckAdapter = new DuckAdapter(duck);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("오리 어댑터는 ");
                duckAdapter.Gobble();
                duckAdapter.Fly();
            }
        }
    }
    
    public interface ITurkey
    {
        void Gobble();
        void Fly();
    }
    public class WildTurkey : ITurkey
    {
        public void Gobble()
        {
            Console.WriteLine("칠칠 면조면조");
        }

        public void Fly()
        {
            Console.WriteLine("짧게 날아 다님");
        }
    }
    public interface IDuck
    {
        void Quack();
        void Fly();
    }
    public class MallardDuck : IDuck
    {
        public void Quack()
        {
            Console.WriteLine("꽥");
        }

        public void Fly()
        {
            Console.WriteLine("멀리 날아 다님");
        }
    }
    public class TurkeyAdapter : IDuck //target interface
    {
        //adaptee interface
        private readonly ITurkey _turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            _turkey = turkey;
        }

        public void Quack()
        {
            _turkey.Gobble();
        }

        public void Fly()
        {
            for (int i = 0; i < 2; i++)
            {
                _turkey.Fly();
            }
        }
    }
    public class DuckAdapter : ITurkey //target interface
    {
        //adaptee interface
        private readonly IDuck _duck;
        private readonly Random _random;

        public DuckAdapter(IDuck duck)
        {
            _duck = duck;
            _random = new Random();
        }

        public void Gobble()
        {
            _duck.Quack();
        }

        public void Fly()
        {
            // 0~2 랜덤중 0일때
            if (_random.Next(3) == 0)
            {
                _duck.Fly();
            }
        }
    }
}
