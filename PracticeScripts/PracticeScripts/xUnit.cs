using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PracticeScripts
{
    internal class xUnit
    {
    }
    /*
    xUnit is a unit testing framework for .NET that:

        Follows the arrange-act-assert pattern
        Uses attributes to define tests and setup/teardown methods
        Supports data-driven tests via [Theory] and [InlineData]
        Is extensible with custom attributes and assertions

        Key differences:
            NUnit: [Test] vs xUnit's [Fact]/[Theory]
            MSTest: More Microsoft-integrated, xUnit is more community-driven
            xUnit doesn't have [SetUp]/[TearDown] - uses constructor and IDisposable
      
         Attributes in xUnit
                [Fact] - A test method that takes no parameters
                [Theory] - A test method that takes parameters (data-driven tests)
                [InlineData] - Provides data for theory tests
                [MemberData] - Gets data from a property or method
                [ClassData] - Gets data from a class
                [Trait] - Categorizes tests (e.g., [Trait("Category", "Integration")])
     */
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests() // Setup
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(8, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, 1, 0)]
        public void Add_VariousNumbers_ReturnsCorrectSum(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }

    public class Calculator
    {
        public int Add(int a, int b) => a + b;
    }
}
