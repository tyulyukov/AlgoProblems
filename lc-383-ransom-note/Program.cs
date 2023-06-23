// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var letters = ransomNote.AsSpan();
        var constructLetters = magazine.AsSpan();
        Span<bool> takenIndexes = stackalloc bool[constructLetters.Length];

        foreach (var letter in letters)
        {
            var hasLetter = false;
            for (var i = 0; i < constructLetters.Length; i++)
            {
                if (takenIndexes[i])
                    continue;

                if (constructLetters[i] != letter) 
                    continue;
                
                takenIndexes[i] = true;
                hasLetter = true;
                break;
            }

            if (!hasLetter)
                return false;
        }

        return true;
    }
}