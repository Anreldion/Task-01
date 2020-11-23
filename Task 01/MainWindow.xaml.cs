using ClassLibrary;
using System.Windows;

namespace Task_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Проверка работы
            string test =
                "{" + //Хлеб
                "category : CategoryName = Bread, ProductName = Волотовской, Quantity = 10;" +
                "ingredient : Name = Мука, Value = 0.3, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = Соль, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "ingredient : Name = Сахар, Value = 0.005, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = Дрожжи, Value = 0.001, Calorie = 325, Price = 7.5;" +
                "ingredient : Name = Масло, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = Вода, Value = 0.3, Calorie = 0, Price = 0.016;" +
                "}" +

                "{" + //Бублик
                "category : CategoryName = Bagel, ProductName = Русский, Quantity = 10;" +
                "ingredient : Name = Мука, Value = 0.01, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = Сахар, Value = 0.005, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = Соль, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "ingredient : Name = Масло, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = Маргарин, Value = 0.05, Calorie = 717, Price = 8.22;" +
                "ingredient : Name = Ванилин, Value = 0.001, Calorie = 288, Price = 30.9;" +
                "}" +

                "{" + //Булочка
                "category : CategoryName = Bun, ProductName = Вкусная, Quantity = 10;" +
                "ingredient : Name = Мука, Value = 0.05, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = Сахар, Value = 0.005, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = Дрожжи, Value = 0.001, Calorie = 325, Price = 7.5;" +
                "ingredient : Name = Вода, Value = 0.05, Calorie = 0, Price = 0.016;" +
                "ingredient : Name = Масло, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = Соль, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "}" +

                "{" + //Лаваш
                "category : CategoryName = Pita, ProductName = Грузинский, Quantity = 10;" +
                "ingredient : Name = Мука, Value = 0.3, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = Вода, Value = 0.1, Calorie = 0, Price = 0.016;" +
                "ingredient : Name = Соль, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "}" +


                "{" + //Батон
                "category : CategoryName = Loaf, ProductName = Нарезной, Quantity = 10;" +
                "ingredient : Name = Мука, Value = 0.3, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = Масло, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = Вода, Value = 0.3, Calorie = 0, Price = 0.016;" +
                "ingredient : Name = Соль, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "ingredient : Name = Сахар, Value = 0.05, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = Дрожжи, Value = 0.001, Calorie = 325, Price = 7.5;" +
                "ingredient : Name = Яйца, Value = 0.027, Calorie = 155, Price = 4;" +
                "}";



            Products[] products = ParseString.GetData(test);

            //10.Необходимо склонировать массив и упорядочить изделия по калорийности
            Products[] сalorie_foods = new Products[products.Length];
            ProductsSort.SortFoodsByCalorieContent(products, ref сalorie_foods);

            //11. Необходимо скопировать массив и упорядочить изделия по стоимости
            Products[] price_foods = new Products[products.Length];
            ProductsSort.SortFoodsByPrice(products, ref price_foods);

            //12. Найти в массиве все изделия, равные данному, если в качестве критерия использовать равенство по цене и калорийности
            Products[] find_foods_by_price_and_by_calorie = new Products[products.Length];
            ProductsSort.FindFoodsByPriceAndByCalorieContent(1092, 0.6376, products, ref find_foods_by_price_and_by_calorie);

            //13. Найти в массиве все изделия, у которых объём использования заданного ингредиента больше указанной величины
            Products[] find_foods_bigest_then_value = new Products[products.Length];
            ProductsSort.FindFoodsBigestThenValueIngredient("Сахар", 0.005, products, ref find_foods_bigest_then_value);

            //14. Найти в массиве все изделия, у которых число ингредиентов больше заданной величины
            Products[] find_foods_number_ingredients_greater_than_the_value = new Products[products.Length];
            ProductsSort.FindFoodsNumberIngredientsGreaterThanTheValue(3, products, find_foods_number_ingredients_greater_than_the_value);


        }
    }
}
