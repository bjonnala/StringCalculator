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

        


    }
}
