// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.LongestPalindrome("babad"));
Console.WriteLine(s.LongestPalindrome("a"));
Console.WriteLine(s.LongestPalindrome("ac"));

public class Solution {
    public string LongestPalindrome(string s)
    {
        var span = s.AsSpan();

        if (span.Length is 0 or 1)
            return s;
        
        var longest = string.Empty;

        for (int i = 0; i < span.Length; i++)
        {
            for (int j = i + 1; j < span.Length - 1; j++)
            {
                var substring = s.Substring(i, j);
                if (IsPalindrome(substring) && longest.Length < substring.Length)
                    longest = substring;
            }
        }

        return longest;
    }

    // private ReadOnlySpan<char> Substring(ReadOnlySpan<char >)

    private bool IsPalindrome(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }

        return true;
    }
}