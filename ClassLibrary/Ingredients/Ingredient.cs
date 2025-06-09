using ClassLibrary.Utilities;
using System;

namespace ClassLibrary.Ingredients
{
    /// <summary>
    /// Represents a single ingredient used in a baked product.
    /// </summary>
    public class Ingredient : ICloneable
    {
        public Ingredient() { }

        public Ingredient(string name, double calorie, double price, double weight)
        {
            Guard.NotNull(name, nameof(name));
            Guard.AgainstNegative(calorie, nameof(calorie));
            Guard.AgainstNegative(price, nameof(price));
            Guard.AgainstNegative(weight, nameof(weight));

            Name = name;
            Calorie = calorie;
            Price = price;
            Weight = weight;
        }

        /// <summary>
        /// Gets or sets the name of the ingredient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the caloric value per 1 unit of weight.
        /// </summary>
        public double Calorie { get; set; }

        /// <summary>
        /// Gets or sets the price per unit of weight.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the weight used in the product.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Creates a deep copy of the ingredient.
        /// </summary>
        public object Clone()
        {
            return new Ingredient(new string(Name), Calorie, Price, Weight);
        }

        public override string ToString()
        {
            return $"{Name} ({Weight}) - {Price:F2} $ / {Calorie:F0} kcal";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Calorie, Price, Weight);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is Ingredient item && item.Name == Name &&
                   Math.Abs(item.Calorie - Calorie) < 0.01 &&
                   Math.Abs(item.Price - Price) < 0.01 &&
                   Math.Abs(item.Weight - Weight) < 0.01;
        }
    }
}
