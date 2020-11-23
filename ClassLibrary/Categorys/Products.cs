using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public abstract class Products
    {
        /// <summary>
        /// Калорийность
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Наценка
        /// </summary>
        public double MarginCoefficient { get; set; }

        /// <summary>
        /// Наименование категории
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Наименование продукции
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Состав
        /// </summary>
        public List<Ingredient> CompositionList = new List<Ingredient>();

        /// <summary>
        /// Преобразовать данные в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string text = ProductName + " " + Quantity.ToString("f2") + "шт " + Calories.ToString("f2") + "Дж " + Price.ToString("f2") + "р,\r\n";
            text += "Состав: ";
            foreach (var item in CompositionList)
            {
                text += item.Name + " " + item.Value.ToString("f2") + "кг " + item.Calorie.ToString("f2") + "Дж " + item.Price.ToString("f2") + "р,\r\n";
            }
            return text;
        }
        /// <summary>
        /// Получить числовое значение продукта
        /// </summary>
        /// <returns>Возвращает HashCode продукта</returns>
        public override int GetHashCode()
        {
            return CompositionList.GetHashCode() + Calories.GetHashCode() + Price.GetHashCode() + MarginCoefficient.GetHashCode() + CategoryName.GetHashCode() + ProductName.GetHashCode();
        }
        /// <summary>
        /// Сравнить два объекта на равенство 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Products products = (Products)obj;
            return (this.CategoryName == products.CategoryName);
        }

        /// <summary>
        /// Рассчет калорий
        /// </summary>
        public void CaloriesCalculate()
        {
            Calories = 0;
            foreach (var item in CompositionList)
            {
                Calories += (item.Calorie * item.Value) / 0.1; //Из расчета на 100г продукта
            }
        }

        /// <summary>
        /// Рассчет цены
        /// </summary>
        public void PriceCalculate()
        {
            Price = 0;
            foreach (var item in CompositionList)
            {
                Price += item.Price * item.Value; //Цена за килограмм
            }
            Price *= MarginCoefficient; //Цена с наценкой
        }

        /// <summary>
        /// Добавить ингредиент
        /// </summary>
        /// <param name="ingredient"></param>
        public void AddIngredient(Ingredient ingredient)
        {
            CompositionList.Add(ingredient);
        }



        //********************************************************************************************************************
        // Доступные категории
        //********************************************************************************************************************
        public const string CATEGORY_BREAD = "Bread"; //Хлеб
        public const string CATEGORY_BAGEL = "Bagel"; //Бублик
        public const string CATEGORY_BUN = "Bun"; //Булочка
        public const string CATEGORY_PITA = "Pita"; //Лаваш
        public const string CATEGORY_LOAF = "Loaf"; //Батон

        /// <summary>
        /// Существует ли указанная категория продукта
        /// </summary>
        /// <param name="category">Наименование категории</param>
        /// <returns>Возвращает true/false</returns>
        static public bool CategoryIsExcist(string category)
        {
            switch (category)
            {
                case CATEGORY_BREAD:
                case CATEGORY_BAGEL:
                case CATEGORY_BUN:
                case CATEGORY_PITA:
                case CATEGORY_LOAF:
                    return true;

                default:
                    return false;
            }
        }
    }
}
