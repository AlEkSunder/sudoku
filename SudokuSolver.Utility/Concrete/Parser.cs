using CommunityToolkit.Diagnostics;
using SodukuSolver.Business.Constants;
using SodukuSolver.Utility.Exceptions;
using SodukuSolver.Utility.Interfaces;

namespace SodukuSolver.Utility.Concrete;

public class Parser : IParser
{
    public int[,] Parse(string data)
    {
        Guard.IsNotNullOrWhiteSpace(data);

        var rows = data.Split(Environment.NewLine);

        if (rows.Length < Limits.NumberOfPossibleValues)
            throw new ParserException("The data contains less than expected number of rows.");

        var arrayOfNumbers = new int[Limits.NumberOfPossibleValues, Limits.NumberOfPossibleValues];

        for (int rowIndex = 0; rowIndex < Limits.NumberOfPossibleValues; rowIndex++)
        {
            if (rows[rowIndex].Length != Limits.NumberOfPossibleValues)
                throw new ParserException($"There should be {Limits.NumberOfPossibleValues} digits at the row {rowIndex + 1}.");

            for (int columnIndex = 0; columnIndex < Limits.NumberOfPossibleValues; columnIndex++)
            {

                var digit = rows[rowIndex][columnIndex];

                if (!char.IsDigit(digit))
                    throw new ParserException($"The char {digit} is not a digit. Check data");

                arrayOfNumbers[rowIndex, columnIndex] = this.ToInt(digit);
            }
        }

        return arrayOfNumbers;
    }

    private int ToInt(char digit) => digit - '0';
}
