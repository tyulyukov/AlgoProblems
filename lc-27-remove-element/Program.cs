// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public int RemoveElement(int[] nums, int val)
    {
        var num = 0;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] == val)
            {
                for (int j = i; j < nums.Length - 1; j++)
                {
                    nums[j] = nums[j + 1];
                }
            }
            else num++;
        }

        return num;
    }
    
    public int RemoveElementBest(int[] nums, int val)
    {
        var num = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val) continue;
            
            nums[num] = nums[i];
            num++;
        }
        return num;
    }
}