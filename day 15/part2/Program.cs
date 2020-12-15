using System;
using System.Linq;
using AdventCommon;
using System.Collections.Generic;

namespace part2
{
    class TurnTracker : List<int>
    {
        public new void Add(int turn)
        {
            if (Count >= 2)
            {
                RemoveAt(0);
            }

            base.Add(turn);
        }

        public int Difference
        {
            get
            {
                if (Count < 2)
                {
                    return 0;
                }

                return this[1] - this[0];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var startingNumbers = lines[0].Split(',').Select(int.Parse).ToArray();

            var turnTrackers = new Dictionary<int, TurnTracker>();

            for (var i = 1; i <= startingNumbers.Length; i++)
            {
                turnTrackers[startingNumbers[i - 1]] = new TurnTracker { i };
            }

            int lastNumber = 0;
            
            for (var i = startingNumbers.Length + 1; i < 30000000; i++)
            {
                if (!turnTrackers.ContainsKey(lastNumber))
                {
                    turnTrackers[lastNumber] = new TurnTracker { i };
                    lastNumber = 0;
                } else {
                    turnTrackers[lastNumber].Add(i);
                    lastNumber = turnTrackers[lastNumber].Difference;
                }
            }

            Console.WriteLine(lastNumber);
        }
    }
}
