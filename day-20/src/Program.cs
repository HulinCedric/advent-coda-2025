using ElfLs;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(AppConfigurationExtensions.Configure);
await app.RunAsync(args);