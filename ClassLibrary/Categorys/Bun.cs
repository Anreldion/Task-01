namespace ClassLibrary.Categorys
{
    /// <summary>
    /// Булочка
    /// </summary>
    public class Bun : Products
    {
        public Bun()
        {
            MarginCoefficient = 1.1; //Наценка

            CategoryName = "";
            Calories = 0;
            Price = 0;
            ProductName = "";
            Quantity = 0;
        }
    }
}
