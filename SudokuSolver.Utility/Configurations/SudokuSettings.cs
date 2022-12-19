using SodukuSolver.Utility.Interfaces;

namespace SudokuSolver.Utility.Configurations;

public sealed class SudokuSettings : ISettings
{
    public string PuzzleFilePath { get; set; }
}
