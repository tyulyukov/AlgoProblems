// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++)
        {
            var num = target - nums[i];

            for (int j = i + 1; j < nums.Length; j++)
            {
                if (num == nums[j])
                    return new[] { i, j };
            }
        }

        return null!;
    }
}