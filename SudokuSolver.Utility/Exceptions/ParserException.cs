namespace SodukuSolver.Utility.Exceptions;

public sealed class ParserException : ApplicationException
{
    public ParserException(string message)
        : base(message)
    {
    }
}
