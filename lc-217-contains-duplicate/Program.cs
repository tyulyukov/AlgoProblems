// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int> { nums[0] };

        for (int i = 1; i < nums.Length; i++)
        {
            var contains = set.Add(nums[i]);
            if (!contains) return true;
        }

        return false;
    }
    
    public bool ContainsDuplicate3(int[] nums)
    {
        var dictionary = new Dictionary<int, bool>();
        
        dictionary.Add(nums[0], false);
        
        for (int i = 1; i < nums.Length; i++)
        {
            if (dictionary.ContainsKey(nums[i]))
                return true;
            
            dictionary.Add(nums[i], false);
        }

        return false;
    }
    
    public bool ContainsDuplicate2(int[] nums)
    {
        var set = nums.ToHashSet();
        return set.Count != nums.Length;
    }
}