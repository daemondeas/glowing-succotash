using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015._5;

public static class NiceDecisionMaker
{
    public static int CountNiceStrings(IEnumerable<string> strings) => strings.Count(IsNice);

    public static int CountNiceStringsNew(IEnumerable<string> strings) => strings.Count(IsNiceNew);

    private static bool IsNice(string input) =>
        HasAtLeastThreeVowels(input) && HasDoubleLetter(input) && !ContainsForbiddenSequence(input);

    private static bool HasAtLeastThreeVowels(string input) => input.Count(l => "aeiou".Contains(l)) >= 3;

    private static bool HasDoubleLetter(string input)
    {
        for (var i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                return true;
            }
        }

        return false;
    }

    private static bool ContainsForbiddenSequence(string input) =>
        input.Contains("ab") || input.Contains("cd") || input.Contains("pq") || input.Contains("xy");

    private static bool IsNiceNew(string input) => HasDoubleSequence(input) && HasDoubleWithOneLetterBetween(input);

    private static bool HasDoubleSequence(string input)
    {
        for (var i = 0; i < input.Length - 3; i++)
        {
            if (input[(i + 2)..].Contains(input[i..(i + 2)]))
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasDoubleWithOneLetterBetween(string input)
    {
        for (var i = 0; i < input.Length - 2; i++)
        {
            if (input[i] == input[i + 2])
            {
                return true;
            }
        }

        return false;
    }
}