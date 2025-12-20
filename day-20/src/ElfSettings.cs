using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ElfLs;

public class ElfSettings : CommandSettings
{
    [CommandOption("-p|--path <PATH>")]
    [Description("Base directory path")]
    [DefaultValue(".")]
    public string Path { get; init; } = Directory.GetCurrentDirectory();

    [CommandOption("-n|--normal")]
    [Description("Displays items in a detailed table format")]
    public bool Normal { get; init; }

    [CommandOption("-c|--compact")]
    [Description("Displays items in a compact line")]
    public bool Compact { get; init; } 

    [CommandOption("-t|--tree")]
    [Description("Displays items in a tree structure")]
    public bool Tree { get; init; }

    public DisplayMode DisplayMode
        => (Normal, Compact, Tree) switch
        {
            (Normal: true, _, _) => DisplayMode.Normal,
            (_, Compact: true, _) => DisplayMode.Compact,
            (_, _, Tree: true) => DisplayMode.Tree,
            _ => DisplayMode.Normal
        };
    
    public override ValidationResult Validate()
    {
        var count = new[] { Normal, Compact, Tree }.Count(x => x);
        return count switch
        {
            0 => ValidationResult.Error("Options --normal, --compact or --tree should be specified. Use --help to see valid usage."),
            1 => ValidationResult.Success(),
            _ => ValidationResult.Error("Options --normal, --compact and --tree are mutually exclusive. Use --help to see valid usage.")
        };
    }
}