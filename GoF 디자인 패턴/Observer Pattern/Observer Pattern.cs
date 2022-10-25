using System;
using System.Collections.Generic;

namespace Observer_Pattern
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
            // 옵저버 목록에서 삭제
            // Es.draw();
        }
    }
    public interface Observer
    {
        // title, news 값이 변경시 update 함수에서 감지하여 동작
        void update(String title, String news);
    }
    public interface Publisher
    {
        void add(Observer observer);        // 메세지 전달할 옵저버 추가
        void delete(Observer observer);     // 메세지 전달할 옵저버 삭제
        void notifyObserver();              // 옵저버에게 전달
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
        // 옵저버에 전달 받으면 실행(출력)
        public void update(String title, String news)
        {
            newsString = "-\t" + title + "\n-\t" + news;
            display();
        }
        public void draw()
        {
            publisher.delete(this);
        }
        public void display()
        {
            Console.WriteLine("\n\t이벤트 유저\n============================");
            Console.WriteLine( newsString+"\n");
        }
    }
    // 대상 클래스 : 대상 인터페이스를 구현한 클래스
    public class NewsMachine : Publisher
    {
        private List<Observer> observers;
        private String title;
        private String news;

        public NewsMachine()
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
        public void notifyObserver()                // 관리중인 옵저버에게 전달
        {
            foreach (Observer observer in observers)
            {
                observer.update(title, news);
            }
        }
        // 옵저버에 전달 
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
