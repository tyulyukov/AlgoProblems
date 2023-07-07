// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.IsValid("()[]{}"));
Console.WriteLine(s.IsValid("(]"));
Console.WriteLine(s.IsValid("([)]"));
Console.WriteLine(s.IsValid("("));
Console.WriteLine(s.IsValid(")"));

public class Solution
{
    private readonly Dictionary<char, char> _brackets = new()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

    public bool IsValid(string s)
    {
        var expected = new Stack<char>(s.Length);

        for (int i = 0; i < s.Length; i++)
        {
            if (_brackets.TryGetValue(s[i], out var endingBracket))
            {
                 expected.Push(endingBracket);
            }
            else if (expected.Count == 0 || expected.Pop() != s[i])
            {
                return false;
            }
        }

        return expected.Count == 0;
    }
    
    public bool IsValid2(string s)
    {
        var parentheses = 0;
        var brackets = 0;
        var braces = 0;

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '(':
                {
                    parentheses++;
                    break;
                }
                case ')':
                {
                    parentheses--;
                    if (parentheses < 0)
                        return false;
                    
                    break;
                }
                case '[':
                {
                    brackets++;
                    break;
                }
                case ']':
                {
                    brackets--;
                    if (brackets < 0)
                        return false;

                    break;
                }
                case '{':
                {
                    braces++;
                    break;
                }
                case '}':
                {
                    braces--;
                    if (braces < 0)
                        return false;

                    break;
                }
            }
        }
        
        return brackets == 0 && braces == 0 && parentheses == 0;
    }
}