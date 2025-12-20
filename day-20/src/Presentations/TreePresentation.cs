using ElfLs.Core;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ElfLs.Presentations;

public class TreePresentation : IPresentationStrategy
{
    private readonly IAnsiConsole _console;

    public TreePresentation(IAnsiConsole console) => _console = console;

    public void Present(InventoryDirectory directory)
    {
        _console.Write(Render(directory));
    }

    
    private static IRenderable Render(InventoryDirectory directory)
    {
        /// .
        /// ├── Poupée chantante (200g, ✨✨✨)
        /// ├── Épée en bois (1kg, ✨)
        /// ├── Livre de sorts (500g, ✨✨)
        /// ├── Boîte à musique (300g, ✨)
        /// └── Dossier Jouets/
        /// ├── Boule de neige (100g, ✨)
        /// └── Sablier magique (300g, ✨✨)
        /// 
        
        var tree = new Tree(".");
        foreach (var file in directory.Files)
        {
            tree.AddNode($"{file.Name} ({file.Weight}, {file.Magic})");
        }  
        foreach (var dir in directory.Directories)
        {
            var dirNode = tree.AddNode($"Dossier {dir.Name}/");
            AddDirectoryNodes(dirNode, dir);
        }
        return tree;
    }
    private static void AddDirectoryNodes(TreeNode parentNode, InventoryDirectory directory)
    {
        foreach (var file in directory.Files)
        {
            parentNode.AddNode($"{file.Name} ({file.Weight}, {file.Magic})");
        }  
        foreach (var dir in directory.Directories)
        {
            var dirNode = parentNode.AddNode($"Dossier {dir.Name}/");
            AddDirectoryNodes(dirNode, dir);
        }
    }
}