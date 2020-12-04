using System;
using AdventCommon;
using System.Linq;
namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = string.Join("\n", ConsoleHelpers.ReadInput()).Split("\n\n");
            var answer = inputs.Select(Passport.Parse).Count(p => p.Validate());
            Console.WriteLine(answer);
        }
    }
}
