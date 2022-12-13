using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2015._7;

public static class LogicBox
{
    private static readonly Dictionary<string, ushort> Results = new();
    public static ushort WhatsInA()
    {
        var wiring = GetWiring(File.ReadAllText("7/input"));
        return Evaluate("a", wiring);
    }

    public static ushort WhatsInAWhenSettingBToFirstA()
    {
        var firstA = WhatsInA();
        Results.Clear();
        Results["b"] = firstA;
        return WhatsInA();
    }

    private static ushort Evaluate(string name, Dictionary<string, IOperation> wiring)
    {
        if (Results.TryGetValue(name, out var value))
        {
            return value;
        }
        var result = (ushort)(ushort.TryParse(name, out var coolNumber)
            ? coolNumber
            : wiring[name] switch
            {
                AndOperation andOperation => Evaluate(andOperation.First, wiring)
                                             & Evaluate(andOperation.Second, wiring),
                LShiftOperation lShiftOperation => Evaluate(lShiftOperation.First, wiring)
                                                   << ushort.Parse(lShiftOperation.Second),
                NotOperation notOperation => ~Evaluate(notOperation.First, wiring),
                OrOperation orOperation   => Evaluate(orOperation.First, wiring) | Evaluate(orOperation.Second, wiring),
                RShiftOperation rShiftOperation => Evaluate(rShiftOperation.First, wiring)
                                                   >> ushort.Parse(rShiftOperation.Second),
                SetOperation setOperation   => ushort.Parse(setOperation.First),
                WireOperation wireOperation => Evaluate(wireOperation.First, wiring)
            });
        Results[name] = result;
        return result;
    }

    private static Dictionary<string, IOperation> GetWiring(string input)
    {
        var wiring = new Dictionary<string, IOperation>();
        foreach (var operation in input.Split('\n'))
        {
            var (key, value) = ParseOperation(operation);
            wiring.Add(key, value);
        }

        return wiring;
    }

    private static (string, IOperation) ParseOperation(string input)
    {
        var parts = input.Split(" -> ");
        var destination = parts[1];
        var expr = parts[0];

        if (!expr.Contains(' '))
        {
            if (ushort.TryParse(expr, out _))
            {
                return (destination, new SetOperation { First = expr });
            }

            return (destination, new WireOperation { First = expr });
        }

        if (parts[0].StartsWith("NOT"))
        {
            return (destination, new NotOperation { First = expr.Split(' ')[1] });
        }

        var innerParts = expr.Split(' ');

        return (destination, GetOperation(innerParts[1], innerParts[0], innerParts[2]));
    }

    private static ITwoEntriesOperation GetOperation(string operationType, string first, string second) =>
        operationType switch
        {
            "AND"    => new AndOperation { First = first, Second = second },
            "OR"     => new OrOperation { First = first, Second = second },
            "LSHIFT" => new LShiftOperation { First = first, Second = second },
            "RSHIFT" => new RShiftOperation { First = first, Second = second }
        };
}

public interface IOperation
{
    string First { get; }
}

public interface ITwoEntriesOperation : IOperation
{
    string Second { get; }
}

public class AndOperation : ITwoEntriesOperation
{
    public string First { get; init; }
    public string Second { get; init; }
}

public class OrOperation : ITwoEntriesOperation
{
    public string First { get; init; }
    public string Second { get; init; }
}

public class NotOperation : IOperation
{
    public string First { get; init; }
}

public class LShiftOperation : ITwoEntriesOperation
{
    public string First { get; init; }
    public string Second { get; init; }
}

public class RShiftOperation : ITwoEntriesOperation
{
    public string First { get; init; }
    public string Second { get; init; }
}

public class SetOperation : IOperation
{
    public string First { get; init; }
}

public class WireOperation : IOperation
{
    public string First { get; init; }
}