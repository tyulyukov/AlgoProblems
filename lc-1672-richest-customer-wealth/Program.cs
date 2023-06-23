// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public int MaximumWealth(int[][] accounts)
    {
        var maxWealth = 0;
        var curWealth = 0;

        for (var i = 0; i < accounts.Length; i++)
        {
            for (var j = 0; j < accounts[i].Length; j++)
            {
                curWealth += accounts[i][j];
            }

            if (maxWealth < curWealth)
                maxWealth = curWealth;
            
            curWealth = 0;
        }

        return maxWealth;
    }
}