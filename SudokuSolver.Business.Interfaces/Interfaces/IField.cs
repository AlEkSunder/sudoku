namespace SodukuSolver.Business.Interfaces;

public interface IField: IDisposable
{
    bool IsCompleted { get; }

    void PlayStep();

    IPlayableElement<ICell>[] Rows { get; }
}
