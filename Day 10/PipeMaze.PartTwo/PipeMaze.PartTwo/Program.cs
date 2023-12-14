// See https://aka.ms/new-console-template for more information
using AdventOfCode.Common.Utils;
using PipeMaze.PartTwo;

var input = FileUtils.Load("input.txt");
Maze maze = Parser.Parse(input);

int count = 0;

maze.SetLoop().SetOutside().SetInsideOutside().Print();

Console.WriteLine();
Console.WriteLine($"The total of inside tiles is {count}");
