var s = new Solution();
Console.WriteLine(s.IsPalindrome("A man, a plan, a canal: Panama"));

public class Solution
{ 
    public bool IsPalindrome(string s) {
        var span = s.AsSpan();
        
        var leftPointer = 0;
        var rightPointer = span.Length - 1;

        while (leftPointer < rightPointer) {
            while (!char.IsLetterOrDigit(span[leftPointer]) && leftPointer < span.Length && leftPointer < rightPointer) 
                leftPointer++; 
            
            while (!char.IsLetterOrDigit(span[rightPointer]) && rightPointer >= 0 && leftPointer < rightPointer) 
                rightPointer--;

            if (char.ToLower(span[leftPointer]) != char.ToLower(span[rightPointer])) 
                return false;
            
            leftPointer++;
            rightPointer--;
        }

        return true;
    }
    
    public bool IsPalindrome2(string s)
    {
        var chars = new List<char>(s.Length);

        foreach (var c in s.AsSpan())
        {
            if (char.IsLetterOrDigit(c))
                chars.Add(char.ToLower(c));
        }
        
        for (var i = 0; i < chars.Count / 2; i++)
        {
            if (chars[i] != chars[chars.Count - i - 1])
                return false;
        }

        return true;
    }
}