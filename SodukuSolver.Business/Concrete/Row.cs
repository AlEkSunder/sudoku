using SodukuSolver.Business.Base;
using SodukuSolver.Business.Interfaces;

namespace SodukuSolver.Business.Concrete;

internal sealed class Row : SetOfCellsBase
{
    protected override void InitializeCell(ICell cell)
    {
        cell.Row = this;
    }
}
