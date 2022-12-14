using System;
using System.Linq;
using AoC2015._1;
using AoC2015._3;
using AoC2015._4;
using AoC2015._5;
using AoC2015._6;
using AoC2015._7;
using AoC2015._8;

namespace AoC2015
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var day = int.Parse(args[0]);
            var subtask = int.Parse(args[1]);
            switch (day)
            {
                case 1:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(Climber.Climb(args[2]));
                            break;
                        case 2:
                            Console.WriteLine(Climber.ClimbToBasement(args[2]));
                            break;
                    }

                    break;

                case 2:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(Wrapper.GetWrappingArea(args.Skip(2).ToArray()));
                            break;
                        case 2:
                            Console.WriteLine(Wrapper.GetRibbonLength(args.Skip(2).ToArray()));
                            break;
                    }

                    break;
                
                case 3:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(Navigator.Navigate(args[2].ToCharArray()));
                            break;
                        case 2:
                            Console.WriteLine(Navigator.NavigateWithRobot(args[2].ToCharArray()));
                            break;
                    }

                    break;
                
                case 4:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(Hasher.FindSmallestAdventCoinHashNumber(args[2], "00000"));
                            break;
                        case 2:
                            Console.WriteLine(Hasher.FindSmallestAdventCoinHashNumber(args[2], "000000"));
                            break;
                    }

                    break;
                
                case 5:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(NiceDecisionMaker.CountNiceStrings(args.Skip(2)));
                            break;
                        case 2:
                            Console.WriteLine(NiceDecisionMaker.CountNiceStringsNew(args.Skip(2)));
                            break;
                    }

                    break;
                
                case 6:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(SuperLightSwitch.FollowSantaInstructions());
                            break;
                        case 2:
                            Console.WriteLine(SuperLightSwitch.FollowBetterTranslation());
                            break;
                    }

                    break;
                
                case 7:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(LogicBox.WhatsInA());
                            break;
                        case 2:
                            Console.WriteLine(LogicBox.WhatsInAWhenSettingBToFirstA());
                            break;
                    }

                    break;
                
                case 8:
                    switch (subtask)
                    {
                        case 1:
                            Console.WriteLine(StringUtils.GetMemoryDifference());
                            break;
                        case 2:
                            Console.WriteLine(StringUtils.EncodeAndCheckOverhead());
                            break;
                    }

                    break;
            }
        }
    }
}