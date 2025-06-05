using ClassLibrary.enums;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Батон
    /// </summary>
    public class Loaf : BakeryProduct
    {
        public Loaf()
        {
        }

        public Loaf(string name, double marginCoefficient)
        {
            Name = name;
            MarginCoefficient = marginCoefficient;
        }

        public override string Name { get; set; } = "Loaf";
        public override ProductCategories ProductCategory { get; } = ProductCategories.Loaf;
        public override double MarginCoefficient { get; } = 1.3;
    }
}
