using System;
using AdventCommon;
using System.Linq;
using System.Collections.Generic;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();

            var ship = new Ship();

            foreach (var line in lines)
            {
                var instruction = line[0];
                var distance = int.Parse(string.Join("", line.Skip(1)));

                ship.Move(instruction, distance);
            }

            Console.WriteLine(Math.Abs(ship.X) + Math.Abs(ship.Y));
        }
    }

    public class Ship
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public int WaypointX { get; set; } = 10;
        public int WaypointY { get; set; } = -1;
        public void Move(char instruction, int distance)
        {
            switch (instruction)
            {
                case 'N': WaypointY -= distance; break;
                case 'S': WaypointY += distance; break;
                case 'E': WaypointX += distance; break;
                case 'W': WaypointX -= distance; break;
                case 'L': {
                    RotateWaypoint(-1 * distance);
                    break;
                }
                case 'R': {
                    RotateWaypoint(distance);
                    break;
                }
                case 'F': {
                    X += WaypointX * distance;
                    Y += WaypointY * distance;                    
                    break;
                }

            }
        }

        private void RotateWaypoint(int degrees)
        {
            var theta = degrees * Math.PI / 180;
            var x = WaypointX;
            var y = WaypointY;

            WaypointX = (int) Math.Round(x * Math.Cos(theta) - y * Math.Sin(theta));
            WaypointY = (int) Math.Round(x * Math.Sin(theta) + y * Math.Cos(theta));
        }
    }
}
