using LambdaExpression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LambdaExpression.Test
{
    [TestClass]
    public class MyExtensionsSpec
    {
        private IEnumerable<Product> _products = new Product[] { 
                new Product{Price= 3, Category=  "Food" },
                new Product{Price= 29, Category="Clothes"},
                new Product{Price=50, Category="Electronics"}
            };

        [TestMethod]
        public void Can_Calculate_Total_Prices_Of_Products()
        {
            //  Arrange
            decimal expected = 50 + 29 + 3;
            //  Act
            decimal actual = _products.TotalPrices();

            //  Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Filter_Products_By_Category()
        {
            //  Arrange
            string category = "Clothes";
            IEnumerator<Product> expectedEnumerator = _products.GetEnumerator();
            expectedEnumerator.MoveNext();
            expectedEnumerator.MoveNext();
            Product expected = expectedEnumerator.Current;

            //  Act
            IEnumerable<Product> actual = _products.FilterByCategory(category);

            //  Assert
            Assert.IsNotNull(actual);
            IEnumerator<Product> actualEnumerator = actual.GetEnumerator();
            actualEnumerator.MoveNext();
            Assert.AreEqual(expected, actualEnumerator.Current);
        }

        [TestMethod]
        public void Can_Filter_Products_By_Selector()
        {
            // TODO: Arrange
            IEnumerator<Product> expectedEnumerator = _products.GetEnumerator();
            expectedEnumerator.MoveNext();
            Product expected1 = expectedEnumerator.Current;
            expectedEnumerator.MoveNext();
            Product expected2 = expectedEnumerator.Current;

            // TODO: Act
            IEnumerable<Product> actual = _products.Filter(product => product.Price < 50);

            // TODO: Assert
            IEnumerator<Product> actualEnumerator = actual.GetEnumerator();
            actualEnumerator.MoveNext();
            Assert.AreEqual(expected1, actualEnumerator.Current);
            actualEnumerator.MoveNext();
            Assert.AreEqual(expected2, actualEnumerator.Current);
        }
    }
}
