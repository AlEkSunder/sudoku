using SodukuSolver.Business.Base;
using SodukuSolver.Business.Interfaces;

namespace SodukuSolver.Business.Concrete;

internal sealed class Column : SetOfCellsBase
{
    protected override void InitializeCell(ICell cell)
    {
        cell.Column = this;
    }
}
