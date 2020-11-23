using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Выполнение операций сортировки
    /// </summary>
    public class ProductsSort
    {
        /// <summary>
        /// Cклонировать массив и упорядочить изделия по калорийности
        /// </summary>
        /// <param name="sourceArray">Исходный массив</param>
        /// <param name="destinationArray">Ссылка на массив, для отсортированных данных</param>
        static public void SortFoodsByCalorieContent(Products[] sourceArray, ref Products[] destinationArray)
        {
            //Клонируем массив
            destinationArray = (Products[])sourceArray.Clone();
            //Сортируем по калорийности
            Array.Sort(destinationArray, new SortByCalories());
        }

        /// <summary>
        /// Необходимо скопировать массив и упорядочить изделия по стоимости
        /// </summary>
        /// <param name="sourceArray">Источник данных</param>
        /// <param name="destinationArray">Приемник данных</param>
        static public void SortFoodsByPrice(Products[] sourceArray, ref Products[] destinationArray)
        {
            //Копируем массив
            Array.Copy(sourceArray, destinationArray, sourceArray.Length);
            //Сортируем по стоимости
            Array.Sort(destinationArray, new SortByPrice());
        }

        /// <summary>
        /// Найти в массиве все изделия, равные данному, если в качестве критерия использовать равенство по цене и калорийности
        /// </summary>
        /// <param name="calories">Значение калорийности</param>
        /// <param name="prices">Значение цены</param>
        /// <param name="sourceArray">Источник данных</param>
        /// <param name="destinationArray">Приемник данных</param>
        static public void FindFoodsByPriceAndByCalorieContent(double calories, double prices, Products[] sourceArray, ref Products[] destinationArray)
        {
            int index = 0;
            int calorie = (int)(calories * 100.0);//убираем дробную часть
            int price = (int)(prices * 100.0);//убираем дробную часть;

            foreach (var item in sourceArray)
            {
                if (calorie == (int)(item.Calories * 100.0) && price == (int)(item.Price * 100.0))
                {
                    destinationArray[index++] = item;
                }
            }
        }
        /// <summary>
        /// Найти в массиве все изделия, у которых объём использования заданного ингредиента больше указанной величины
        /// </summary>
        /// <param name="name">Наименование ингридиента</param>
        /// <param name="value">Количество ингредиента</param>
        /// <param name="sourceArray">Источник данных</param>
        /// <param name="destinationArray">Приемник данных</param>
        static public void FindFoodsBigestThenValueIngredient(string name, double value, Products[] sourceArray, ref Products[] destinationArray)
        {
            int index = 0;
            foreach (var item in sourceArray)
            {
                foreach (var ingredient in item.CompositionList)
                {
                    if (ingredient.Name == name)
                    {
                        if (ingredient.Value > value)
                        {
                            destinationArray[index++] = item;
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Найти в массиве все изделия, у которых число ингредиентов больше заданной величины
        /// </summary>
        /// <param name="value">Число ингредиентов</param>
        /// <param name="sourceArray">Источник данных</param>
        /// <param name="destinationArray">Приемник данных</param>
        static public void FindFoodsNumberIngredientsGreaterThanTheValue(double value, Products[] sourceArray, Products[] destinationArray)
        {
            int index = 0;
            foreach (var item in sourceArray)
            {
                if (item.CompositionList.Count > value)
                {
                    destinationArray[index++] = item;
                }
            }
        }
    }
    /// <summary>
    /// Интерфейс сортировки по калорийности
    /// </summary>
    public class SortByCalories : IComparer<Products>
    {
        public int Compare(Products o1, Products o2)
        {
            return o1.Calories.CompareTo(o2.Calories);
        }
    }
    /// <summary>
    /// Интерфейс сортировки по цене
    /// </summary>
    public class SortByPrice : IComparer<Products>
    {
        public int Compare(Products o1, Products o2)
        {
            return o1.Price.CompareTo(o2.Price);
        }
    }
}


