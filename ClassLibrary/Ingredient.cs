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


        /// <summary>
        /// Преобразовать данные в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string text = Name + " " + Value.ToString("f2") + "кг " + Calorie.ToString("f2") + "Дж " + Price.ToString("f2") + "р,\r\n";
            return text;
        }
    }
}
