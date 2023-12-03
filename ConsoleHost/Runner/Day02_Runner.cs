using Infrastructure;
using PuzzleSolving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost.Runner
{
    public static class Day02_Runner
    {
        public static async Task Run() 
        {
            var input = await ReadFile.ReadFromDisk("inputs", 2);
            var solver = new Day02();

            var solution = solver.getSolution(input.Lines);

            Console.WriteLine(solution);
        }
    }
}
