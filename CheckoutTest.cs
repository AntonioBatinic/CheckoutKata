using CheckoutKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout_Kata.Tests
{
    [TestFixture]
    public class CheckoutTest
    {
        [Test]
        public void AddNoItems_TotalIsZero()
        {
            // Arrange
            var checkout = new Checkout();

            // Act + Assert
            Assert.AreEqual(0, checkout.Total);
        }

        [TestCase('A', 10.0)]
        [TestCase('B', 15.0)]
        [TestCase('C', 40.0)]
        [TestCase('D', 55.0)]
        public void AddOneItem_TotalIsValueItem(char item, double total)
        {
            // Arrange
            var checkout = new Checkout();

            // Act
            checkout.AddItem(item);

            // Assert
            Assert.AreEqual(total, checkout.Total);
        }

        private void AddMultipleItems(string items, double total)
        {
            // Arrange
            var checkout = new Checkout();

            // Act
            for (int i = 0; i < items.Length; i++)
            {
                checkout.AddItem(items[i]);
            }

            // Assert
            Assert.AreEqual(total, checkout.Total);
        }

        [TestCase("AA", 20.0)]
        [TestCase("AB", 25.0)]
        [TestCase("ABC", 65.0)]
        [TestCase("ABCD", 120.0)]
        public void AddMultipleItems_TotalIsSum(string items, double total)
        {
            AddMultipleItems(items, total);
        }

        [TestCase("AAA", 30.0)]
        [TestCase("BBB", 40.0)]
        [TestCase("DD", 82.5)]
        public void AddMultipleItemsWithOffer_TotalIsSumSubtractDiscount(string items, double total)
        {
            AddMultipleItems(items, total);
        }
    }
}
