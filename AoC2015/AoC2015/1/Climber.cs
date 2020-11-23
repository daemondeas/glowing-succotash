using System.Linq;

namespace AoC2015._1
{
    public static class Climber
    {
        public static int Climb(string input)
        {
            return input.Count(c => c == '(')
                   - input.Count(c => c == ')');
        }

        public static int ClimbToBasement(string input)
        {
            var floor = 0;
            var position = 0;
            while (floor >= 0)
            {
                var c = input[position++];
                floor += c == '(' ? 1 : -1;
            }

            return position;
        }
    }
}