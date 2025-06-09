using System;
using ClassLibrary.enums;
using ClassLibrary.Ingredients;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Utilities;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Represents a baked product such as bread, pita, or loaf.
    /// </summary>
    public class BakedProduct : IBakedProduct, ICloneable
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of the baked product.
        /// </summary>
        public ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the markup applied to the product price.
        /// </summary>
        public double Markup { get; set; }


        /// <summary>
        /// Gets or sets the list of ingredients in the product.
        /// </summary>
        public List<Ingredient> Ingredients { get; set; }

        public BakedProduct() { }

        public BakedProduct(string name, ProductCategory category, double markup, List<Ingredient> ingredients)
        {
            Guard.NotNull(name, nameof(name));
            Guard.NotNull(ingredients, nameof(ingredients));
            Guard.NotEmpty(ingredients, nameof(ingredients));

            Name = name;
            ProductCategory = category;
            Markup = markup;
            Ingredients = ingredients;
        }

        /// <summary>
        /// Calculates the total caloric value of the product.
        /// </summary>
        public double GetCalories() => Ingredients.Sum(item => item.Calorie * item.Weight);

        /// <summary>
        /// Calculates the total price of the product including markup.
        /// </summary>
        public double GetPrice()
        {
            var price = Ingredients.Sum(item => item.Price * item.Weight);
            price *= Markup; 
            return price; 
        }
        /// <summary>
        /// Creates a deep copy of the baked product, including its ingredients.
        /// </summary>
        public object Clone()
        {
            return new BakedProduct(new string(Name), ProductCategory, Markup,
                Ingredients.Select(ing => (Ingredient) ing.Clone()).ToList());
        }

        public override string ToString()
        {
            return $"{Name} ({ProductCategory}) - {GetPrice():F2} $ / {GetCalories():F0} kcal";

        }

        public override int GetHashCode()
        {
            var ingredientHash = Ingredients?
                .OrderBy(i => i.Name)
                .Select(i => i.GetHashCode())
                .Aggregate(0, HashCode.Combine) ?? 0;

            return HashCode.Combine(ingredientHash, Markup, ProductCategory, Name ?? string.Empty);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is BakedProduct item && item.Name == Name && item.ProductCategory == ProductCategory &&
                   Math.Abs(item.Markup - Markup) < 0.01 && item.Ingredients.OrderBy(i => i.Name)
                       .SequenceEqual(Ingredients.OrderBy(i => i.Name));
        }
    }
}
