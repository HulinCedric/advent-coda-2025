using System.ComponentModel;
using ElfLs.Core;
using ElfLs.Presentations;
using Spectre.Console;

namespace ElfLs.Commands;

[Description("Displays items in a detailed table format")]
public class NormalCommand(IAnsiConsole console) : ElfCommand
{
    protected override IPresentationStrategy GetPresentation() => new NormalPresentation(console);
}