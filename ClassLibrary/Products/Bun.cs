using ClassLibrary.enums;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Булочка
    /// </summary>
    public class Bun : BakeryProduct
    {
        public Bun()
        {
        }
        public Bun(string name, double marginCoefficient)
        {
            Name = name;
            MarginCoefficient = marginCoefficient;
        }
        public override string Name { get; set; } = "Bun";
        public override ProductCategories ProductCategory { get; } = ProductCategories.Bun;
        public override double MarginCoefficient { get; } = 1.1;
    }
}
