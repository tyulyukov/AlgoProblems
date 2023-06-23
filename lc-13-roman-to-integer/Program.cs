var s = new Solution();
Console.WriteLine(s.RomanToInt("XIII"));
Console.WriteLine(s.RomanToInt("XIX"));
Console.WriteLine(s.RomanToInt("MCMXCIV"));

public class Solution
{
    private readonly Dictionary<char, int> _romanSymbols = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 },
    };

    public int RomanToInt(string s)
    {
        Span<int> values = stackalloc int[s.Length];
        var prev = _romanSymbols[s[0]];
        var result = 0;

        for (var i = 1; i < values.Length; i++)
        {
            if (i > 1)
                prev = values[i - 1];
            
            var curr = values[i] = _romanSymbols[s[i]];
            result += prev < curr ? -prev : prev;
        }

        result += _romanSymbols[s[values.Length - 1]];

        return result;
    }
    
    public int RomanToInt2(string s)
    {
        Span<int> values = stackalloc int[s.Length];
        for (var i = 0; i < values.Length; i++)
        {
            values[i] = _romanSymbols[s[i]];
        }
        
        var result = 0;
        
        for (var i = 0; i < values.Length; i++)
        {
            var curr = values[i];
            var next = s.Length == i + 1 ? 0 : values[i + 1];
            result += curr < next ? -curr : curr;
        }

        return result;
    }
}