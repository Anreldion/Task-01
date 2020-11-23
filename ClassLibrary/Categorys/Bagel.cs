using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Categorys
{
    /// <summary>
    /// Бублик
    /// </summary>
    public class Bagel : Products
    {
        public Bagel()
        {
            MarginCoefficient = 1.4; //Наценка

            CategoryName = "";
            Calories = 0;
            Price = 0;
            ProductName = "";
            Quantity = 0;
        }
    }
}
