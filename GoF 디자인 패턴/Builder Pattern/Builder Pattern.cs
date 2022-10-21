using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderSimple_ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car builder;
            Shop shop = new Shop();

            builder = new Avantte();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new Granger();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new Sonata();
            shop.Construct(builder);
            builder.Vehicle.Show();
        }
    }

    // Director
    class Shop
    {
        public void Construct(Car vehicleBuilder)
        {
            vehicleBuilder.Engine();
            vehicleBuilder.Mission();
            vehicleBuilder.Wheels();
            vehicleBuilder.Turbo();
        }
    }

    // 상속용 클래스, Builder
    abstract class Car
    {
        // 자식 클래스만 접근, 빌더
        // 
        protected Vehicle vehicle;

        // 프로퍼티
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }
        // 상속용
        public abstract void Engine();
        public abstract void Mission();
        public abstract void Wheels();
        public abstract void Turbo();
    }

    // 결과, 출력용
    class Vehicle
    {
        // 이름, 사양   접근한정
        private string name;
        private Dictionary<string, string> cars = new Dictionary<string, string>();

        // 이름 프로퍼티
        public Vehicle(string name) { this.name = name; }
        // 사양 프로퍼티
        public string this[string key]
        {
            get { return cars[key]; }
            set { cars[key] = value; }
        }

        // 출력
        public void Show()
        {
            Console.WriteLine("\n");
            Console.WriteLine(" Name    : {0}", name);
            Console.WriteLine(" Engine  : {0}", cars["Engine"]);
            Console.WriteLine(" Wheels  : {0}", cars["Wheels"]);
            Console.WriteLine(" Mission : {0}", cars["Mission"]);
            Console.WriteLine(" Turbo   : {0}", cars["Turbo"]);
        }
    }

    // 종류
    class Avantte : Car
    {
        public Avantte()
        {
            vehicle = new Vehicle("Avantte");
        }
        public override void Engine()
        {
            vehicle["Engine"] = "A Type";
        }
        public override void Mission()
        {
            vehicle["Mission"] = "자동";
        }
        public override void Wheels()
        {
            vehicle["Wheels"] = "한국";
        }
        public override void Turbo()
        {
            vehicle["Turbo"] = "유";
        }
    }
    class Granger : Car
    {
        public Granger()
        {
            vehicle = new Vehicle("Granger");
        }
        public override void Engine()
        {
            vehicle["Engine"] = "B Type";
        }
        public override void Mission()
        {
            vehicle["Mission"] = "자동";
        }
        public override void Wheels()
        {
            vehicle["Wheels"] = "금호";
        }
        public override void Turbo()
        {
            vehicle["Turbo"] = "무";
        }
    }
    class Sonata : Car
    {
        public Sonata()
        {
            vehicle = new Vehicle("Sonata");
        }
        public override void Engine()
        {
            vehicle["Engine"] = "A Type";
        }
        public override void Mission()
        {
            vehicle["Mission"] = "수동";
        }
        public override void Wheels()
        {
            vehicle["Wheels"] = "미쉐린";
        }
        public override void Turbo()
        {
            vehicle["Turbo"] = "무";
        }
    }
}
