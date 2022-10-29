using System;

public class Solution {
    public int[] solution(int denum1, int num1, int denum2, int num2) {
        int[] answer = new int[2] ;
        int a, b, r;
        
        if (num1 >= num2)
        {
            a = num1;
            b = num2;
        }
        else
        {
            a = num2;
            b = num1;
        }
        while (true)
        {
            r = a % b;
            a = b;
            b = r;
            if (r == 0) break;
        }
        answer[1] = num1 * num2 / a;
        answer[0] = denum1 * answer[1] / num1 + denum2 * answer[1] / num2;
        return answer;
    }
}
