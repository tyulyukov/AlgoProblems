// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public int MaxProfit(int[] prices)
    {
        var minStock = prices[0];
        var maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            var profit = prices[i] - minStock;
            if (maxProfit < profit)
                maxProfit = profit;

            if (minStock > prices[i])
                minStock = prices[i];
        }

        return maxProfit;
    }
    
    public int MaxProfit2(int[] prices)
    {
        var maxProfit = 0;
        var lastMinPurchaseValue = int.MaxValue;
        
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < lastMinPurchaseValue)
                lastMinPurchaseValue = prices[i];
            else continue;
            
            for (int j = i + 1; j < prices.Length; j++)
            {
                var profit = prices[j] - prices[i];
                if (profit > maxProfit)
                    maxProfit = profit;
            }
        }

        return maxProfit;
    }
}