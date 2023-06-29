// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using lc_7_reverse_integer;

BenchmarkRunner.Run<IDontBelieveInThisSolution>();
return;

var s = new Solution();
Console.WriteLine(s.Reverse(321));
Console.WriteLine(s.Reverse(120));
Console.WriteLine(s.Reverse(1534236469));

public class Solution {
    public int Reverse(int x)
    {
        if (x is 0)
            return x;
        
        var isUnsigned = x < 0;

        if (isUnsigned)
            x *= -1;
        
        while (x % 10 == 0)
            x /= 10;

        var result = 0;

        while (x > 0)
        {
            var prev = result;
            result *= 10;
            result += x % 10;

            // if the result was bigger than int.MaxValue after operation upper, it would shift
            if ((result - x % 10) / 10 != prev)
                return 0;
            
            x /= 10;
        }

        if (isUnsigned)
            result *= -1;
        
        return result;
    }
}