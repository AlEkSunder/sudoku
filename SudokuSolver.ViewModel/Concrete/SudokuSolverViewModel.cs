using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SodukuSolver.Business.Interfaces;
using SodukuSolver.Utility.Interfaces;
using System.ComponentModel;

namespace SudokuSolver.ViewModel.Concrete;

public sealed class SudokuSolverViewModel : ObservableObject
{
    private BindingList<RowViewModel> rows;
    private readonly IRelayCommand nextStep;

    private IField Field { get; }

    public bool IsFinished { get; private set; }

    public IRelayCommand NextStep => this.nextStep ?? new RelayCommand(this.NextStepExecuted);

    private void NextStepExecuted()
    {
        this.Field.PlayStep();

        foreach (var row in this.Rows)
            row.NotifyPropertyChanged();

        if (this.Field.IsCompleted)
            this.IsFinished = true;
    }

    public BindingList<RowViewModel> Rows
    {
        get => this.rows;
        set => this.SetProperty(ref this.rows, value);
    }

    public SudokuSolverViewModel(IFieldFactory fieldFactory, IDataProvider dataProvider)
    {
        this.Field = fieldFactory.CreateField(dataProvider.GetPuzzleData());

        this.Rows = new BindingList<RowViewModel>();

        foreach (var row in this.Field.Rows)
            this.Rows.Add(new RowViewModel(row));
    }
}
