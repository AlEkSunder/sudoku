using CommunityToolkit.Diagnostics;
using SodukuSolver.Business.Concrete;
using SodukuSolver.Business.Constants;
using SodukuSolver.Business.Interfaces;

namespace SodukuSolver.Business.Factories;

public sealed class FieldFactory : IFieldFactory
{
    public IField CreateField(int[,] arrayOfNumbers)
    {
        Guard.IsNotNull(arrayOfNumbers);
        Guard.IsEqualTo(arrayOfNumbers.GetLength(0), Limits.NumberOfPossibleValues);
        Guard.IsEqualTo(arrayOfNumbers.GetLength(1), Limits.NumberOfPossibleValues);

        var columns = new Column[]
        {
            new Column(),
            new Column(),
            new Column(),
            new Column(),
            new Column(),
            new Column(),
            new Column(),
            new Column(),
            new Column()
        };
        var rows = new Row[]
        {
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row()
        };
        var blocks = new Block[]
        {
            new Block(),
            new Block(),
            new Block(),
            new Block(),
            new Block(),
            new Block(),
            new Block(),
            new Block(),
            new Block()
        };
        var cells = new Cell[Limits.MaxValue, Limits.MaxValue];

        for (int rowIndex = Limits.MinIndex; rowIndex < Limits.NumberOfPossibleValues; rowIndex++)
        {
            for (int columnIndex = Limits.MinIndex; columnIndex < Limits.NumberOfPossibleValues; columnIndex++)
            {
                int number = arrayOfNumbers[rowIndex, columnIndex];
                var cell = new Cell(number);

                rows[rowIndex].Add(cell);
                columns[columnIndex].Add(cell);
                blocks[GetBlockNumber(rowIndex, columnIndex)].Add(cell);
                cells[rowIndex, columnIndex] = cell;
            }
        }

        return new Field(rows, columns, blocks, cells);
    }

    private int GetBlockNumber(int rowIndex, int columnIndex) => rowIndex / 3 * 3 + columnIndex / 3;
}
