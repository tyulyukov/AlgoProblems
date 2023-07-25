// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.MyPow(2, -2147483648));

public class Solution {
    public double MyPow(double x, int n)
    {
        return n switch
        {
            0 => 1,
            < 0 => InternalPositivePow(1 / x, -(long)n),
            _ => InternalPositivePow(x, n)
        };
    }

    private static double InternalPositivePow(double x, long n)
    {
        if (n == 1) return x;
        var halfPow = InternalPositivePow(x, n / 2);
        return n % 2 == 0 ? halfPow * halfPow : halfPow * halfPow * x;
    }
}