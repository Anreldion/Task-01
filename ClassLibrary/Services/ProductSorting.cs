using System;
using System.Linq;
using ClassLibrary.Products;
using ClassLibrary.Services.Interfaces;
using ClassLibrary.Utilities;

namespace ClassLibrary.Services
{
    /// <summary>
    /// Provides sorting operations for arrays of baked products.
    /// </summary>
    public class ProductSorting : IProductSorting
    {
        /// <summary>
        /// Creates a deep copy of the array and sorts the products by total calories.
        /// </summary>
        /// <param name="products">The source array of products.</param>
        /// <returns>A new array sorted by caloric content in ascending order.</returns>
        public BakedProduct[] CloneAndSortByCalories(BakedProduct[] products)
        {
            Guard.NotNull(products, nameof(products));

            var cloned = products.Select(p => (BakedProduct)p.Clone()).ToArray();
            return cloned.OrderBy(p => p.GetCalories()).ToArray();
        }

        /// <summary>
        /// Creates a shallow copy of the array and sorts the products by total price.
        /// </summary>
        /// <param name="products">The source array of products.</param>
        /// <returns>A new array sorted by price in ascending order.</returns>
        public BakedProduct[] CopyAndSortByPrice(BakedProduct[] products)
        {
            Guard.NotNull(products, nameof(products));

            var copied = new BakedProduct[products.Length];
            Array.Copy(products, copied, products.Length);
            return copied.OrderBy(p => p.GetPrice()).ToArray();
        }
    }
}