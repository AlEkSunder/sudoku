using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodukuSolver.Business.Constants;
using SodukuSolver.Utility.Concrete;
using SodukuSolver.Utility.Exceptions;

namespace SudokuSolver.Business.UnitTest
{
    [TestClass]
    public class ParserTest
    {
        private Parser Parser { get; set; }

        [TestInitialize]
        public void Initialize() => this.Parser = new Parser();

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void Parse_DataContainsLessLinesThanRequired_ArgumentExceptionIsThrowed()
        {
            //
            // Arrange.
            //
            string data = $"123{Environment.NewLine}333{Environment.NewLine}2323";

            //
            // Act.
            //
            this.Parser.Parse(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void Parse_DataContainsLetter_ArgumentExceptionIsThrowed()
        {
            //
            // Arrange.
            //
            string data = $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"12345678a{Environment.NewLine}";
            //
            // Act.
            //
            this.Parser.Parse(data);
        }

        [TestMethod]
        public void Parse_DataIsCorrect_ReturnsParsedArrayOfIntegers()
        {
            //
            // Arrange.
            //
            string data = $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}";

            var expectedResult = new int[Limits.NumberOfPossibleValues, Limits.NumberOfPossibleValues]
            {
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };

            //
            // Act.
            //
            var actualResult = this.Parser.Parse(data);

            //
            // Assert
            //
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_DataIsEmpty_ArgumentExceptionIsThrowed()
        {
            //
            // Arrange.
            //
            string data = string.Empty;

            //
            // Act.
            //
            this.Parser.Parse(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_DataIsNull_ArgumentNullExceptionIsThrowed()
        {
            //
            // Arrange.
            //
            string data = null;

            //
            // Act.
            //
            this.Parser.Parse(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_DataIsSpace_ArgumentExceptionIsThrowed()
        {
            //
            // Arrange.
            //
            string data = " ";

            //
            // Act.
            //
            this.Parser.Parse(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void Parse_DataRowContainsGreaterNumerOfDigitsThanRequired_ArgumentExceptionIsThrowed()
        {
            //
            // Arrange.
            //
            string data = $"1234567890{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}";

            //
            // Act.
            //
            this.Parser.Parse(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void Parse_DataRowContainsLessNumerOfDigitsThanRequired_ArgumentExceptionIsThrowed()
        {
            //
            // Arrange.
            //
            string data = $"12345678{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}" +
                          $"123456789{Environment.NewLine}";

            //
            // Act.
            //
            this.Parser.Parse(data);
        }
    }
}
