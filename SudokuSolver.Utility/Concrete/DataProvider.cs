using CommunityToolkit.Diagnostics;
using SodukuSolver.Utility.Interfaces;

namespace SodukuSolver.Utility.Concrete;

public sealed class DataProvider : IDataProvider
{
    private readonly IFileReader fileReader;
    private readonly IParser parser;
    private readonly ISettings settings;

    public DataProvider(IFileReader fileReader, IParser parser, ISettings settings)
    {
        Guard.IsNotNull(fileReader);
        Guard.IsNotNull(parser);
        Guard.IsNotNull(settings);

        this.fileReader = fileReader;
        this.parser = parser;
        this.settings = settings;
    }

    public int[,] GetPuzzleData()
    {
        var data = this.fileReader.GetFileData(this.settings.PuzzleFilePath);
        var arrayOfNumbers = this.parser.Parse(data);

        return arrayOfNumbers;
    }
}
