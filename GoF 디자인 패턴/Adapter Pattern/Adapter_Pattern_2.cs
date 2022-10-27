using System;

namespace Adapter_Pattern_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit un = new Unit();
            un.Move();
            Console.WriteLine();

            List<NewUnit> List_Unit = new List<NewUnit>();
            List_Unit.Add(new NewUnit());  // 신규 유닛
            List_Unit.Add(new Unit());     // 기존 유닛
            
            foreach (NewUnit newUnit in List_Unit)
            {
                // 같은 소스로 제어가능
                newUnit.Move();
                newUnit.Stop();
            }
        }
    }
    // 어뎁티(기존객체) 클래스
    class OldUnit
    {
        public void MoveToPoint()
        {
            Console.WriteLine("-걷기");
        }

        public void StopMove()
        {
            Console.WriteLine("-천천히 멈추기");
        }
    }
    // 타겟 클래스
    class NewUnit
    {
        public virtual void Move()
        {
            Console.WriteLine("+달리기");
        }

        public virtual void Stop()
        {
            Console.WriteLine("+바로 멈추기");
        }
    }

    // 어뎁터클래스
    class Unit : NewUnit
    {
        private OldUnit _adaptee = new OldUnit();

        public override void Move()
        {
            _adaptee.MoveToPoint();
        }

        public override void Stop()
        {
            _adaptee.StopMove();
        }
    }
}
