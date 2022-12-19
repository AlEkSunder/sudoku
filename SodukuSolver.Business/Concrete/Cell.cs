using CommunityToolkit.Diagnostics;
using SodukuSolver.Business.Constants;
using SodukuSolver.Business.Interfaces;

namespace SodukuSolver.Business.Concrete;

internal sealed class Cell : ICell
{
    private IPlayableElement<ICell> block;
    private IPlayableElement<ICell> column;
    private IPlayableElement<ICell> row;
    private int value;

    public event EventHandler PossibleValueChanged;

    private void RaisePossibleValueChanged() => this.PossibleValueChanged?.Invoke(this, EventArgs.Empty);

    public int this[int index]
    {
        get
        {
            Guard.IsGreaterThanOrEqualTo(index, Limits.MinIndex);
            Guard.IsLessThanOrEqualTo(index, Limits.MaxIndex);

            return this.PossibleNumbers[index];
        }
    }

    public IPlayableElement<ICell> Block
    {
        get => this.block;
        set
        {
            Guard.IsNotNull(value, nameof(this.Block));

            this.block = value;
        }
    }

    public Cell(int value)
    {
        this.PossibleNumbers = Enumerable.Range(Limits.MinValue, Limits.NumberOfPossibleValues).ToList();

        this.Value = value;
    }

    private void ClearPossibleNumbers()
    {
        for (int i = 0; i < Limits.NumberOfPossibleValues; i++)
            this.PossibleNumbers[i] = default;

        this.MarkRelatedAsProcessed();

        this.RaisePossibleValueChanged();
    }

    public IPlayableElement<ICell> Column
    {
        get => this.column;
        set
        {
            Guard.IsNotNull(value, nameof(this.Column));

            this.column = value;
        }
    }

    private void MarkRelatedAsProcessed()
    {
        if (this.Row is null || this.Block is null || this.Column is null)
            return;

        this.Row.IsInProcessOfUpdate = true;
        this.Block.IsInProcessOfUpdate = true;
        this.Column.IsInProcessOfUpdate = true;
    }

    public bool IsOnlyAvailableValue => this.PossibleNumbersCount == 1;

    public List<int> PossibleNumbers { get; init; }

    public int PossibleNumbersCount => this.PossibleNumbers.Count(number => number != default);

    public IEnumerable<int> RemainingNumbers => this.PossibleNumbers.Where(number => number != default);

    public void RemovePossibleNumber(int number)
    {
        Guard.IsGreaterThanOrEqualTo(number, Limits.MinValue);
        Guard.IsLessThanOrEqualTo(number, Limits.MaxValue);

        if (this.Value != default)
            return;

        var numberIndex = number - 1;

        if (this.PossibleNumbers[numberIndex] == default)
            return;

        this.PossibleNumbers[numberIndex] = default;

        if (this.IsOnlyAvailableValue)
        {
            this.Value = this.PossibleNumbers.First(value => value != default);
            this.PossibleNumbers[this.Value - 1] = default;
        }

        this.RaisePossibleValueChanged();
    }

    public IPlayableElement<ICell> Row
    {
        get => this.row;
        set
        {
            Guard.IsNotNull(value, nameof(this.Row));

            this.row = value;
        }
    }

    public override string ToString() => this.Value.ToString();

    public void TryRemove(int number)
    {
        Guard.IsGreaterThanOrEqualTo(number, Limits.MinValue);
        Guard.IsLessThanOrEqualTo(number, Limits.MaxValue);

        if (this.Row.HasNumber(number))
            this.Row.RemovePossibleNumber(number);

        if (this.Column.HasNumber(number))
            this.Column.RemovePossibleNumber(number);

        if (this.Block.HasNumber(number))
            this.Block.RemovePossibleNumber(number);
    }

    public int Value
    {
        get => this.value;
        set
        {
            Guard.IsGreaterThanOrEqualTo(value, default);
            Guard.IsLessThanOrEqualTo(value, Limits.MaxValue);

            this.value = value;

            if (value != default)
                this.ClearPossibleNumbers();
        }
    }
}
