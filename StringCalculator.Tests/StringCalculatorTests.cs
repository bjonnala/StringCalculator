using NUnit.Framework;
using System;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        readonly string operand = string.Empty;
        private readonly IStringCal _stringcalService;

        public StringCalculatorTests()
        {
            operand = "+";
            _stringcalService = new StringCal();
        }

        [TestCase("")]
        public void CanHandleEmptyNumbers(string input)
        {
            //// Arrange
            var expectedOutput = 0;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestCase("1")]
        [TestCase("2")]
        public void CanHandleOneNumber(string input)
        {
            // Arrange
            var expectedOutput = Int32.Parse(input);
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("1,2")]
        public void CanHandleTwoNumbers(string input)
        {
            //// Arrange
            var expectedOutput = 3;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("1,34,4,2,98,1,2")]
        public void CanHandleUnknownAmountOfNumbers(string input)
        {
            //// Arrange
            var expectedOutput = 142;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("0\n,3,3")]
        [TestCase("1\n,2,3")]
        public void CanHandleNewLinesBetweenNumbers(string input)
        {
            //// Arrange
            var expectedOutput = 6;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("1,\n")]
        [TestCase("2,\n")]
        [TestCase("1,\n,3")]
        [TestCase("1,5,\n")]
        [TestCase("1,2,3,\n")]
        public void CanHandleNewLinesBetweenNumbersIncorrectCase(string input)
        {
            var ex = Assert.Throws<ArgumentException>(() => _stringcalService.Operation(operand, input.Trim()));
            Assert.That(ex.Message, Is.EqualTo("Invalid Input"));
        }

        [TestCase("//;\n1;2")]
        [TestCase("//,\n1,2")]
        [TestCase("//&\n1&2")]
        [TestCase("//$\n1$2")]
        [TestCase("//@\n1@2")]
        public void CanHandleVariousDelimitersBetweenNumbers(string input)
        {
            //// Arrange
            var expectedOutput = 3;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("-1")]
        [TestCase("-1,-4")]
        [TestCase("-1,-3,-4")]
        public void ThrowExceptionForNegativeNumbers(string input)
        {
            var ex = Assert.Throws<ArgumentException>(() => _stringcalService.Operation(operand, input.Trim()));
            Assert.That(ex.Message, Is.EqualTo("negatives not allowed " + input.Trim()));
        }


        [TestCase("2,1001")]
        [TestCase("2,1002")]
        [TestCase("2,2000")]
        public void CanHandleNumbersGreaterThan1000(string input)
        {
            //// Arrange
            var expectedOutput = 2;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("2,1000")]
        public void CanHandleNumbersUpto1000(string input)
        {
            //// Arrange
            var expectedOutput = 1002;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("//[***]\n1***2***3")]
        public void CanHandleDelimitersOfAnyLengthAndFormat(string input)
        {
            //// Arrange
            var expectedOutput = 6;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("//[*][%]\n1*2%3")]
        public void CanHandleMultipleDelimiters(string input)
        {
            //// Arrange
            var expectedOutput = 6;
            //// Act
            var actualOutput = _stringcalService.Operation(operand, input.Trim());
            //// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
