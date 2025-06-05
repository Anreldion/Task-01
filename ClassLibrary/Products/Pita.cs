using ClassLibrary.enums;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Pita
    /// </summary>
    public class Pita : BakeryProduct
    {
        public Pita()
        {
        }
        public Pita(string name, double marginCoefficient)
        {
            Name = name;
            MarginCoefficient = marginCoefficient;
        }

        public override string Name { get; set; } = "Pita";
        public override ProductCategories ProductCategory { get; } = ProductCategories.Pita;
        public override double MarginCoefficient { get; } = 1.5;
    }
}
