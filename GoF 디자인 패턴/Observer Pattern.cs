using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewsMachine newsMachine = new NewsMachine();
            AnnualSubscriber As = new AnnualSubscriber(newsMachine);
            EventSubscriber Es = new EventSubscriber(newsMachine);

            newsMachine.setNewsInfo("오늘은 한파", "전국 영하 18도 입니다.");
            newsMachine.setNewsInfo("벛꽃 축제합니다", "다같이 벚꽃보러~");
        }
    }
    public interface Observer
    {
        void update(String title, String news);
    }
    public interface Publisher
    {
        void add(Observer observer);
        void delete(Observer observer);
        void notifyObserver();
    }
    public class AnnualSubscriber : Observer
    {
        private String newsString;
        private Publisher publisher;

        public AnnualSubscriber(Publisher publisher)
        {
            this.publisher = publisher;
            publisher.add(this);
        }
        public void update(String title, String news)
        {
            this.newsString = title + news;
            display();
        }

        private void display()
        {
            Console.WriteLine("\t오늘의 뉴스\n============================\n- " + newsString);
        }
    }
    public class EventSubscriber : Observer
    {
        private String newsString;
        private Publisher publisher;

        public EventSubscriber(Publisher publisher)
        {
            this.publisher = publisher;
            publisher.add(this);
        }
        public void update(String title, String news)
        {
            newsString = "-\t" + title + "\n-\t" + news;
            display();
        }

        public void display()
        {
            Console.WriteLine("\n\t이벤트 유저\n============================");
            Console.WriteLine( newsString+"\n");
        }
    }
    public class NewsMachine : Publisher
    {
        private List<Observer> observers;
        private String title;
        private String news;

        public NewsMachine()
        {
            observers = new List<Observer>();
        }
        public void add(Observer observer)
        {
            observers.Add(observer);
        }
        public void delete(Observer observer)
        {
            int index = observers.IndexOf(observer);
            observers.RemoveAt(index);
        }
        public void notifyObserver()
        {
            foreach (Observer observer in observers)
            {
                observer.update(title, news);
            }
        }

        public void setNewsInfo(String title, String news)
        {
            this.title = title;
            this.news = news;
            notifyObserver();
        }

        public String getTitle()
        {
            return title;
        }

        public String getNews()
        {
            return news;
        }
    }
}
