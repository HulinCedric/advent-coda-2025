namespace ElfLs.Tests.Utils;

public static class InventoryDirectoryFinder
{
    extension(string directoryName)
    {
        public string FindDirectory()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);

            while (dir != null)
            {
                if (dir.EnumerateFiles("ElfLs.Tests.csproj", SearchOption.TopDirectoryOnly).Any())
                    return Path.GetFullPath(Path.Combine(dir.FullName, "..", directoryName));

                dir = dir.Parent;
            }

            return new DirectoryInfo(AppContext.BaseDirectory).FullName;
        }
    }
}