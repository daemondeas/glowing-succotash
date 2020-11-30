using System;
using System.Linq;

namespace AoC2015
{
    public static class Wrapper
    {
        public static int GetWrappingArea(string[] boxen)
        {
            return boxen.Select(ParseBox).Select(GetSides).Sum(GetBoxWrappingArea);
        }

        public static int GetRibbonLength(string[] boxen)
        {
            return boxen.Select(ParseBox).Sum(b => GetShortestPerimeter(b) + GetVolume(b));
        }

        private static int[] GetSides(int[] dimensions)
        {
            return new[] {
                dimensions[0] * dimensions[1],
                dimensions[0] * dimensions[2],
                dimensions[1] * dimensions[2]
            };
        }

        private static int[] ParseBox(string box)
        {
            return box.Split('x').Select(int.Parse).ToArray();
        }

        private static int GetBoxWrappingArea(int[] sides)
        {
            Array.Sort(sides);
            return sides[0] * 3 + (sides[1] + sides[2]) * 2;
        }

        private static int GetShortestPerimeter(int[] dimensions)
        {
            Array.Sort(dimensions);
            return (dimensions[0] + dimensions[1]) * 2;
        }

        private static int GetVolume(int[] dimensions)
        {
            return dimensions.Aggregate((a, b) => a * b);
        }
    }
}
