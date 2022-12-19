using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using SodukuSolver.Business.Interfaces;

namespace SudokuSolver.ViewModel.Concrete;

public sealed class RowViewModel : ObservableObject
{
	private readonly IPlayableElement<ICell> row;

    public char Cell1 => this.GetCellValue(0);

    public char Cell2 => this.GetCellValue(1);

    public char Cell3 => this.GetCellValue(2);

    public char Cell4 => this.GetCellValue(3);

    public char Cell5 => this.GetCellValue(4);

    public char Cell6 => this.GetCellValue(5);

    public char Cell7 => this.GetCellValue(6);

    public char Cell8 => this.GetCellValue(7);

    public char Cell9 => this.GetCellValue(8);

    private char GetCellValue(int index)
    {
        var cell = this.row[index];

        return cell.Value == default ? ' ' : cell.Value.ToString().Single();
    }

    public void NotifyPropertyChanged()
    {
        this.OnPropertyChanged(nameof(this.Cell1));
        this.OnPropertyChanged(nameof(this.Cell2));
        this.OnPropertyChanged(nameof(this.Cell3));
        this.OnPropertyChanged(nameof(this.Cell4));
        this.OnPropertyChanged(nameof(this.Cell5));
        this.OnPropertyChanged(nameof(this.Cell6));
        this.OnPropertyChanged(nameof(this.Cell7));
        this.OnPropertyChanged(nameof(this.Cell8));
        this.OnPropertyChanged(nameof(this.Cell9));
    }

    public RowViewModel(IPlayableElement<ICell> row)
	{
        Guard.IsNotNull(row);

		this.row = row;
	}
}
