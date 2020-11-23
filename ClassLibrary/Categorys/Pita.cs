using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Categorys
{
    /// <summary>
    /// Лаваш
    /// </summary>
    public class Pita : Products
    {
        public Pita()
        {
            MarginCoefficient = 1.5; //Наценка

            CategoryName = "";
            Calories = 0;
            Price = 0;
            ProductName = "";
            Quantity = 0;
        }
    }
}
