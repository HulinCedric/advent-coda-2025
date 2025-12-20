using ElfLs;
using Spectre.Console.Cli;

var app = new CommandApp();
app.SetDefaultCommand<ElfCommand>();
app.Configure(config => config.SetApplicationName("elf"));
await app.RunAsync(args);