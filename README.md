# Task-01
Declaring and calling methods
         
Формат данных:

         {
         category : CategoryName = Pita, ProductName = Грузинский, Quantity = 10;
         ingredient : Name = Мука, Value = 0.3, Calorie = 364, Price = 1;
         ingredient : Name = Вода, Value = 0.1, Calorie = 0, Price = 0.016;
         ingredient : Name = Соль, Value = 0.01, Calorie = 0, Price = 0.65;
         }
Структура проекта:

ClassLibrary - Библиотека классов. Содержит:
- Categorys - Папка содержащая категории продукции (Бублик, Хлеб, Булочка, Лаваш, Батон)
- Products - Абстрактный класс. Наследуется классами Bread, Bagel, Bun, Pita, Loaf.
- Bread, Bagel, Bun, Pita, Loaf - Категории хлебобулочных изделий. Наследуют абстрактный класс Products.
- Ingredient - Класс формирующий состав продукта.
- FoldersAndFiles - Класс содержащий методы для работы с файлами (Открыть, Сохранить, Создать папку).
- ParseString - Класс для разбора и получения данных из строки с информацией о производстве.
- ProductsSort - Класс содержащий методы для сортировки массива по заданным параметрам.
         
ClassLibrary.Tests - Проект модульных тестов. Проверяет: 
- разбор строки, 
- расчет цены, 
- расчет калорий, 
- наценку по категориям,
- сортировку по заданным условиям
 
