// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        n--;
        for (; n >= 0; n--)
        {
            nums1[m + n] = nums2[n];
        }
        
        Array.Sort(nums1);
    }
}