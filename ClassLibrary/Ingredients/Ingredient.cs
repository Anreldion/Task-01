using ClassLibrary.Utilities;
using System;

namespace ClassLibrary.Ingredients
{
    /// <summary>
    /// Ingredient.
    /// </summary>
    public class Ingredient : ICloneable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ingredient()
        {
        }

        public Ingredient(string name, double calorie, double price, double weight)
        {
            Guard.NotNull(name, nameof(name));
            Guard.AgainstNegative(calorie,nameof(calorie));
            Guard.AgainstNegative(price, nameof(price));
            Guard.AgainstNegative(weight, nameof(weight));

            Name = name;
            Calorie = calorie;
            Price = price;
            Weight = weight;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Calorie
        /// </summary>
        public double Calorie { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }

        public object Clone()
        {
            return new Ingredient(Name, Calorie, Price, Weight);
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
