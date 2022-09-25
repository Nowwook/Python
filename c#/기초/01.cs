using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(); //줄 띄워서
            Console.Write("문자" + B); //줄 붙여서
            Console.WriteLine($"{A} * {B} = {A * B}"); //여러개
            Console.WriteLine("ㅁ{0,7:D}", "0번자리"); //0번째를 7칸 중에 뒤로 붙이기(-7 앞에 붙이기)
            Console.Write("{0,2:D},{1,2:D},{2,2:D}", "0번", "1번", "2번");

            /*
            F - 실수(F5 > 소숫점 5자리)
            D - 정수("{0:D}", 0xFF) == 255
            X - 16진수(아스키코드)("{0:X}", 255) = ("{0:X}", 0xFF) == FF
            N - 콤마삽입      100.000
            E - 지수("{0:E}", 1234.567) == 1.234567E+003)
            */

            string.Format("{0,-8}DEF", "ABC");              // ABC DEF

            string 이름 = "{0,-20}{1,-15}{2,30}";           // 0번째는 20칸 앞에부터
            Console.WriteLine(이름, "abcdef", "efgh", "asda");

            /*
            \t 탭 (4칸 띄우기)
            \n 다음 줄
            \s 빈공간
            \S 채워진 공간
            \r 그 줄 맨앞
            */

            while (true)     // 조건
            {
                // 반복 실행
            }

            // do while
            do 
            {
                // 반복 실행
            }
            while (true);   // 이 조건이면 반복


            // 스위치 문
            int a = 0;
            switch (a)      // 받은 값
            {
                case 1:
                    break;
                case 2:
                    break;
            }


            string day = "x요일";
            switch (day)
            {
                case "월요일":
                case "화요일":
                case "수요일":
                case "목요일":
                case "금요일":
                    Console.WriteLine("평일입니다.");
                    break;
                case "토요일":
                case "일요일":
                    Console.WriteLine("휴일입니다.");
                    break;
            }
        }
    }
}
