using Infrastructure;
using PuzzleSolving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost.Runner
{
    public static class Day01_Runner
    {
        public static async Task Run() 
        {
            var input = await ReadFile.ReadFromDisk("inputs", 1);
            var solver = new Day01();

            var solution = solver.getNumber(input.Lines);

            Console.WriteLine(solution);
        }
    }
}
