// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(s.FindMedianSortedArrays(new[] { 1, 2 }, new [] { 3 }));
Console.WriteLine(s.FindMedianSortedArrays(new[] { 1, 2 }, new [] { 3, 4 }));

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var mergedLength = nums1.Length + nums2.Length;

        int i = 0, j = 0, k = 0;
        
        var center = mergedLength / 2;
        int prevNum = 0, addedNum = 0;

        for (; k <= center && i < nums1.Length && j < nums2.Length; k++)
        {
            prevNum = addedNum;
            if (nums1[i] < nums2[j])
            {
                addedNum = nums1[i];
                i++;
            }
            else
            {
                addedNum = nums2[j];
                j++;
            }
        }

        for (; k <= center && i < nums1.Length; k++)
        {
            prevNum = addedNum;
            addedNum = nums1[i];
            i++;
        }

        for (; k <= center && j < nums2.Length; k++)
        {
            prevNum = addedNum;
            addedNum = nums2[j];
            j++;
        }
        
        GC.Collect();

        if (mergedLength % 2 != 0)
            return addedNum;
        
        return (prevNum + addedNum) / 2.0;
    }
    
    public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
    {
        var span1 = nums1.AsSpan();
        var span2 = nums2.AsSpan();
        var mergedLength = nums1.Length + nums2.Length;

        int i = 0, j = 0;
        
        var center = mergedLength / 2;
        int prevNum = 0, addedNum = 0;

        for (int k = 0; k <= center; k++)
        {
            int? num1 = null;
            int? num2 = null;
            
            if (i < span1.Length)
                num1 = span1[i];

            if (j < span2.Length)
                num2 = span2[j];

            prevNum = addedNum;
            if (num1 < num2 || (num1 is not null && num2 is null))
            {
                i++;
                addedNum = num1.Value;
            }
            else if (num1 >= num2 || (num2 is not null && num1 is null))
            {
                j++;
                addedNum = num2.Value;
            }
        }
        
        GC.Collect();

        var hasCenter = mergedLength % 2 != 0;
        
        if (hasCenter)
            return addedNum;
        
        return (prevNum + addedNum) / 2.0;
    }
    
    public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
    {
        var span1 = nums1.AsSpan();
        var span2 = nums2.AsSpan();
        var mergedLength = nums1.Length + nums2.Length;

        int i = 0, j = 0, k = 1;
        
        var center = Convert.ToInt32(Math.Ceiling(mergedLength / 2.0));
        var hasCenter = mergedLength % 2 != 0;
        var addedNum = 0;
        
        while (true)
        {
            int? num1 = null;
            int? num2 = null;
            
            if (i < span1.Length)
                num1 = span1[i];

            if (j < span2.Length)
                num2 = span2[j];

            var prevNum = addedNum;
            if (num1 < num2 || (num1 is not null && num2 is null))
            {
                i++;
                addedNum = num1.Value;
            }
            else
            {
                j++;
                addedNum = num2.Value;
            }

            switch (hasCenter)
            {
                case true when center == k:
                    GC.Collect();
                    return addedNum;
                case false when center + 1 == k:
                    GC.Collect();
                    return (prevNum + addedNum) / 2.0;
            }

            k++;
        }
    }
}