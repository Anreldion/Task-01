using ClassLibrary.Products;

namespace ClassLibrary.Services.Interfaces
{
    public interface IProductFinding
    {
        BakedProduct[] FindByPriceAndCalories(BakedProduct[] products, double price, double calories);

        BakedProduct[] FindByIngredientWeightThreshold(BakedProduct[] products, string ingredientName,
            double minWeight);

        BakedProduct[] FindByIngredientCountThreshold(BakedProduct[] products, int minIngredientCount);
    }
}
