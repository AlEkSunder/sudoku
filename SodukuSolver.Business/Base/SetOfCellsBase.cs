using CommunityToolkit.Diagnostics;
using SodukuSolver.Business.Constants;
using SodukuSolver.Business.Interfaces;
using System.Collections;

namespace SodukuSolver.Business.Base;

internal abstract class SetOfCellsBase: IPlayableElement<ICell>, IEnumerable<ICell>
{
    private byte currentIndex;

    public ICell this[int index]
    {
        get
        {
            Guard.IsGreaterThanOrEqualTo(index, Limits.MinIndex);
            Guard.IsLessThanOrEqualTo(index, Limits.MaxIndex);

            return this.Cells[index];
        }
    }

    public void Add(ICell cell)
    {
        Guard.IsNotNull(cell);

        this.Cells[this.currentIndex] = cell;
        this.currentIndex++;
        this.InitializeCell(cell);
    }

    protected ICell[] Cells { get; }

    public void DefineSingles()
    {
        var groups = this.Cells
            .Where(cell => cell.Value == default)
            .SelectMany(cell => cell.PossibleNumbers, (cell, number) => new
            {
                Cell = cell,
                Number = number
            })
            .GroupBy(cell => cell.Number, (key, group) => new
            {
                Cell = group.First().Cell,
                NumberToSetup = key,
                Count = group.Count()
            })
            .Where(group => group.Count == 1);

        foreach (var group in groups)
            group.Cell.Value = group.NumberToSetup;
    }

    public IEnumerator<ICell> GetEnumerator() => (IEnumerator<ICell>)this.Cells.GetEnumerator();

    public void HandleNakedPairs()
    {
        const int NumberValuesInPair = 2;

        var groups = this.Cells
            .Where(cell => cell.Value == default && cell.PossibleNumbersCount == NumberValuesInPair)
            .SelectMany(cell => cell.RemainingNumbers, (cell, number) => new
            {
                Cell = cell,
                Number = number
            })
            .GroupBy(cell => cell.Number, (key, group) => new
            {
                Cells = group,
                NumberToRemove = key,
                Count = group.Count()
            })
            .Where(group => group.Count == 2);

        foreach (var group in groups)
        {
            foreach (var cell in this.Cells)
            {
                cell.RemovePossibleNumber(group.NumberToRemove);
            }
        }
    }

    public bool HasNumber(int number)
    {
        Guard.IsGreaterThanOrEqualTo(number, Limits.MinValue);
        Guard.IsLessThanOrEqualTo(number, Limits.MaxValue);

        foreach (var cell in this.Cells)
        {
            if (cell.Value == number)
                return true;
        }

        return false;
    }

    IEnumerator IEnumerable.GetEnumerator() => this.Cells.GetEnumerator();

    protected abstract void InitializeCell(ICell cell);

    public bool IsCompleted => this.Cells.All(cell => cell.Value != default);
    
    public bool IsInProcessOfUpdate { get; set; }

    public void RemovePossibleNumber(int number)
    {
        Guard.IsGreaterThanOrEqualTo(number, Limits.MinValue);
        Guard.IsLessThanOrEqualTo(number, Limits.MaxValue);

        foreach (var cell in this.Cells)
            cell.RemovePossibleNumber(number);
    }

    public SetOfCellsBase() => this.Cells = new ICell[Limits.NumberOfPossibleValues];
}
