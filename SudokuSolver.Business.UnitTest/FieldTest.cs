using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodukuSolver.Business.Constants;
using SodukuSolver.Business.Factories;

namespace SudokuSolver.Business.UnitTest
{
    [TestClass]
    public class FieldTest
    {
        private int[,] ActField(int[,] puzzle)
        {
            var field = new FieldFactory().CreateField(puzzle);

            while (!field.IsCompleted)
                field.PlayStep();

            var actualResult = new int[Limits.NumberOfPossibleValues, Limits.NumberOfPossibleValues];

            for (int rowIndex = 0; rowIndex < Limits.NumberOfPossibleValues; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Limits.NumberOfPossibleValues; columnIndex++)
                {
                    actualResult[rowIndex, columnIndex] = field.Rows[rowIndex][columnIndex].Value;
                }
            }

            return actualResult;
        }

        [TestMethod]
        public void PlayStep_SolvesPuzzle1Correctly()
        {
            //
            // Arrange.
            //
            var puzzle = new int[,]
            {
                { 0, 0, 0, 7, 0, 2, 0, 0, 0 },
                { 3, 0, 0, 0, 4, 0, 0, 0, 6 },
                { 4, 0, 6, 5, 0, 0, 0, 0, 0 },
                { 0, 0, 5, 0, 2, 0, 0, 9, 3 },
                { 0, 2, 0, 0, 0, 0, 0, 8, 0 },
                { 1, 6, 0, 0, 5, 0, 4, 0, 0 },
                { 0, 0, 0, 0, 0, 8, 3, 0, 1 },
                { 6, 0, 0, 0, 9, 0, 0, 0, 7 },
                { 0, 0, 0, 2, 0, 5, 0, 0, 0 }
            };
            var expectedResult = new int[,]
            {
                { 5, 9, 1, 7, 6, 2, 8, 3, 4 },
                { 3, 8, 2, 9, 4, 1, 7, 5, 6 },
                { 4, 7, 6, 5, 8, 3, 2, 1, 9 },
                { 8, 4, 5, 1, 2, 7, 6, 9, 3 },
                { 9, 2, 7, 4, 3, 6, 1, 8, 5 },
                { 1, 6, 3, 8, 5, 9, 4, 7, 2 },
                { 2, 5, 9, 6, 7, 8, 3, 4, 1 },
                { 6, 1, 8, 3, 9, 4, 5, 2, 7 },
                { 7, 3, 4, 2, 1, 5, 9, 6, 8 }
            };

            //
            // Act.
            //
            var actualResult = this.ActField(puzzle);

            //
            // Assert.
            //
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PlayStep_SolvesPuzzle2Correctly()
        {
            //
            // Arrange.
            //
            var puzzle = new int[,]
            {
                { 8, 3, 2, 0, 0, 0, 0, 0, 5 },
                { 0, 6, 0, 9, 0, 7, 0, 0, 0 },
                { 9, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 2, 0, 3, 0, 1 },
                { 0, 9, 0, 7, 0, 4, 0, 8, 0 },
                { 7, 0, 3, 0, 6, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 3 },
                { 0, 0, 0, 5, 0, 8, 0, 6, 0 },
                { 5, 0, 0, 0, 0, 0, 9, 1, 4 }
            };
            var expectedResult = new int[,]
            {
                { 8, 3, 2, 6, 4, 1, 7, 9, 5 },
                { 4, 6, 5, 9, 8, 7, 1, 3, 2 },
                { 9, 1, 7, 2, 5, 3, 6, 4, 8 },
                { 6, 5, 4, 8, 2, 9, 3, 7, 1 },
                { 2, 9, 1, 7, 3, 4, 5, 8, 6 },
                { 7, 8, 3, 1, 6, 5, 4, 2, 9 },
                { 1, 7, 6, 4, 9, 2, 8, 5, 3 },
                { 3, 4, 9, 5, 1, 8, 2, 6, 7 },
                { 5, 2, 8, 3, 7, 6, 9, 1, 4 }
            };

            //
            // Act.
            //
            var actualResult = this.ActField(puzzle);

            //
            // Assert.
            //
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}