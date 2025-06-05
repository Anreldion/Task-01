using ClassLibrary.Products;
using ClassLibrary.Services.Interfaces;

namespace ClassLibrary.Services
{
    public class ProductFinding : IProductFinding
    {
        /// <summary>
        /// Найти в массиве все изделия, равные данному, если в качестве критерия использовать равенство по цене и калорийности
        /// </summary>
        /// <param name="calories">Значение калорийности</param>
        /// <param name="prices">Значение цены</param>
        /// <param name="inputArray">Источник данных</param>
        public BakedProduct[] FindProductsByPriceAndByCalorieContent(BakedProduct[] inputArray, double calories, double prices)
        {
            var index = 0;
            var calorie = (int)(calories * 100.0);//убираем дробную часть
            var price = (int)(prices * 100.0);//убираем дробную часть;
            var outputArray = new BakedProduct[inputArray.Length];

            foreach (var item in inputArray)
            {
                if (calorie == (int)(item.GetCalories() * 100.0) && price == (int)(item.GetPrice() * 100.0))
                {
                    outputArray[index++] = item;
                }
            }

            return outputArray;
        }
        /// <summary>
        /// Найти в массиве все изделия, у которых объём использования заданного ингредиента больше указанной величины
        /// </summary>
        /// <param name="name">Наименование ингридиента</param>
        /// <param name="value">Количество ингредиента</param>
        /// <param name="inputArray">Источник данных</param>
        public BakedProduct[] FindFoodsBigestThenValueIngredient(BakedProduct[] inputArray, string name, double value)
        {
            var index = 0;
            var outputArray = new BakedProduct[inputArray.Length];
            foreach (var item in inputArray)
            {
                foreach (var ingredient in item.Ingredients)
                {
                    if (ingredient.Name == name)
                    {
                        if (ingredient.Weight > value)
                        {
                            outputArray[index++] = item;
                            break;
                        }
                    }
                }
            }

            return outputArray;
        }
        /// <summary>
        /// Найти в массиве все изделия, у которых число ингредиентов больше заданной величины
        /// </summary>
        /// <param name="value">Число ингредиентов</param>
        /// <param name="sourceArray">Источник данных</param>
        public BakedProduct[] FindFoodsNumberIngredientsGreaterThanTheValue(BakedProduct[] inputArray, int value)
        {
            var index = 0;
            var outputArray = new BakedProduct[inputArray.Length];
            foreach (var item in inputArray)
            {
                if (item.Ingredients.Count > value)
                {
                    outputArray[index++] = item;
                }
            }

            return outputArray;
        }
    }
}
