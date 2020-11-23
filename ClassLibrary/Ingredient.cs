namespace ClassLibrary
{
    public class Ingredient
    {
        public Ingredient()
        {
            Name = "";
            Value = 0;
            Calorie = 0;
            Price = 0;
        }

        public string Name { get; set; } //Наименование
        public double Value { get; set; } //Значение
        public double Calorie { get; set; } //Калорийность
        public double Price { get; set; } //Цена
    }
}
