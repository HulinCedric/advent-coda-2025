using System.ComponentModel;
using ElfLs.Core;
using ElfLs.Presentations;
using Spectre.Console;

namespace ElfLs.Commands;

[Description("Displays items in a compact line")]
public class CompactCommand(IAnsiConsole console) : ElfCommand
{
    protected override IPresentationStrategy GetPresentation() => new CompactPresentation(console);
}