using System;
using AdventCommon;
using System.Linq;
using System.Collections.Generic;

namespace part1
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
        public CardinalDirection Direction { get; set; } = CardinalDirection.East;

        public enum CardinalDirection
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }

        public void Move(char instruction, int distance)
        {
            switch (instruction)
            {
                case 'N': MoveDirection(CardinalDirection.North, distance); break;
                case 'S': MoveDirection(CardinalDirection.South, distance); break;
                case 'E': MoveDirection(CardinalDirection.East, distance); break;
                case 'W': MoveDirection(CardinalDirection.West, distance); break;
                case 'L': {
                    var quarterTurns = distance / 90;
                    for (var i = 0; i < quarterTurns; i++)
                    {
                        Direction = Direction == CardinalDirection.North ? CardinalDirection.West : Direction - 1;
                    }

                    break;
                }
                case 'R': {
                    var quarterTurns = distance / 90;
                    for (var i = 0; i < quarterTurns; i++)
                    {
                        Direction = Direction == CardinalDirection.West ? CardinalDirection.North : Direction + 1;
                    }
                    
                    break;
                }
                case 'F': {
                    MoveDirection(Direction, distance);
                    break;
                }

            }
        }

        private void MoveDirection(CardinalDirection direction, int distance)
        {
            switch (direction)
            {
                case CardinalDirection.North: Y -= distance; break;
                case CardinalDirection.South: Y += distance; break;
                case CardinalDirection.East: X += distance; break;
                case CardinalDirection.West: X -= distance; break;
            }
        }
    }
}
