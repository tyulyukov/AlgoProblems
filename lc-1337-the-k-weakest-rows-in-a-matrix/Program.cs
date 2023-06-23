// See https://aka.ms/new-console-template for more information

var s = new Solution();
Array.ForEach(s.KWeakestRows(new[]
{
    new[]{ 1,1,0,0,0 },  
    new[]{ 1,1,1,1,0 },  
    new[]{ 1,0,0,0,0 }, 
    new[]{ 1,1,0,0,0 },  
    new[]{ 1,1,1,1,1 }
}, 3), Console.WriteLine);
Console.WriteLine();
Array.ForEach(s.KWeakestRows(new[]
{
    new[]{ 1,0,0,0 },  
    new[]{ 1,1,1,1 },  
    new[]{ 1,0,0,0 }, 
    new[]{ 1,0,0,0 }
}, 2), Console.WriteLine);
Console.WriteLine();
Array.ForEach(s.KWeakestRows(new[]
{
    new[]{ 1,1,1,1,1,1 },  
    new[]{ 1,1,1,1,1,1 },  
    new[]{ 1,1,1,1,1,1 }
}, 1), Console.WriteLine);
Console.WriteLine();
Array.ForEach(s.KWeakestRows(new[]
{
    new[]{ 1,0 },  
    new[]{ 1,0 },  
    new[]{ 1,0 },  
    new[]{ 1,1 }
}, 4), Console.WriteLine);


public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) {
        // here i use 0 index as the sum of the soldiers and 1 index as the index in the main array
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 1; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 1)
                {
                    mat[i][0]++;
                }
                else
                {
                    mat[i][1] = i;
                    break;
                }
                
                if (j == 1)
                    mat[i][1] = i;
            }
        }

        var result = new int[k];
        
        for (int i = 0; i < k; i++)
        {
            var min = mat[i][0];
            var indexOfMin = i;
            
            for (int j = i; j < mat.Length; j++)
            {
                if (mat[j][0] < min)
                {
                    min = mat[j][0];
                    indexOfMin = j;
                }
            }
            
            if (i != indexOfMin)
            {
                var temp = mat[i];
                mat[i] = mat[indexOfMin];

                for (int j = indexOfMin - 1; j > i; j--)
                {
                    mat[j + 1] = mat[j];
                }

                mat[i + 1] = temp;
            }
            

            result[i] = mat[i][1];
        }

        return result;
    }
}