// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.LongestPalindrome("babad"));
Console.WriteLine(s.LongestPalindrome("a"));
Console.WriteLine(s.LongestPalindrome("ac"));
Console.WriteLine(s.LongestPalindrome("abcdadsfaABABA"));

public class Solution {
    public string LongestPalindrome(string s)
    {
        var longest = ReadOnlySpan<char>.Empty;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 1; j <= s.Length - i; j++)
            {
                var substring = j == s.Length - i ? s.AsSpan(i) : s.AsSpan(i, j);
                
                if (IsPalindrome(substring) && longest.Length < substring.Length)
                    longest = substring;
            }
        }

        return longest.ToString();
    }

    private bool IsPalindrome(ReadOnlySpan<char> s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }

        return true;
    }
}