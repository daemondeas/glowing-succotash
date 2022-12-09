using System.Collections.Generic;
using System.Linq;

namespace AoC2015._3;

public class Navigator
{
    public static int Navigate(char[] input)
    {
        var position = (0, 0);
        var houses = new List<(int, int)> { position };
        foreach (var direction in input)
        {
            position = Move(position, direction);
            houses.Add(position);
        }
        
        return houses.Distinct().Count();
    }
    
    public static int NavigateWithRobot(char[] input)
    {
        var position = (0, 0);
        var robotPosition = (0, 0);
        var houses = new List<(int, int)> { position };
        for (var index = 0; index < input.Length; index++)
        {
            var direction = input[index];
            if ((index & 1) == 0)
            {
                position = Move(position, direction);
                houses.Add(position);
            }
            else
            {
                robotPosition = Move(robotPosition, direction);
                houses.Add(robotPosition);
            }
        }

        return houses.Distinct().Count();
    }

    private static (int, int) Move((int x, int y) pos, char direction) =>
        direction switch
        {
            '^' => (pos.x, pos.y + 1),
            'v' => (pos.x, pos.y - 1),
            '<' => (pos.x - 1, pos.y),
            '>' => (pos.x + 1, pos.y)
        };
}