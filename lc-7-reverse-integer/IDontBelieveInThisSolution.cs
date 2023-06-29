using BenchmarkDotNet.Attributes;

namespace lc_7_reverse_integer;

[MemoryDiagnoser(false)]
public class IDontBelieveInThisSolution
{
    [Params(123, -123, 321, 120, 1534236469, 12312312, -545345, 12343, 654645, 0, 2, 3, 5, -432423423, 6456, 3)]
    public int x;
    
    [Benchmark]
    public int Reverse() {
        if (x == 0)
        {
            return 0;
        }

        while(x % 10 == 0)
        {
            x /= 10; 
        }

        var (str, revStr, isNegative) = (x.ToString(), default(string), x < 0);

        for (var index = str.Length -1; index >= (isNegative ? 1 : 0); index--)
        {
            revStr += str[index];
        }

        if (int.TryParse(revStr, out var res))
        {
            return isNegative ? -1 * res : res;
        }

        return default;
    }
}