using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMastersPOS.UnitTests
{
    [TestClass]
    public class ChangeCalculatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateChange_ProductPriceIsZero_ThrowsAnException()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 0;
            var list = new List<double> { 10.0 };

            // Act
            changeCalculator.CalculateChange(productPrice, list);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateChange_BillsAndCoinsProvidedIsNull_ThrowsAnException()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 1;

            // Act
            changeCalculator.CalculateChange(productPrice, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateChange_BillsAndCoinsProvidedIsEmpty_ThrowsAnException()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 1;

            // Act
            changeCalculator.CalculateChange(productPrice, new List<double>());
        }

        [TestMethod]
        public void CalculateChange_ChangeAmount_ShouldReturnPositiveNumber4()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 6.0;
            var list = new List<double> { 5.0, 5.0 };

            // Act
            var result = changeCalculator.CalculateChange(productPrice, list);
            var expected = 4;

            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateChange_ChangeAmount_ShouldReturnNegativeNumber2()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 12.0;
            var list = new List<double> { 5.0, 5.0 };

            // Act
            var result = changeCalculator.CalculateChange(productPrice, list);
            var expected = -2;

            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateChangeDenominations_ProductPriceIsZero_ThrowsAnException()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 0;
            var list = new List<double> { 10.0 };

            // Act
            changeCalculator.CalculateChangeDenominations(productPrice, list);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateChangeDenominations_BillsAndCoinsProvidedIsNull_ThrowsAnException()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 1;

            // Act
            changeCalculator.CalculateChangeDenominations(productPrice, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateChangeDenominations_BillsAndCoinsProvidedIsEmpty_ThrowsAnException()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 1;

            // Act
            changeCalculator.CalculateChangeDenominations(productPrice, new List<double>());
        }

        [TestMethod]
        public void CalculateChangeDenomination_ChangeDenominations_ShouldReturnAListWithFourValues()
        {
            // Arrange
            var changeCalculator = new ChangeCalculator();
            var productPrice = 5.25;
            var list = new List<double> { 5.0, 5.0 };

            // Act
            var result = changeCalculator.CalculateChangeDenominations(productPrice, list);
            var expected = 4;

            // Assert
            Assert.AreEqual(result.Count, expected);
        }
    }
}
