namespace SodukuSolver.Business.Interfaces;

public interface IPlayableElement<T> where T: IValue
{
    T this[int index] { get; }

    void Add(T cell);

    void DefineSingles();

    void HandleNakedPairs();

    bool HasNumber(int number);

    bool IsCompleted { get; }

    bool IsInProcessOfUpdate { get; set; }

    void RemovePossibleNumber(int number);
}
