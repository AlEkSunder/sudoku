namespace SodukuSolver.Business.Interfaces;

public interface IFieldFactory
{
    IField CreateField(int[,] arrayOfNumbers);
}
