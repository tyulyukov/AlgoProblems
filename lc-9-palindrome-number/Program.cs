// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.IsPalindrome(-121));
Console.WriteLine(s.IsPalindrome(11));
Console.WriteLine(s.IsPalindrome(10));
Console.WriteLine(s.IsPalindrome(1001));
Console.WriteLine(s.IsPalindrome(102301));
Console.WriteLine(s.IsPalindrome(121));
Console.WriteLine(s.IsPalindrome(123));

public class Solution {
    public bool IsPalindrome(int x)
    {
        switch (x)
        {
            case < 0:
                return false;
            case < 10:
                return true;
        }

        if (x < 100)
        {
            var last = x % 10;
            var first = x / 10;
            return first == last;
        }
        
        var digits = (int)Math.Ceiling(Math.Log10(x));
        var remains = digits;
        var number = x;

        for (int i = 0; i < digits / 2; i++)
        {
            var first = (int)(number / Math.Pow(10, remains - 1));
            var last = number % 10;

            if (first != last)
                return false;

            number -= first * (int)Math.Pow(10, remains - 1);
            number -= last;
            remains -= 2;
        }

        return true;
    }

    public bool IsPalindrome2(int x)
    {
        switch (x)
        {
            case < 0:
                return false;
            case < 10:
                return true;
        }
        
        var result = 0;
        var number = x;

        while (number > 0)
        {
            result = result * 10 + number % 10;
            number /= 10;
        }

        return result == x;
    }
}