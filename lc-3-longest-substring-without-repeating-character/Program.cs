// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.LengthOfLongestSubstring("abcabcbb"));
Console.WriteLine(s.LengthOfLongestSubstring("bbbbbb"));
Console.WriteLine(s.LengthOfLongestSubstring("pwwkew"));
Console.WriteLine(s.LengthOfLongestSubstring("dvdf"));
Console.WriteLine(s.LengthOfLongestSubstring("au"));
Console.WriteLine(s.LengthOfLongestSubstring(""));
Console.WriteLine(s.LengthOfLongestSubstring(" "));

public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        var span = s.AsSpan();
        var length = 0;
        var lastRepeatedIndex = -1;

        if (s.Length is 0 or 1)
            return s.Length;

        for (int i = 1; i < span.Length; i++)
        {
            var current = 1;
            
            for (int j = lastRepeatedIndex + 1; j < i; j++)
            {
                if (span[i] == span[j])
                {
                    lastRepeatedIndex = j;
                    break;
                }

                current++;
            }

            if (current > length)
                length = current;
        }

        return length;
    }
}