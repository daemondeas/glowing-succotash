﻿using System;
using AoC2015._1;

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
            }
        }
    }
}