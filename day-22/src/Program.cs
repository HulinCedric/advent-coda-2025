using ChristmasTreeArt;
using Spectre.Console.Cli;

await new CommandApp<ChristmasTreeCommand>().RunAsync(args);