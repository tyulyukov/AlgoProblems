// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.ThreeSum(new[] { 3, 0, -2, -1, 1, 2 }).Count);
Console.WriteLine(s.ThreeSum(new[] { 0, 0, 0 }).Count);

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var threesums = new List<IList<int>>();
        Array.Sort(nums);

        var start = 0;

        while (start < nums.Length - 2)
        {
            var target = nums[start] * -1;
            var left = start + 1;
            var right = nums.Length - 1;

            while (left < right)
                if (nums[left] + nums[right] > target)
                {
                    --right;
                }
                else if (nums[left] + nums[right] < target)
                {
                    ++left;
                }
                else
                {
                    var arr = new[] { nums[start], nums[left], nums[right] };
                    var triplet = new List<int>(arr);
                    threesums.Add(triplet);

                    while (left < right && nums[left] == triplet[1])
                        ++left;
                    
                    while (left < right && nums[right] == triplet[2])
                        --right;
                }

            var currentStartNumber = nums[start];
            while (start < nums.Length - 2 && nums[start] == currentStartNumber)
                ++start;
        }

        return threesums;
    }
}