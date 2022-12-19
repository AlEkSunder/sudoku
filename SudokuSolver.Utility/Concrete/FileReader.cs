using CommunityToolkit.Diagnostics;
using SodukuSolver.Utility.Interfaces;

namespace SodukuSolver.Utility.Concrete;

public sealed class FileReader : IFileReader
{
    public string GetFileData(string path)
    {
        Guard.IsNotNullOrWhiteSpace(path);
        Guard.IsTrue(File.Exists(path), nameof(path), $"The file {path} does not exists");

        using (StreamReader reader = new StreamReader(path))
        {
            return reader.ReadToEnd();
        }
    }
}
