using System;
using System.Collections.Generic;

namespace LambdaExpression
{
    public static class MyExtensions
    {
        /// <summary>
        /// Get total price of a Collection of <see cref="Product"/>s.
        /// </summary>
        /// <param name="products">Collection of products</param>
        /// <returns></returns>
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach(Product product in products){
                total += product.Price;
            }

            return total;
        }

        /// <summary>
        /// Filter a collection of <see cref="Product"/>s by specified <paramref name="categoryParam"/>.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="categoryParam"></param>
        /// <returns></returns>
        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> products, string categoryParam)
        {
            foreach (Product product in products)
            {
                if (product.Category == categoryParam)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product, bool> selectorParam)
        {
            foreach (Product product in products)
            {
                if (selectorParam(product))
                {
                    yield return product;
                }
            }
        }
    }
}
