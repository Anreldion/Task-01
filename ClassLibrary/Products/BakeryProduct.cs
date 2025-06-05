using ClassLibrary.enums;
using System.Collections.Generic;

namespace ClassLibrary.Products
{
    /// <summary>
    /// Хлебобулочные изделия
    /// </summary>
    public abstract class BakeryProduct
    {
        /// <summary>
        /// Калорийность
        /// </summary>
        public abstract string Name { get; set; }
        /// <summary>
        /// Наименование категории
        /// </summary>
        public abstract ProductCategories ProductCategory { get; }
        /// <summary>
        /// Калорийность
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Margin coefficient
        /// </summary>
        public abstract double MarginCoefficient { get; }


        /// <summary>
        /// List of Ingredients
        /// </summary>
        public List<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Преобразовать данные в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string text = ProductName + " " + Quantity.ToString("f2") + "шт " + Calories.ToString("f2") + "Дж " + Price.ToString("f2") + "р,\r\n";
            text += "Состав: ";
            foreach (var item in Ingredients)
            {
                text += item.Name + " " + item.Value.ToString("f2") + "кг " + item.Calorie.ToString("f2") + "Дж " + item.Price.ToString("f2") + "р,\r\n";
            }
            return text;
        }
        /// <summary>
        /// Получить числовое значение продукта
        /// </summary>
        /// <returns>Возвращает Hash Code продукта</returns>
        public override int GetHashCode()
        {
            return Ingredients.GetHashCode() + Calories.GetHashCode() + Price.GetHashCode() + MarginCoefficient.GetHashCode() + CategoryName.GetHashCode() + ProductName.GetHashCode();
        }
        
        /// <summary>
        /// Сравнить два объекта на равенство 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            BakeryProduct bakeryProduct = (BakeryProduct)obj;
            return (this.ProductCategory == bakeryProduct.ProductCategory);
        }

        /// <summary>
        /// Рассчет калорий
        /// </summary>
        public void CaloriesCalculate()
        {
            Calories = 0;
            foreach (var item in Ingredients)
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
            foreach (var item in Ingredients)
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
            Ingredients.Add(ingredient);
        }
    }
}
