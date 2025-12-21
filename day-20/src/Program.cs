using ElfLs;
using ElfLs.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
    config.SetApplicationName("elf");
    config.AddCommand<NormalCommand>("normal");
});
await app.RunAsync(args);