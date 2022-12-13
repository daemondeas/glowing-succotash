using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2015._6;

public static class SuperLightSwitch
{
    public static int FollowSantaInstructions()
    {
        var grid = GenerateGrid();
        var instructions = ParseInput(File.ReadAllText("6/input"));
        foreach (var instruction in instructions)
        {
            RunInstruction(instruction, grid);
        }
        
        return grid.Sum(r => r.Count(l => l));
    }

    public static long FollowBetterTranslation()
    {
        var grid = GenerateBrightnessGrid();
        var instructions = ParseInput(File.ReadAllText("6/input"));
        foreach (var instruction in instructions)
        {
            RunInstruction(instruction, grid);
        }
        
        return grid.Sum(r => r.Sum());
    }

    private static void RunInstruction(SwitchInstruction instruction, List<List<bool>> grid)
    {
        for (var i = instruction.Start.Y; i <= instruction.End.Y; i++)
        {
            for (var j = instruction.Start.X; j <= instruction.End.X; j++)
            {
                grid[i][j] = SingleInstruction(instruction.Type, grid[i][j]);
            }
        }
    }
    
    private static void RunInstruction(SwitchInstruction instruction, List<List<long>> grid)
    {
        for (var i = instruction.Start.Y; i <= instruction.End.Y; i++)
        {
            for (var j = instruction.Start.X; j <= instruction.End.X; j++)
            {
                grid[i][j] = SingleInstruction(instruction.Type, grid[i][j]);
            }
        }
    }

    private static bool SingleInstruction(InstructionType iType, bool previous) =>
        iType switch
        {
            InstructionType.On     => true,
            InstructionType.Off    => false,
            InstructionType.Toggle => !previous
        };
    
    private static long SingleInstruction(InstructionType iType, long previous) =>
        iType switch
        {
            InstructionType.On     => previous + 1,
            InstructionType.Off    => Math.Max(0, previous - 1),
            InstructionType.Toggle => previous + 2
        };

    private static IEnumerable<SwitchInstruction> ParseInput(string input) =>
        input.Split('\n').Select(ParseInstruction);

    private static List<List<bool>> GenerateGrid()
    {
        var grid = new List<List<bool>>(1000);
        for (var i = 0; i < 1000; i++)
        {
            grid.Add(new List<bool>(1000));
            for (var j = 0; j < 1000; j++)
            {
                grid[i].Add(false);
            }
        }

        return grid;
    }
    
    private static List<List<long>> GenerateBrightnessGrid()
    {
        var grid = new List<List<long>>(1000);
        for (var i = 0; i < 1000; i++)
        {
            grid.Add(new List<long>(1000));
            for (var j = 0; j < 1000; j++)
            {
                grid[i].Add(0);
            }
        }

        return grid;
    }

    private static Position ParsePosition(string input)
    {
        var parts = input.Split(',');
        return new Position { X = int.Parse(parts[0]), Y = int.Parse(parts[1]) };
    }

    private static SwitchInstruction ParseInstruction(string row)
    {
        InstructionType iType;
        Position start;
        Position end;
        if (row.StartsWith("turn on"))
        {
            iType = InstructionType.On;
            start = ParsePosition(row.Split(' ')[2]);
            end = ParsePosition(row.Split(' ')[4]);
        }
        else if (row.StartsWith("turn off"))
        {
            iType = InstructionType.Off;
            start = ParsePosition(row.Split(' ')[2]);
            end = ParsePosition(row.Split(' ')[4]);
        }
        else
        {
            iType = InstructionType.Toggle;
            start = ParsePosition(row.Split(' ')[1]);
            end = ParsePosition(row.Split(' ')[3]);
        }

        return new SwitchInstruction { Type = iType, Start = start, End = end };
    }
}

public record struct Position
{
    public int X;
    public int Y;
}

public enum InstructionType
{
    On,
    Off,
    Toggle
}

public record struct SwitchInstruction
{
    public InstructionType Type;
    public Position Start;
    public Position End;
}