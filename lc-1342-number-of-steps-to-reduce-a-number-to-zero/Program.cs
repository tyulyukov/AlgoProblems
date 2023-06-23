var s = new Solution();
Console.WriteLine(s.NumberOfSteps(123));

public class Solution {
    public int NumberOfSteps(int num)
    {
        var steps = 0;

        while (num is not 0)
        {
            if (num % 2 == 0)
                num /= 2;
            else
                num -= 1;

            steps++;
        }

        return steps;
    }
}