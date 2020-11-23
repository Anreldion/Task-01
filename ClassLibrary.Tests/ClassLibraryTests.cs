using ClassLibrary.Categorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class LoadFromFileTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange

            // act

            // assert
        }
        /// <summary>
        /// �������� ������ � ����������� � ������������
        /// </summary>
        /// <returns>���������� ������ � ���������� ����������� ������������� �������</returns>
        string GetManufacturingString()
        {
            return "{" + //����
                "category : CategoryName = Bread, ProductName = �����������, Quantity = 10;" +
                "ingredient : Name = ����, Value = 0.3, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = ����, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "ingredient : Name = �����, Value = 0.005, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = ������, Value = 0.001, Calorie = 325, Price = 7.5;" +
                "ingredient : Name = �����, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = ����, Value = 0.3, Calorie = 0, Price = 0.016;" +
                "}" +

                "{" + //������
                "category : CategoryName = Bagel, ProductName = �������, Quantity = 10;" +
                "ingredient : Name = ����, Value = 0.01, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = �����, Value = 0.005, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = ����, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "ingredient : Name = �����, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = ��������, Value = 0.05, Calorie = 717, Price = 8.22;" +
                "ingredient : Name = �������, Value = 0.001, Calorie = 288, Price = 30.9;" +
                "}" +

                "{" + //�������
                "category : CategoryName = Bun, ProductName = �������, Quantity = 10;" +
                "ingredient : Name = ����, Value = 0.05, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = �����, Value = 0.005, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = ������, Value = 0.001, Calorie = 325, Price = 7.5;" +
                "ingredient : Name = ����, Value = 0.05, Calorie = 0, Price = 0.016;" +
                "ingredient : Name = �����, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = ����, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "}" +

                "{" + //�����
                "category : CategoryName = Pita, ProductName = ����������, Quantity = 10;" +
                "ingredient : Name = ����, Value = 0.3, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = ����, Value = 0.1, Calorie = 0, Price = 0.016;" +
                "ingredient : Name = ����, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "}" +


                "{" + //�����
                "category : CategoryName = Loaf, ProductName = ��������, Quantity = 10;" +
                "ingredient : Name = ����, Value = 0.3, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = �����, Value = 0.05, Calorie = 884, Price = 3.89;" +
                "ingredient : Name = ����, Value = 0.3, Calorie = 0, Price = 0.016;" +
                "ingredient : Name = ����, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "ingredient : Name = �����, Value = 0.05, Calorie = 387, Price = 1.59;" +
                "ingredient : Name = ������, Value = 0.001, Calorie = 325, Price = 7.5;" +
                "ingredient : Name = ����, Value = 0.027, Calorie = 155, Price = 4;" +
                "}";
        }

        //**************************************************************************************************************
        // PARSE STRING TESTS
        //**************************************************************************************************************
        [TestMethod]
        public void GetData_Test()
        {
            // arrange
            Products[] products;
            //����� �������
            int expected_length = 5;
            //������������
            string expected_product_0_ProductName = "�����������";
            string expected_product_1_ProductName = "�������";
            string expected_product_2_ProductName = "�������";
            string expected_product_3_ProductName = "����������";
            string expected_product_4_ProductName = "��������";

            // act
            products = ParseString.GetData(GetManufacturingString());

            // assert
            //����� �������
            Assert.AreEqual(expected_length, products.Length);
            //�������� ������������
            Assert.AreEqual(expected_product_0_ProductName, products[0].ProductName);
            Assert.AreEqual(expected_product_1_ProductName, products[1].ProductName);
            Assert.AreEqual(expected_product_2_ProductName, products[2].ProductName);
            Assert.AreEqual(expected_product_3_ProductName, products[3].ProductName);
            Assert.AreEqual(expected_product_4_ProductName, products[4].ProductName);



        }

        //**************************************************************************************************************
        // PRODUCTS Calories and Prices TESTS
        //**************************************************************************************************************

        [TestMethod]
        public void GetPrice_Test()
        {
            // arrange
            Products[] products;
            //����
            int expected_product_0_price = (int)(0.7659 * 100.0); //������� ������� �����
            int expected_product_1_price = (int)(0.9306 * 100.0);
            int expected_product_2_price = (int)(0.3154 * 100.0);
            int expected_product_3_price = (int)(0.6376 * 100.0);
            int expected_product_4_price = (int)(1.0631 * 100.0);

            // act
            products = ParseString.GetData(GetManufacturingString());
            //����
            int product_0_price = (int)(products[0].Price * 100.0); //������� ������� �����
            int product_1_price = (int)(products[1].Price * 100.0);
            int product_2_price = (int)(products[2].Price * 100.0);
            int product_3_price = (int)(products[3].Price * 100.0);
            int product_4_price = (int)(products[4].Price * 100.0);

            // assert
            //�������� ����
            Assert.AreEqual(expected_product_0_price, product_0_price);
            Assert.AreEqual(expected_product_1_price, product_1_price);
            Assert.AreEqual(expected_product_2_price, product_2_price);
            Assert.AreEqual(expected_product_3_price, product_3_price);
            Assert.AreEqual(expected_product_4_price, product_4_price);
        }

        [TestMethod]
        public void GetCalories_Test()
        {
            // arrange
            Products[] products;
            //������������
            int expected_product_0_calories = (int)(1556.6 * 100.0); //������� ������� �����
            int expected_product_1_calories = (int)(859.13 * 100.0);
            int expected_product_2_calories = (int)(646.59 * 100.0);
            int expected_product_3_calories = (int)(1092 * 100.0);
            int expected_product_4_calories = (int)(1772.6 * 100.0);

            // act
            products = ParseString.GetData(GetManufacturingString());
            //������������
            int product_0_calories = (int)(products[0].Calories * 100.0); //������� ������� �����
            int product_1_calories = (int)(products[1].Calories * 100.0);
            int product_2_calories = (int)(products[2].Calories * 100.0);
            int product_3_calories = (int)(products[3].Calories * 100.0);
            int product_4_calories = (int)(products[4].Calories * 100.0);

            // assert
            //�������� ������������
            Assert.AreEqual(expected_product_0_calories, product_0_calories);
            Assert.AreEqual(expected_product_1_calories, product_1_calories);
            Assert.AreEqual(expected_product_2_calories, product_2_calories);
            Assert.AreEqual(expected_product_3_calories, product_3_calories);
            Assert.AreEqual(expected_product_4_calories, product_4_calories);
        }

        //**************************************************************************************************************
        // PRODUCTS CATEGORYS TESTS
        //**************************************************************************************************************
        [TestMethod]
        public void CategorysMarginCoefficient_Test()
        {
            // arrange
            int bun_margin_coefficient_expected = (int)(1.1 * 100.0); //������� ������� �����
            int bread_margin_coefficient_expected = (int)(1.2 * 100.0);
            int loaf_margin_coefficient_expected = (int)(1.3 * 100.0);
            int bagel_margin_coefficient_expected = (int)(1.4 * 100.0);
            int pita_margin_coefficient_expected = (int)(1.5 * 100.0);
            // act
            Products bread = new Bread();
            Products bagel = new Bagel();
            Products bun = new Bun();
            Products pita = new Pita();
            Products loaf = new Loaf();
            int bun_margin_coefficient = (int)(bun.MarginCoefficient * 100.0); //������� ������� �����
            int bread_margin_coefficient = (int)(bread.MarginCoefficient * 100.0);
            int loaf_margin_coefficient = (int)(loaf.MarginCoefficient * 100.0);
            int bagel_margin_coefficient = (int)(bagel.MarginCoefficient * 100.0);
            int pita_margin_coefficient = (int)(pita.MarginCoefficient * 100.0);
            // assert
            Assert.AreEqual(bun_margin_coefficient_expected, bun_margin_coefficient);

            Assert.AreEqual(bread_margin_coefficient_expected, bread_margin_coefficient);

            Assert.AreEqual(loaf_margin_coefficient_expected, loaf_margin_coefficient);

            Assert.AreEqual(bagel_margin_coefficient_expected, bagel_margin_coefficient);

            Assert.AreEqual(pita_margin_coefficient_expected, pita_margin_coefficient);
        }

        //**************************************************************************************************************
        // PRODUCTS SORT TESTS
        //**************************************************************************************************************
        [TestMethod]
        public void SortFoodsByCalorieContent_Test()
        {
            // arrange
            Products[] products;
            Products[] �alorie_foods;

            // act
            products = ParseString.GetData(GetManufacturingString());
            �alorie_foods = new Products[products.Length];
            ProductsSort.SortFoodsByCalorieContent(products, ref �alorie_foods);
            // assert

        }
        [TestMethod]
        public void SortFoodsByPrice_Test()
        {
            // arrange
            Products[] products;
            Products[] price_foods;

            // act
            products = ParseString.GetData(GetManufacturingString());
            price_foods = new Products[products.Length];
            ProductsSort.SortFoodsByPrice(products, ref price_foods);

            // assert
        }
        [TestMethod]
        public void FindFoodsByPriceAndByCalorieContent_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_by_price_and_by_calorie;

            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_by_price_and_by_calorie = new Products[products.Length];
            ProductsSort.FindFoodsByPriceAndByCalorieContent(700, 0.7, products, ref find_foods_by_price_and_by_calorie);

            // assert
        }
        [TestMethod]
        public void FindFoodsBigestThenValueIngredient_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_bigest_then_value;

            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_bigest_then_value = new Products[products.Length];
            ProductsSort.FindFoodsBigestThenValueIngredient("�����", 45, products, ref find_foods_bigest_then_value);

            // assert
        }
        [TestMethod]
        public void FindFoodsNumberIngredientsGreaterThanTheValue_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_number_ingredients_greater_than_the_value;

            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_number_ingredients_greater_than_the_value = new Products[products.Length];
            ProductsSort.FindFoodsNumberIngredientsGreaterThanTheValue(1, products, find_foods_number_ingredients_greater_than_the_value);

            // assert
        }
    }
}
