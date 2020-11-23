using ClassLibrary.Categorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class LoadFromFileTests
    {
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
        /// <summary>
        /// �������� ������ � ������������ �� ������.
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetPrice_Test()
        {
            // arrange
            Products[] products;
            //����
            double expected_product_0_price = 0.7659; //������� ������� �����
            double expected_product_1_price = 0.9306;
            double expected_product_2_price = 0.3154;
            double expected_product_3_price = 0.6376;
            double expected_product_4_price = 1.0631;

            double delta = .001;

            // act
            products = ParseString.GetData(GetManufacturingString());
            // assert
            //�������� ����
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
            //������������
            double expected_product_0_calories = 1556.6; 
            double expected_product_1_calories = 859.13; 
            double expected_product_2_calories = 646.59; 
            double expected_product_3_calories = 1092;  
            double expected_product_4_calories = 1772.6;

            double delta = 0.01;

            // act
            products = ParseString.GetData(GetManufacturingString());
            
            // assert
            //�������� ������������
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
         �� ��������� �� �������� ����������, ����� ��������� ������ �� ������, ������ ����� ��������� ��� (.ToString())
         [0]    
            {  
                ����������� 10,00�� 1556,60�� 0,77�,
                ������: ���� 0,30�� 364,00�� 1,39�,
                ���� 0,01�� 0,00�� 0,65�,
                ����� 0,01�� 387,00�� 1,59�,
                ������ 0,00�� 325,00�� 7,50�,
                ����� 0,05�� 884,00�� 3,89�,
                ���� 0,30�� 0,00�� 0,02�,
             }
        [1]
            {    ������� 10,00�� 859,13�� 0,93�,
                ������: ���� 0,01�� 364,00�� 1,39�,
                ����� 0,01�� 387,00�� 1,59�,
                ���� 0,01�� 0,00�� 0,65�,
                ����� 0,05�� 884,00�� 3,89�,
                �������� 0,05�� 717,00�� 8,22�,
                ������� 0,00�� 288,00�� 30,90�,
            }
        [2]
            {   
                ������� 10,00�� 646,60�� 0,32�,
                ������: ���� 0,05�� 364,00�� 1,39�,
                ����� 0,01�� 387,00�� 1,59�,
                ������ 0,00�� 325,00�� 7,50�,
                ���� 0,05�� 0,00�� 0,02�,
                ����� 0,05�� 884,00�� 3,89�,
                ���� 0,01�� 0,00�� 0,65�,
            }
        [3]
            {
                ���������� 10,00�� 1092,00�� 0,64�,
                ������: ���� 0,30�� 364,00�� 1,39�,
                ���� 0,10�� 0,00�� 0,02�,
                ���� 0,01�� 0,00�� 0,65�,
            }
        [4]
            {
                �������� 10,00�� 1772,60�� 1,06�,
                ������: ���� 0,30�� 364,00�� 1,39�,
                ����� 0,05�� 884,00�� 3,89�,
                ���� 0,30�� 0,00�� 0,02�,
                ���� 0,01�� 0,00�� 0,65�,
                ����� 0,05�� 387,00�� 1,59�,
                ������ 0,00�� 325,00�� 7,50�,
                ���� 0,03�� 155,00�� 4,00�,
            }

         */

        /// <summary>
        /// C����������� ������ � ����������� ������� �� ������������
        /// </summary>
        [TestMethod]
        public void SortFoodsByCalorieContent_Test()
        {
            // arrange
            Products[] products;
            Products[] �alorie_foods;

            double product_0_expected_�alorie = 646.599;
            double product_1_expected_�alorie = 859.13;
            double product_2_expected_�alorie = 1092;
            double product_3_expected_�alorie = 1556.6;
            double product_4_expected_�alorie = 1772.6;

            double delta = 0.001;

            // act
            products = ParseString.GetData(GetManufacturingString());
            �alorie_foods = new Products[products.Length];
            ProductsSort.SortFoodsByCalorieContent(products, ref �alorie_foods);
            // assert
            Assert.AreEqual(product_0_expected_�alorie, �alorie_foods[0].Calories, delta);
            Assert.AreEqual(product_1_expected_�alorie, �alorie_foods[1].Calories, delta);
            Assert.AreEqual(product_2_expected_�alorie, �alorie_foods[2].Calories, delta);
            Assert.AreEqual(product_3_expected_�alorie, �alorie_foods[3].Calories, delta);
            Assert.AreEqual(product_4_expected_�alorie, �alorie_foods[4].Calories, delta);
        }

        /// <summary>
        /// C���������� ������ � ����������� ������� �� ���������
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
        /// ����� � ������� ��� �������, ������ �������, ���� � �������� �������� ������������ ��������� �� ���� � ������������
        /// </summary>
        [TestMethod]
        public void FindFoodsByPriceAndByCalorieContent_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_by_price_and_by_calorie;

            double expected_�alorie = 1092;
            double expected_price = 0.6376;
            string expected_product_name = "����������";
            double delta = 0.001;
            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_by_price_and_by_calorie = new Products[products.Length];
            ProductsSort.FindFoodsByPriceAndByCalorieContent(expected_�alorie, expected_price, products, ref find_foods_by_price_and_by_calorie);

            // assert
            Assert.AreEqual(expected_�alorie, find_foods_by_price_and_by_calorie[0].Calories, delta);
            Assert.AreEqual(expected_price, find_foods_by_price_and_by_calorie[0].Price, delta);
            // ������ ������������ ����������
            Assert.AreEqual(expected_product_name, find_foods_by_price_and_by_calorie[0].ProductName);

        }

        /// <summary>
        /// ����� � ������� ��� �������, � ������� ����� ������������� ��������� ����������� ������ ��������� ��������
        /// </summary>
        [TestMethod]
        public void FindFoodsBigestThenValueIngredient_Test()
        {
            // arrange
            Products[] products;
            Products[] find_foods_bigest_then_value;
            string ingredient = "�����";
            double ingredient_val = 0.005;
            string expected_product_name = "��������";
            // act
            products = ParseString.GetData(GetManufacturingString());
            find_foods_bigest_then_value = new Products[products.Length];
            ProductsSort.FindFoodsBigestThenValueIngredient(ingredient, ingredient_val, products, ref find_foods_bigest_then_value);

            // assert
            // ������ ������������ ��������
            Assert.AreEqual(expected_product_name, find_foods_bigest_then_value[0].ProductName);
        }

        /// <summary>
        /// ����� � ������� ��� �������, � ������� ����� ������������ ������ �������� ��������
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
