using SodukuSolver.Business.Base;
using SodukuSolver.Business.Interfaces;

namespace SodukuSolver.Business.Concrete;

internal sealed class Block : SetOfCellsBase
{
    protected override void InitializeCell(ICell cell)
    {
        cell.Block = this;
    }
}
