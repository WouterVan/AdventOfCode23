using Infrastructure;
using PuzzleSolving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost.Runner
{
    public static class Day03_Runner
    {
        public static async Task Run() 
        {
            var input = await ReadFile.ReadFromDisk("inputs", 3);
            var solver = new Day03();

            var solution = solver.getSolution(input.Lines);

            Console.WriteLine(solution);
        }
    }
}
