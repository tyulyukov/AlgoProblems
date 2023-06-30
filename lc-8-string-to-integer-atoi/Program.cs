// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.MyAtoi("123"));
Console.WriteLine(s.MyAtoi("      -123"));
Console.WriteLine(s.MyAtoi("4193 with words"));
Console.WriteLine(s.MyAtoi("2147483648"));
Console.WriteLine(s.MyAtoi("2147483647"));
Console.WriteLine(s.MyAtoi("2147483646"));

public class Solution
{
    public int MyAtoi(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;
        
        var i = 0;
        while (s[i] == ' ')
            i++;

        var coefficient = 1;

        switch (s[i])
        {
            case '-':
                coefficient = -1;
                i++;
                break;
            case '+':
                i++;
                break;
        }

        int result = 0;
        while (i < s.Length)
        {
            if (s[i] < '0' || s[i] > '9')
                break;

            var num = s[i] - 48;
            
            if ((int.MaxValue - num) / 10 < result)
                return coefficient == 1 ? int.MaxValue : int.MinValue;
            
            result *= 10;
            result += num;
            i++;
        }

        return result * coefficient;
    }
}