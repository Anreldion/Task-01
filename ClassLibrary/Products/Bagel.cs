using ClassLibrary.enums;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Bagel
    /// </summary>
    public class Bagel : BakeryProduct
    {
        public Bagel()
        {
        }

        public Bagel(string name, double marginCoefficient)
        {
            Name = name;
            MarginCoefficient = marginCoefficient;
        }


        public override string Name { get; set; } = "Bagel";
        public override ProductCategories ProductCategory { get; } = ProductCategories.Bagel;
        public override double MarginCoefficient { get; } = 1.4;

    }
}
