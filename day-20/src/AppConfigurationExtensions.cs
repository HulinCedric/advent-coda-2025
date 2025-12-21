using ElfLs.Commands;
using Spectre.Console.Cli;

namespace ElfLs;

public static class AppConfigurationExtensions
{
    extension(IConfigurator config)
    {
        public void Configure()
        {
            config.SetApplicationName("elf");
            config.AddCommand<NormalCommand>("normal");
            config.AddCommand<CompactCommand>("compact");
            config.AddCommand<TreeCommand>("tree");
        }
    }
}