namespace ClassLibrary.Categorys
{
    /// <summary>
    /// Хлеб
    /// </summary>
    public class Bread : Products
    {
        public Bread()
        {
            MarginCoefficient = 1.2; //Наценка

            CategoryName = "";
            Calories = 0;
            Price = 0;
            ProductName = "";
            Quantity = 0;
        }
    }
}
