using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CashMastersPOS.UnitTests
{
    [TestClass]
    public class OrderProcessorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_ProductIsNull_ThrowsAnException()
        {
            // Arrange
            var orderProcessor = new OrderProcessor(new FakeChangeCalculator());
            var list = new List<double> { 10.0 };

            // Act
            orderProcessor.Process(null, list);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_BillsAndCoinsIsNull_ThrowsAnException()
        {
            // Arrange
            var orderProcessor = new OrderProcessor(new FakeChangeCalculator());
            var product = new Product(1.0);

            // Act
            orderProcessor.Process(product, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_BillsAndCoinsIsEmpty_ThrowsAnException()
        {
            // Arrange
            var orderProcessor = new OrderProcessor(new FakeChangeCalculator());
            var product = new Product(1.0);
            var list = new List<double>();

            // Act
            orderProcessor.Process(product, list);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProcessChange_AmountProvidedByCustomerIsIncorrect_ThrowsAnException()
        {
            // Arrange
            var orderProcessor = new OrderProcessor(new FakeChangeCalculator());
            var product = new Product(5.25);
            var list = new List<double> {2.0};

            // Act
            orderProcessor.Process(product, list);
        }
    }

    public class FakeChangeCalculator : ICalculator
    {
        public double CalculateChange(double productPrice, List<double> billsAndCoinsProvided)
        {
            return -1;
        }

        public List<double> CalculateChangeDenominations(double productPrice, List<double> billsAndCoinsProvided)
        {
            return new List<double> { 1.0 };
        }
    }
}
