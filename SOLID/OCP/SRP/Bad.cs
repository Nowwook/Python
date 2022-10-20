using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_SRP_1
{
    // SRP 단일 책임의 원칙
    public class BadOrderService
    {
        // 1 주문
        public void CreateOrder(string Order)
        {

        }
        // 2 지불
        public void Payment(string Order)
        {

        }
        // 3 송장 만들기
        public void Invoice(string Order)
        {

        }
        // 4 이메일
        public void Email(string Order)
        {

        }
    }
}
