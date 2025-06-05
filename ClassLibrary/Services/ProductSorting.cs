using System;
using System.Collections.Generic;
using ClassLibrary.Products;
using ClassLibrary.Services.Interfaces;

namespace ClassLibrary.Services
{
    /// <summary>
    /// Выполнение операций сортировки
    /// </summary>
    public class ProductSorting : IProductSorting
    {
        /// <summary>
        /// Клонировать массив и упорядочить изделия по калорийности
        /// </summary>
        /// <param name="input">Исходный массив</param>
        public BakedProduct[] CloneAndSortByCalorie(BakedProduct[] input)
        {
            var output = (BakedProduct[])input.Clone();
            Array.Sort(output, new SortByCalories());
            return output;
        }

        /// <summary>
        /// Необходимо копировать массив и упорядочить изделия по стоимости
        /// </summary>
        /// <param name="input">Источник данных</param>
        /// <param name="destinationArray">Приемник данных</param>
        public BakedProduct[] CopyAndSortByPrice(BakedProduct[] input)
        {
            var output = new BakedProduct[input.Length];
            Array.Copy(input, output, input.Length);
            Array.Sort(output, new SortByPrice());
            return output;
        }
    }
    /// <summary>
    /// Интерфейс сортировки по калорийности
    /// </summary>
    public class SortByCalories : IComparer<BakedProduct>
    {
        public int Compare(BakedProduct o1, BakedProduct o2)
        {
            return o1.Calories.CompareTo(o2.Calories);
        }
    }
    /// <summary>
    /// Интерфейс сортировки по цене
    /// </summary>
    public class SortByPrice : IComparer<BakedProduct>
    {
        public int Compare(BakedProduct o1, BakedProduct o2)
        {
            return o1.Price.CompareTo(o2.Price);
        }
    }
}


