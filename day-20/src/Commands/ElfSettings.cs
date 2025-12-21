using System.ComponentModel;
using Spectre.Console.Cli;

namespace ElfLs.Commands;

public class ElfSettings : CommandSettings
{
    [CommandOption("-p|--path <PATH>")]
    [Description("Base directory path")]
    [DefaultValue(".")]
    public string Path { get; init; } = Directory.GetCurrentDirectory();
}