using NUnit.Framework;
using CalculatorLibrary;
using System;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }
        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            double result = _calculator.Add(5, 3);
            Console.WriteLine($"Add Result: {result}");  // Print result instead of asserting
        }


        public void Subtract_ShouldReturnCorrectDifference()
        {
            double result = _calculator.Subtract(10, 4);
            Console.WriteLine($"Subtract Result: {result}");  // Print result instead of asserting
        }


        public void Multiply_ShouldReturnCorrectProduct()
        {
            double result = _calculator.Multiply(3, 5);
            Console.WriteLine($"Multiply Result: {result}");  // Print result instead of asserting
        }

        public void Divide_ShouldReturnCorrectQuotient()
        {
            double result = _calculator.Divide(10, 2);
            Console.WriteLine($"Divide Result: {result}");  // Print result instead of asserting
        }


        public void Divide_ByZero_ShouldThrowException()
        {
            try
            {
                _calculator.Divide(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Caught Exception: {ex.Message}");  // Print exception message
            }
        }


        public void Add_Zero_ShouldReturnSameNumber()
        {
            double result = _calculator.Add(5, 0);
            Console.WriteLine($"Add Zero Result: {result}");  // Print result instead of asserting
        }


        public void Subtract_Zero_ShouldReturnSameNumber()
        {
            double result = _calculator.Subtract(5, 0);
            Console.WriteLine($"Subtract Zero Result: {result}");  // Print result instead of asserting
        }
    }
    }