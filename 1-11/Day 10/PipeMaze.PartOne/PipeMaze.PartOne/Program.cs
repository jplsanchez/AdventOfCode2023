// See https://aka.ms/new-console-template for more information
using AdventOfCode.Common.Utils;
using PipeMaze.PartOne;

Console.WriteLine("Hello, World!");

var input = FileUtils.Load("input.txt");
Maze maze = Parser.Parse(input);

var tile = maze.FindFarestTileInPath();

Console.WriteLine($"{tile.Distance} @ i: {tile.Position.i}, j: {tile.Position.j}");

