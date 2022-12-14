using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2015._8;

public static class StringUtils
{
    public static int GetMemoryDifference()
    {
        var strings = File.ReadAllLines("8/input");
        return strings.Sum(CodeRepresentationSize) - strings.Sum(MemorySize);
    }

    public static int EncodeAndCheckOverhead()
    {
        var strings = File.ReadAllLines("8/input");
        return strings.Sum(EncodedSize) - strings.Sum(CodeRepresentationSize);
    }

    private static int CodeRepresentationSize(string s) => s.Length;
    
    private static int MemorySize(string s)
    {
        var i = 1;
        var result = 0;
        while (i < s.Length - 1)
        {
            if (s[i] == '\\')
            {
                if (s[i + 1] == '\\')
                {
                    result++;
                    i += 2;
                }
                else if(s[i + 1] == '"')
                {
                    result++;
                    i += 2;
                }
                else if(s[i + 1] == 'x' && s[i + 2].IsHexadecimal() && s[i + 3].IsHexadecimal())
                {
                    result++;
                    i += 4;
                }
            }
            else
            {
                result++;
                i++;
            }
        }

        return result;
    }

    private static bool IsHexadecimal(this char h) => h is >= '0' and <= '9' or >= 'a' and <= 'f' or >= 'A' and <= 'F';

    private static int EncodedSize(string s) => s.Count(c => c is '"' or '\\') + s.Length + 2;
}