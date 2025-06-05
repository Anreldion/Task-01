using ClassLibrary.Products;

namespace ClassLibrary.Services.Interfaces
{
    public interface IProductFinding
    {
        BakedProduct[] FindByPriceAndCalories(BakedProduct[] inputArray, BakedProduct product);

        BakedProduct[] FindByIngredientWeightThreshold(BakedProduct[] inputArray, string ingredientName,
            double weight);

        BakedProduct[] FindByIngredientCountThreshold(BakedProduct[] inputArray, int value);
    }
}
