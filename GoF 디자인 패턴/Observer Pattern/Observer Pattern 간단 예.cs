using System;
using System.Collections.Generic;

namespace Observer_Pattern
{
    // 1~10 1씩 증가하면서 조건 만족시 전달
    internal class Program
    {
        static void Main(string[] args)
        {
            Count_ten ct = new Count_ten();

            Even ev = new Even(ct);
            ct.Cnt();
        }
    }
    public interface Observer
    {
        void update(int cnt);
    }
    public interface Publisher
    {
        void add(Observer observer);        // 메세지 전달할 옵저버 추가
        void delete(Observer observer);     // 메세지 전달할 옵저버 삭제
        void Go();                          // 옵저버에게 전달
    }
    public class Count_ten : Publisher
    {
        private List<Observer> observers;
        private int count;

        public Count_ten()
        {
            observers = new List<Observer>();       // 옵저버 관리 리스트
        }
        public void add(Observer observer)          // 관리할 옵저버 등록
        {
            observers.Add(observer);
        }
        public void delete(Observer observer)       // 관리할 옵저버 삭제
        {
            observers.Remove(observer);
        }
        public void Go()                            // 관리중인 옵저버에게 전달
        {
            foreach (Observer observer in observers)
            {
                observer.update(count);
            }
        }
        public void Cnt()                 // 옵저버 판단
        {
            for (int i = 0; i < 10; i++)
                if (i % 2 == 0)
                {
                    count = i;
                    Go();
                }
        }
    }
    public class Even : Observer
    {
        private int cnt;
        private Publisher publisher;

        public Even(Publisher publisher)
        {
            this.publisher = publisher;
            publisher.add(this);
        }
        public void update(int count)
        {
            Console.WriteLine(count);
        }
    }
}
