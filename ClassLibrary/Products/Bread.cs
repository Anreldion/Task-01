using ClassLibrary.enums;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Хлеб
    /// </summary>
    public class Bread : BakeryProduct
    {
        public Bread()
        {
        }
        public Bread(string name, double marginCoefficient)
        {
            Name = name;
            MarginCoefficient = marginCoefficient;
        }

        public override string Name { get; set; } = "Bread";
        public override ProductCategories ProductCategory { get; } = ProductCategories.Bread;
        public override double MarginCoefficient { get; } = 1.2;
    }
}
