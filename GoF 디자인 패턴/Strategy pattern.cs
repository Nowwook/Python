using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_pattern
{
    public class StrategyPattern
    {
        // 전략 패턴
        // 실행중 가격변경
        public static void Main(String[] args)
        {
            // Prepare strategies
            // 전략 준비
            var normalStrategy = new NormalStrategy();
            var happyHourStrategy = new HappyHourStrategy();

            // 손님1, 정가
            var firstCustomer = new CustomerBill(normalStrategy);
            firstCustomer.Add(1.0, 1);
            // 반값
            firstCustomer.Strategy = happyHourStrategy;
            firstCustomer.Add(1.0, 2);

            // 손님1 계산서
            firstCustomer.Print();


            // 손님2, 반값
            var secondCustomer = new CustomerBill(happyHourStrategy);
            secondCustomer.Add(0.8, 1);
            // 정가
            secondCustomer.Strategy = normalStrategy;
            secondCustomer.Add(1.3, 2);
            secondCustomer.Add(2.5, 1);

            // 손님2 계산서
            secondCustomer.Print();
        }
    }

    // 고객 청구서
    class CustomerBill
    {
        private IList<double> drinks;

        // Get/Set Strategy
        public IBillingStrategy Strategy { get; set; }
        public CustomerBill(IBillingStrategy strategy)
        {
            this.drinks = new List<double>();
            this.Strategy = strategy;
        }
        public void Add(double price, int quantity)
        {
            // 가격 * 수량
            this.drinks.Add(this.Strategy.GetActPrice(price * quantity));
        }
        // 계산서
        public void Print()
        {
            double sum = 0;
            foreach (var drinkCost in this.drinks)
            {
                sum += drinkCost;
            }
            Console.WriteLine($"총가격: {sum}.");
            this.drinks.Clear();
        }
    }
    interface IBillingStrategy
    {
        // 결제 전략, 얼마?
        double GetActPrice(double rawPrice);
    }
    // 정가
    class NormalStrategy : IBillingStrategy
    {
        public double GetActPrice(double rawPrice) => rawPrice;
    }
    // 반값
    class HappyHourStrategy : IBillingStrategy
    {
        public double GetActPrice(double rawPrice) => rawPrice * 0.5;
    }
}
