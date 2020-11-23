using ClassLibrary.Categorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class LoadFromFileTests
    {
        /// <summary>
        /// Получить строку с информацией о производстве
        /// </summary>
        /// <returns>Возвращает строку с различными категориями хлебобулочных изделий</returns>
        string GetManufacturingString()
        {
            return "{" + //Хлеб
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
        }

        //**************************************************************************************************************
        // PARSE STRING TESTS
        //**************************************************************************************************************
        /// <summary>
        /// Получить данные о производстве из строки.
        /// </summary>
        [TestMethod]
        public void GetData_Test()
        {
            // arrange
            Products[] products;
            //Длина массива
            int expected_length = 5;
            //Наименования
            string expected_product_0_ProductName = "Волотовской";
            string expected_product_1_ProductName = "Русский";
            string expected_product_2_ProductName = "Вкусная";
            string expected_product_3_ProductName = "Грузинский";
            string expected_product_4_ProductName = "Нарезной";

            // act
            products = ParseString.GetData(GetManufacturingString());

            // assert
            //Длина массива
            Assert.AreEqual(expected_length, products.Length);
            //Проверка наименования
            Assert.AreEqual(expected_product_0_ProductName, products[0].ProductName);
            Assert.AreEqual(expected_product_1_ProductName, products[1].ProductName);
            Assert.AreEqual(expected_product_2_ProductName, products[2].ProductName);
            Assert.AreEqual(expected_product_3_ProductName, products[3].ProductName);
            Assert.AreEqual(expected_product_4_ProductName, products[4].ProductName);



        }

        //**************************************************************************************************************
        // PRODUCTS Calories and Prices TESTS
        //**************************************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetPrice_Test()
        {
            // arrange
            Products[] products;
            //Цена
            double expected_product_0_price = 0.7659; //убираем дробную часть
            double expected_product_1_price = 0.9306;
            double expected_product_2_price = 0.3154;
            double expected_product_3_price = 0.6376;
            double expected_product_4_price = 1.0631;

            double delta = .001;

            // act
            products = ParseString.GetData(GetManufacturingString());
            // assert
            //Проверка цены
            Assert.AreEqual(expected_product_0_price, products[0].Price, delta);
            Assert.AreEqual(expected_product_1_price, products[1].Price, delta);
            Assert.AreEqual(expected_product_2_price, products[2].Price, delta);
            Assert.AreEqual(expected_product_3_price, products[3].Price, delta);
            Assert.AreEqual(expected_product_4_price, products[4].Price, delta);
        }

        [TestMethod]
        public void GetCalories_Test()
        {
            // arrange
            Products[] products;
            //Калорийность
            double expected_product_0_calories = 1556.6; 
            double expected_product_1_calories = 859.13; 
            double expected_product_2_calories = 646.59; 
            double expected_product_3_calories = 1092;  
            double expected_product_4_calories = 1772.6;

            double delta = 0.01;

            // act
            products = ParseString.GetData(GetManufacturingString());
            
            // assert
            //Проверка калорийности
            Assert.AreEqual(expected_product_0_calories, products[0].Calories, delta);
            Assert.AreEqual(expected_product_1_calories, products[1].Calories, delta);
            Assert.AreEqual(expected_product_2_calories, products[2].Calories, delta);
            Assert.AreEqual(expected_product_3_calories, products[3].Calories, delta);
            Assert.AreEqual(expected_product_4_calories, products[4].Calories, delta);
        }

        //**************************************************************************************************************
        // PRODUCTS CATEGORYS TESTS
        //**************************************************************************************************************
        [TestMethod]
        public void CategorysMarginCoefficient_Test()
        {
            // arrange
            double bun_margin_coefficient_expected = 1.1;
            double bread_margin_coefficient_expected = 1.2;
            double loaf_margin_coefficient_expected = 1.3;
            double bagel_margin_coefficient_expected = 1.4;
            double pita_margin_coefficient_expected = 1.5;

            double delta = 0.1;

            // act
            Products bread = new Bread();
            Products bagel = new Bagel();
            Products bun = new Bun();
            Products pita = new Pita();
            Products loaf = new Loaf();

            // assert
            Assert.AreEqual(bun_margin_coefficient_expected, bun.MarginCoefficient, delta);
            Assert.AreEqual(bread_margin_coefficient_expected, bread.MarginCoefficient, delta);
            Assert.AreEqual(loaf_margin_coefficient_expected, loaf.MarginCoefficient, delta);
            Assert.AreEqual(bagel_margin_coefficient_expected, bagel.MarginCoefficient, delta);
            Assert.AreEqual(pita_margin_coefficient_expected, pita.MarginCoefficient, delta);
        }

        //**************************************************************************************************************
        // PRODUCTS SORT TESTS
        //**************************************************************************************************************
        /*
         По умолчанию до операций сортировки, после получения данных из строки, массив имеет следующий вид (.ToString())
         [0]    
            {  
                Волотовской 10,00шт 1556,60Дж 0,77р,
                Состав: Мука 0,30кг 364,00Дж 1,39р,
                Соль 0,01кг 0,00Дж 0,65р,
                Сахар 0,01кг 387,00Дж 1,59р,
                Дрожжи 0,00кг 325,00Дж 7,50р,
                Масло 0,05кг 884,00Дж 3,89р,
                Вода 0,30кг 0,00Дж 0,02р,
             }
        [1]
            {    Русский 10,00шт 859,13Дж 0,93р,
                Состав: Мука 0,01кг 364,00Дж 1,39р,
                Сахар 0,01кг 387,00Дж 1,59р,
                Соль 0,01кг 0,00Дж 0,65р,
                Масло 0,05кг 884,00Дж 3,89р,
                Маргарин 0,05кг 717,00Дж 8,22р,
                Ванилин 0,00кг 288,00Дж 30,90р,
            }
        [2]
            {   
                Вкусная 10,00шт 646,60Дж 0,32р,
                Состав: Мука 0,05кг 364,00Дж 1,39р,
                Сахар 0,01кг 387,00Дж 1,59р,
                Дрожжи 0,00кг 325,00Дж 7,50р,
                Вода 0,05кг 0,00Дж 0,02р,
                Масло 0,05кг 884,00Дж 3,89р,
                Соль 0,01кг 0,00Дж 0,65р,
            }
        [3]
            {
                Грузинский 10,00шт 1092,00Дж 0,64р,
                Состав: Мука 0,30кг 364,00Дж 1,39р,
                Вода 0,10кг 0,00Дж 0,02р,
                Соль 0,01кг 0,00Дж 0,65р,
            }
        [4]
            {
                Нарезной 10,00шт 1772,60Дж 1,06р,
                Состав: Мука 0,30кг 364,00Дж 1,39р,
                Масло 0,05кг 884,00Дж 3,89р,
                Вода 0,30кг 0,00Дж 0,02р,
                Соль 0,01кг 0,00Дж 0,65р,
                Сахар 0,05кг 387,00Дж 1,59р,
                Дрожжи 0,00кг 325,00Дж 7,50р,
                Яйца 0,03кг 155,00Дж 4,00р,
            }

         */

        /// <summary>
        /// Cклонировать массив и упорядочить изделия по калорийности
        /// </summary>
        [TestMethod]
        public void SortFoodsByCalorieContent_Test()
        {
            // arrange
            Products[] products;
            Products[] сalorie_foods;

            double product_0_expected_сalorie = 646.599;
            double product_1_expected_сalorie = 859.13;
            double product_2_expected_сalorie = 1092;
            double product_3_expected_сalorie = 1556.6;
            double product_4_expected_сalorie = 1772.6;

            double delta = 0.001;

            // act
            products = ParseString.GetData(GetManufacturingString());
            сalorie_foods = new Products[products.Length];
            ProductsSort.SortFoodsByCalorieContent(products, ref сalorie_foods);
            // assert
            Assert.AreEqual(product_0_expected_сalorie, сalorie_foods[0].Calories, delta);
            Assert.AreEqual(product_1_expected_сalorie, сalorie_foods[1].Calories, delta);
            Assert.AreEqual(product_2_expected_сalorie, сalorie_foods[2].Calories, delta);
            Assert.AreEqual(product_3_expected_сalorie, сalorie_foods[3].Calories, delta);
            Assert.AreEqual(product_4_expected_сalorie, сalorie_foods[4].Calories, delta);
        }

        /// <summary>
        /// Cкопировать массив и упорядочить изделия по стоимости
        /// </summary>
        [TestMethod]
        public void SortFoodsByPrice_Test()
        {
            // arrange
            Products[] products;
            Products[] price_foods;

            double product_0_expected_price = 0.315425;
            double product_1_expected_price = 0.6376;
            double product_2_expected_price = 0.7659;
            double product_3_expected_price = 0.93065;
            double product_4_expected_price = 1.06313;

            double delta = 0.001;

            // act
            products = ParseString.GetData(GetManufacturingString());
            price_foods = new Products[products.Length];
            ProductsSort.SortFoodsByPrice(products, ref price_foods);

            // assert
            Assert.AreEqual(product_0_expected_price, price_foods[0].Price, delta);
            Assert.AreEqual(product_1_expected_price, price_foods[1].Price, delta);
            Assert.AreEqual(product_2_expected_price, price_foods[2].Price, delta);
            Assert.AreEqual(product_3_expected_price, price_foods[3].Price, delta);
            Assert.AreEqual(product_4_expected_price, price_foods[4].Price, delta);
        }

        /// <summary>
        /// Найти в массиве все изделия, равные данному, если в качестве критерия использовать равенство по цене и калорийности
        /// </summary>
        [TestMethod]
        public void FindFoodsByPriceAndByCalorieContent_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_by_price_and_by_calorie;

            double expected_сalorie = 1092;
            double expected_price = 0.6376;
            string expected_product_name = "Грузинский";
            double delta = 0.001;
            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_by_price_and_by_calorie = new Products[products.Length];
            ProductsSort.FindFoodsByPriceAndByCalorieContent(expected_сalorie, expected_price, products, ref find_foods_by_price_and_by_calorie);

            // assert
            Assert.AreEqual(expected_сalorie, find_foods_by_price_and_by_calorie[0].Calories, delta);
            Assert.AreEqual(expected_price, find_foods_by_price_and_by_calorie[0].Price, delta);
            // Должен определиться Грузинский
            Assert.AreEqual(expected_product_name, find_foods_by_price_and_by_calorie[0].ProductName);

        }

        /// <summary>
        /// Найти в массиве все изделия, у которых объём использования заданного ингредиента больше указанной величины
        /// </summary>
        [TestMethod]
        public void FindFoodsBigestThenValueIngredient_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_bigest_then_value;
            string ingredient = "Сахар";
            double ingredient_val = 0.005;
            string expected_product_name = "Нарезной";
            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_bigest_then_value = new Products[products.Length];
            ProductsSort.FindFoodsBigestThenValueIngredient(ingredient, ingredient_val, products, ref find_foods_bigest_then_value);

            // assert
            // Должен определиться Нарезной
            Assert.AreEqual(expected_product_name, find_foods_bigest_then_value[0].ProductName);
        }

        /// <summary>
        /// Найти в массиве все изделия, у которых число ингредиентов больше заданной величины
        /// </summary>
        [TestMethod]
        public void FindFoodsNumberIngredientsGreaterThanTheValue_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_number_ingredients_greater_than_the_value;
            int count = 0;
            int expected_quantity = 4;

            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_number_ingredients_greater_than_the_value = new Products[products.Length];
            ProductsSort.FindFoodsNumberIngredientsGreaterThanTheValue(3, products, find_foods_number_ingredients_greater_than_the_value);
            foreach (var item in find_foods_number_ingredients_greater_than_the_value)
            {
                if (item != null)
                {
                    count++;
                }
            }

            // assert
            Assert.AreEqual(expected_quantity, count);
        }
    }
}
