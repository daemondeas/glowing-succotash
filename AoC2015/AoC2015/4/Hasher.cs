using System;

namespace AoC2015._4;

public class Hasher
{
    public static int FindSmallestAdventCoinHashNumber(string key, string startingNumber)
    {
        string hash;
        var result = 0;
        do
        {
            hash = CreateMD5($"{key}{++result}");
        } while (!hash.StartsWith(startingNumber));

        return result;
    }
    
    private static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using var md5 = System.Security.Cryptography.MD5.Create();
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}