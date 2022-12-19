namespace SodukuSolver.Business.Interfaces;

public interface ICell : IValue
{
    event EventHandler PossibleValueChanged;

    int this[int index] { get; }

    IPlayableElement<ICell> Block { get; set; }

    IPlayableElement<ICell> Column { get; set; }

    void TryRemove(int number);

    bool IsOnlyAvailableValue { get; }

    List<int> PossibleNumbers { get; }

    int PossibleNumbersCount { get; }

    IEnumerable<int> RemainingNumbers { get; }

    void RemovePossibleNumber(int number);

    IPlayableElement<ICell> Row { get; set; }
}
