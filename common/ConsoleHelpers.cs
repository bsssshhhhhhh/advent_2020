using System.IO;
using System.Collections.Generic;
using System;

namespace AdventCommon
{
    public static class ConsoleHelpers
    {
        public static string[] ReadInput()
        {
            var lines = new List<string>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                lines.Add(line);
            }

            return lines.ToArray();
        }
    }
}