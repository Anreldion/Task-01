using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Выполнение операций сортировки
    /// </summary>
    public class ProductsSort
    {
        //Cклонировать массив и упорядочить изделия по калорийности
        static public void SortFoodsByCalorieContent(Products[] sourceArray, ref Products[] destinationArray)
        {
            //Клонируем массив
            destinationArray = (Products[])sourceArray.Clone();
            //Сортируем по калорийности
            Array.Sort(destinationArray, new SortByCalories());
        }

        //Необходимо скопировать массив и упорядочить изделия по стоимости
        static public void SortFoodsByPrice(Products[] sourceArray, ref Products[] destinationArray)
        {
            //Копируем массив
            Array.Copy(sourceArray, destinationArray, sourceArray.Length);
            //Сортируем по стоимости
            Array.Sort(destinationArray, new SortByPrice());
        }

        //Найти в массиве все изделия, равные данному, если в качестве критерия использовать равенство по цене и калорийности
        static public void FindFoodsByPriceAndByCalorieContent(double calories, double price, Products[] sourceArray, ref Products[] destinationArray)
        {
            int index = 0;
            foreach (var item in sourceArray)
            {
                if (calories == item.Calories && price == item.Price)
                {
                    destinationArray[index++] = item;
                }
            }
        }
        //Найти в массиве все изделия, у которых объём использования заданного ингредиента больше указанной величины
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
        // Найти в массиве все изделия, у которых число ингредиентов больше заданной величины
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
    public class SortByCalories : IComparer<Products>
    {
        public int Compare(Products o1, Products o2)
        {
            return o1.Calories.CompareTo(o2.Calories);
        }
    }

    public class SortByPrice : IComparer<Products>
    {
        public int Compare(Products o1, Products o2)
        {
            return o1.Price.CompareTo(o2.Price);
        }
    }
}


