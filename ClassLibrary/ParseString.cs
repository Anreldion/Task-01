using ClassLibrary.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    /// <summary>
    /// Синтаксический анализ строки
    /// </summary>
    public class ParseString
    {
        /*
         * Формат данных:
                "{" + 
                "category : CategoryName = Pita, ProductName = Грузинский, Quantity = 10;" +
                "ingredient : Name = Мука, Value = 0.3, Calorie = 364, Price = 1.39;" +
                "ingredient : Name = Вода, Value = 0.1, Calorie = 0, Price = 0.016;" +
                "ingredient : Name = Соль, Value = 0.01, Calorie = 0, Price = 0.65;" +
                "}" +
         * и т.д.
         */

        /// <summary>
        /// Получить данные о производстве из строки.
        /// </summary>
        /// <param name="data_in">Строка с информацией о производстве</param>
        /// <returns>Возвращает массив содержащий объекты Products</returns>
        static public Products[] GetData(String data_in)
        {
            Products[] products_array;
            int array_index = 0;

            List<string> blocks = new List<string> { }; //Промежуточный список для хранения блоков с параметрами для каждой категории.

            //0. Первичные преобразования строки
            String data = Regex.Replace(data_in, @"[ \r\n\t]", ""); //Избавляемся от пробелов, переносов


            //Патерн для разбиения строки на блоки.
            String pattern = @"\{([^\{\}]+)\}";     //где, \{	Совпадение с открывающей скобкой. 
                                                    // ([^\{\}]+)  Совпадение с любым символом, который не является открывающей или закрывающей круглой скобкой один или несколько раз. 
                                                    // \}   Совпадение с закрывающей скобкой
                                                    //1. Извлечение блоков из строки на основе шаблона
            foreach (Match match in Regex.Matches(data, pattern))
            {
                blocks.Add(match.Groups[1].Value);
            }
            //Количество элементов больше 0?
            if (blocks.Count == 0)
            {
                return _ = new Products[0];//Пусто. Выход
            }
            else
            {
                products_array = new Products[blocks.Count];
            }

            //2. Извлечение данных из блоков
            foreach (var item in blocks)
            {
                //2.1. Существует ли параметр категория в строке?
                if (item.IndexOf("category") == -1) //не существует
                {
                    //Удаляем элемент из списка.
                    blocks.Remove(item);
                    continue;
                }

                //2.2. Разбиение блока на массив строк.
                string[] string_array = item.Split(';', StringSplitOptions.RemoveEmptyEntries);
                bool category_is_excist = false;
                Products product = new Bread();
                Ingredient ingredient;

                //2.3. Определение категории (Без категории, блок игнорируется)
                foreach (var element in string_array)
                {
                    //Ищем параметр category
                    if (item.IndexOf("category") != -1)//Нашли
                    {
                        //Получаем введенную информацию
                        product = ParseCategory(element, ref category_is_excist);
                        break; //Выход из цикла foreach
                    }
                }


                if (category_is_excist == false)//Без категории, блок игнорируется
                {
                    //Удаляем элемент из списка.
                    blocks.Remove(item);
                    continue;
                }
                else
                {

                }
                //3. Получаем состав продукта.
                foreach (var string_array_item in string_array)
                {
                    //Ищем параметр ingredient
                    if (string_array_item.IndexOf("ingredient") != -1)//Нашли
                    {
                        ingredient = ParseIngredient(string_array_item);
                        //Добавляем к текущему продукту.
                        product.AddIngredient(ingredient);
                    }
                }

                product.PriceCalculate();//Рассчет цены
                product.CaloriesCalculate();//Рассчет калорий

                products_array[array_index++] = product;
            }

            return products_array;
        }



        /// <summary>
        /// Разобрать строку содержащую информацию о категории
        /// </summary>
        /// <param name="input_string">Строка с информацией о категории</param>
        /// <param name="is_ok">Ссылка на переменную, указывающую на успешный разбор строки</param>
        /// <returns>Возвращает Products</returns>
        static Products ParseCategory(string input_string, ref bool is_ok)
        {
            //Формат 
            //"category : CategoryName = Bread, ProductName = Волотовской, Quantity = 10;"

            Products product = new Bread();
            int positions = input_string.LastIndexOf(':');//Определяем позицию после двоеточия
            string edit_string = input_string.Substring(positions + 1);

            //Разбиваем строку на массив строк
            string[] string_array = edit_string.Split(',', StringSplitOptions.RemoveEmptyEntries);

            //Определяем категорию к которой относится продукция
            foreach (var item in string_array)
            {
                //ищем
                if (item.IndexOf("CategoryName") == -1) //не существует, ищем дальше
                {
                    continue;
                }
                //Нашли, получаем параметры
                string[] parameter;

                parameter = item.Split(new char[] { '=' });//Разбиваем параметр на 2 части
                if (parameter.Length < 2)//Проверяем длину
                {
                    is_ok = false;
                    return product;
                }
                string type = parameter[0];
                string category = parameter[1];

                //Проверяем, определена ли данная категория
                if (Products.CategoryIsExcist(category) == false)
                {
                    is_ok = false;
                    return product;
                }
                else
                {
                    switch (category)
                    {

                        case Products.CATEGORY_BREAD:
                            product = new Bread();
                            break;

                        case Products.CATEGORY_LOAF:
                            product = new Loaf();
                            break;

                        case Products.CATEGORY_BAGEL:
                            product = new Bagel();
                            break;

                        case Products.CATEGORY_BUN:
                            product = new Bun();
                            break;

                        case Products.CATEGORY_PITA:
                            product = new Pita();
                            break;
                    }

                    break;//Выходим из цикла foreach
                }
            }


            //Получаем остальные параметры
            foreach (var item in string_array)
            {
                string[] parameter;

                parameter = item.Split(new char[] { '=' });//Разбиваем параметр на 2 части
                if (parameter.Length < 2)//Проверяем длину
                {
                    continue;
                }
                string type = parameter[0];
                string str_value = parameter[1];
                double value;

                switch (type)
                {
                    case "ProductName": //Наименование продукции
                        try
                        {
                            product.ProductName = str_value;
                        }
                        catch
                        {
                            product.ProductName = "";
                        }
                        break;

                    case "Quantity": //Количество
                        double.TryParse(string.Join("", str_value.Where(c => char.IsDigit(c))), out value);
                        try
                        {
                            str_value = str_value.Replace('.', ',');
                            double.TryParse(str_value, out value);
                            product.Quantity = value;
                        }
                        catch
                        {
                            product.Quantity = 0;
                        }
                        break;


                    case "CategoryName"://Наименование категории
                        try
                        {
                            product.CategoryName = str_value;
                        }
                        catch
                        {
                            product.CategoryName = "";
                        }
                        break;
                }
            }
            is_ok = true;
            return product;
        }

        /// <summary>
        /// Разобрать строку содержащую информацию об ингредиенте
        /// </summary>
        /// <param name="input_string">Строка с информацией об ингредиенте</param>
        /// <returns>Возвращает Ingredient</returns>
        static Ingredient ParseIngredient(string input_string)
        {
            //Формат
            //"ingredient : Name = Мука, Value = 0.3, Calorie = 364, Price = 1.39;"

            Ingredient ingredient = new Ingredient();

            //Определяем позицию после двоеточия
            int positions = input_string.LastIndexOf(':');
            string edit_string = input_string.Substring(positions + 1);
            //Разбиваем строку на массив строк
            string[] string_array = edit_string.Split(',', StringSplitOptions.RemoveEmptyEntries);
            //Получаем параметры
            foreach (var item in string_array)
            {
                string[] parameter;

                parameter = item.Split(new char[] { '=' });//Разбиваем параметр на 2 части
                if (parameter.Length < 2)//Проверяем длину
                {
                    continue;
                }
                string type = parameter[0];
                string str_value = parameter[1];
                double value;

                switch (type)
                {
                    case "Name":
                        try
                        {
                            ingredient.Name = str_value;
                        }
                        catch
                        {
                            ingredient.Name = "";
                        }
                        break;

                    case "Value":
                        try
                        {
                            str_value = str_value.Replace('.', ',');
                            double.TryParse(str_value, out value);
                            ingredient.Value = value;
                        }
                        catch
                        {
                            ingredient.Value = 0;
                        }
                        break;

                    case "Calorie":
                        try
                        {
                            str_value = str_value.Replace('.', ',');
                            double.TryParse(str_value, out value);
                            ingredient.Calorie = value;
                        }
                        catch
                        {
                            ingredient.Calorie = 0;
                        }
                        break;

                    case "Price":
                        try
                        {
                            str_value = str_value.Replace('.', ',');
                            double.TryParse(str_value, out value);
                            ingredient.Price = value;
                        }
                        catch
                        {
                            ingredient.Price = 0;
                        }
                        break;
                }

            }
            return ingredient;
        }
    }
}
