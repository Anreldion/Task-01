using System;
using ClassLibrary.enums;
using ClassLibrary.Ingredients;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Utilities;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Baked Product
    /// </summary>
    public class BakedProduct : IBakedProduct, ICloneable
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product category
        /// </summary>
        public ProductCategories ProductCategory { get; set; }

        /// <summary>
        /// Margin coefficient
        /// </summary>
        public double MarginCoefficient { get; set; }


        /// <summary>
        /// List of Ingredients
        /// </summary>
        public List<Ingredient> Ingredients { get; set; }

        public BakedProduct()
        {
        }

        public BakedProduct(string name, ProductCategories categories, double marginCoefficient, List<Ingredient> ingredients)
        {
            Guard.NotNull(name, nameof(name));
            Guard.NotNull(ingredients, nameof(ingredients));
            Guard.NotEmpty(ingredients, nameof(ingredients));

            Name = name;
            ProductCategory = categories;
            MarginCoefficient = marginCoefficient;
            Ingredients = ingredients;
        }

        /// <summary>
        /// Get calories
        /// </summary>
        public double GetCalories() => Ingredients.Sum(item => item.Calorie * item.Weight);

        /// <summary>
        /// Price Calculate
        /// </summary>
        public double GetPrice()
        {
            var price = Ingredients.Sum(item => item.Price * item.Weight);
            price *= MarginCoefficient; 
            return price; 
        }

        public object Clone()
        {
            return new BakedProduct(Name, ProductCategory, MarginCoefficient,
                Ingredients.Select(ing => (Ingredient) ing.Clone()).ToList());
        }

        public override string ToString()
        {
            return $"{Name} ({ProductCategory}) - {GetPrice():F2} $ / {GetCalories():F0} kcal";

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ingredients, MarginCoefficient, ProductCategory, Name);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is BakedProduct item && item.Name == Name && item.ProductCategory == ProductCategory &&
                   Math.Abs(item.MarginCoefficient - MarginCoefficient) < 0.01 && item.Ingredients.OrderBy(i => i.Name)
                       .SequenceEqual(Ingredients.OrderBy(i => i.Name));
        }
    }
}
