using CommunityToolkit.Diagnostics;
using SodukuSolver.Business.Constants;
using SodukuSolver.Business.Interfaces;

namespace SodukuSolver.Business.Concrete;

internal sealed class Field : IField
{
    private int currentColumnIndex;
    private int currentPossibleNumber;

    private void ApplyToCells(Action<ICell> action)
    {
        for (int rowIndex = 0; rowIndex < Limits.NumberOfPossibleValues; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < Limits.NumberOfPossibleValues; columnIndex++)
            {
                action(this.Cells[rowIndex, columnIndex]);
            }
        }
    }

    private IPlayableElement<ICell>[] Blocks { get; init; }

    private ICell[,] Cells { get; }

    private IPlayableElement<ICell>[] Columns { get; init; }

    private ICell CurrentCell => this.Cells[this.CurrentRowIndex, this.CurrentColumnIndex];

    private int CurrentColumnIndex
    {
        get => this.currentColumnIndex;
        set
        {
            Guard.IsGreaterThanOrEqualTo(value, Limits.MinIndex);

            if (value > Limits.MaxIndex)
            {
                this.currentColumnIndex = default;
                this.CurrentRowIndex++;
            }
            else
            {
                this.currentColumnIndex = value;
            }
        }
    }

    private int CurrentPossibleNumber
    {
        get => this.currentPossibleNumber;
        set
        {
            Guard.IsGreaterThanOrEqualTo(value, Limits.MinValue);

            if (value > Limits.MaxValue)
            {
                this.currentPossibleNumber = Limits.MinValue;
                this.CurrentColumnIndex++;
            }
            else
            {
                this.currentPossibleNumber = value;
            }
        }
    }

    private int CurrentRowIndex { get; set; }

    public void Dispose()
    {
        //
        // TODO: implement disposable pattern.
        //
        this.ApplyToCells(this.UnSubscribeCellEvent);
    }

    internal Field(IPlayableElement<ICell>[] rows, IPlayableElement<ICell>[] columns, IPlayableElement<ICell>[] blocks, ICell[,] cells)
    {
        Guard.IsNotNull(rows);
        Guard.IsNotNull(columns);
        Guard.IsNotNull(blocks);
        Guard.IsNotNull(cells);

        this.Rows = rows;
        this.Columns = columns;
        this.Blocks = blocks;
        this.Cells = cells;
        this.CurrentPossibleNumber = Limits.MinValue;
        this.ApplyToCells(this.SubscribeCellEvent);
    }

    private void HandleHiddenSingles()
    {
        foreach (var row in this.Rows.Where(row => !row.IsInProcessOfUpdate))
            row.DefineSingles();

        foreach (var column in this.Columns.Where(column => !column.IsInProcessOfUpdate))
            column.DefineSingles();

        foreach (var block in this.Blocks.Where(block => !block.IsInProcessOfUpdate))
            block.DefineSingles();

        this.MarkAsProcessed();
    }

    private void HandleNakedPairs()
    {
        foreach (var row in this.Rows)
            row.HandleNakedPairs();

        foreach (var column in this.Columns)
            column.HandleNakedPairs();

        foreach (var block in this.Blocks)
            block.HandleNakedPairs();
    }

    private void HandlePossibles()
    {
        while (this.IsInFieldRange)
        {
            this.CurrentCell.TryRemove(this.CurrentPossibleNumber);
            this.CurrentPossibleNumber++;
        }

        this.CurrentRowIndex = Limits.MinIndex;
        this.CurrentColumnIndex = Limits.MinIndex;
    }

    public bool IsCompleted { get; private set; }

    private bool IsInFieldRange => this.CurrentColumnIndex <= Limits.MaxIndex
                                && this.CurrentRowIndex <= Limits.MaxIndex;

    private bool IsStepSucceded { get; set; }

    private void OnCellPossibleValueChanged(object? sender, EventArgs e) => this.IsStepSucceded = true;

    public void PlayStep()
    {
        this.HandlePossibles();

        if (this.IsStepSucceded)
        {
            this.IsStepSucceded = false;
            this.UpdateIsCompleted();
            return;
        }

        this.HandleHiddenSingles();

        if (this.IsStepSucceded)
        {
            this.IsStepSucceded = false;
            this.UpdateIsCompleted();
            return;
        }

        this.HandleNakedPairs();

        if (this.IsStepSucceded)
            this.IsStepSucceded = false;

        this.UpdateIsCompleted();
    }

    public IPlayableElement<ICell>[] Rows { get; init; }

    private void SubscribeCellEvent(ICell cell) => cell.PossibleValueChanged += this.OnCellPossibleValueChanged;

    private void UnSubscribeCellEvent(ICell cell) => cell.PossibleValueChanged -= this.OnCellPossibleValueChanged;

    private void UpdateIsCompleted()
    {
        if (!this.Rows.Any(row => !row.IsCompleted))
            this.IsCompleted = true;
    }

    private void MarkAsProcessed()
    {
        foreach (var row in this.Rows)
            row.IsInProcessOfUpdate = false;

        foreach (var column in this.Columns)
            column.IsInProcessOfUpdate = false;

        foreach (var block in this.Blocks)
            block.IsInProcessOfUpdate = false;
    }
}
