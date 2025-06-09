using ClassLibrary.Products;
using ClassLibrary.Services.Interfaces;
using System;
using System.Linq;
using ClassLibrary.Utilities;

namespace ClassLibrary.Services
{
    /// <summary>
    /// Provides methods for searching baked products based on various criteria.
    /// </summary>
    public class ProductFinding : IProductFinding
    {
        private const double Tolerance = 0.1;

        /// <summary>
        /// Finds all baked products that have the same price and calories as the given reference referenceProduct.
        /// Uses a small tolerance to account for floating-point precision.
        /// </summary>
        /// <param name="products">The array of baked products to search.</param>
        /// <param name="price"></param>
        /// <param name="calories"></param>
        /// <returns>
        /// An array of baked products whose total price and caloric content 
        /// are within a small tolerance of the reference referenceProduct.
        /// </returns>
        public BakedProduct[] FindByPriceAndCalories(BakedProduct[] products, double price, double calories)
        {
            Guard.NotNull(products, nameof(products));
            Guard.AgainstNegative(price, nameof(price));
            Guard.AgainstNegative(calories, nameof(calories));

            return products.Where(x =>
                Math.Abs(x.GetPrice() - price) < Tolerance &&
                Math.Abs(x.GetCalories() - calories) < Tolerance).ToArray();
        }

        /// <summary>
        /// Finds all baked products that contain a specified ingredient 
        /// in a quantity greater than the provided threshold.
        /// </summary>
        /// <param name="products">The array of baked products to search.</param>
        /// <param name="ingredientName">The name of the ingredient to look for.</param>
        /// <param name="minWeight">The minimum minWeight threshold of the ingredient.</param>
        /// <returns>
        /// An array of baked products where the specified ingredient is used 
        /// in an amount greater than the given threshold.
        /// </returns>
        public BakedProduct[] FindByIngredientWeightThreshold(BakedProduct[] products, string ingredientName, double minWeight)
        {
            Guard.NotNull(products, nameof(products));
            Guard.NotNull(ingredientName, nameof(ingredientName));
            Guard.AgainstNegative(minWeight, nameof(minWeight));

            return products.Where(item => item.Ingredients.Any(i => i.Name == ingredientName && i.Weight > minWeight))
                .ToArray();
        }

        /// <summary>
        /// Finds all baked products that contain more ingredients than the specified number.
        /// </summary>
        /// <param name="products">The array of baked products to search.</param>
        /// <param name="minIngredientCount">The minimum number of ingredients required.</param>
        /// <returns>
        /// An array of baked products that contain more ingredients than the specified count.
        /// </returns>
        public BakedProduct[] FindByIngredientCountThreshold(BakedProduct[] products, int minIngredientCount)
        {
            Guard.NotNull(products, nameof(products));
            Guard.AgainstNegative(minIngredientCount, nameof(minIngredientCount));

            return products.Where(x => x.Ingredients.Count > minIngredientCount).ToArray();
        }
    }
}
