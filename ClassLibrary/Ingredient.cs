namespace ClassLibrary
{
    /// <summary>
    /// Ингредиент. Определяет состав продукта
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Ingredient()
        {
            Name = "";
            Value = 0;
            Calorie = 0;
            Price = 0;
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Калорийность
        /// </summary>
        public double Calorie { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
    }
}
