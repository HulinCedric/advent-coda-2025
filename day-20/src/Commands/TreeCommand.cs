using System.ComponentModel;
using ElfLs.Core;
using ElfLs.Presentations;
using Spectre.Console;

namespace ElfLs.Commands;

[Description("Displays items in a tree structure")]
public class TreeCommand(IAnsiConsole console) : ElfCommand
{
    protected override IPresentationStrategy GetPresentation() => new TreePresentation(console);
}