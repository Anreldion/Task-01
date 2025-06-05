using ClassLibrary.Products;

namespace ClassLibrary.Services.Interfaces
{
    public interface IProductFinding
    {
        BakedProduct[] FindProductsByPriceAndByCalorieContent(BakedProduct[] inputArray, double calories, double prices);

        BakedProduct[] FindFoodsBigestThenValueIngredient(BakedProduct[] inputArray, string name, double value);

        BakedProduct[] FindFoodsNumberIngredientsGreaterThanTheValue(BakedProduct[] inputArray, int value);
    }
}
