using ClassLibrary.enums;
using ClassLibrary.Ingredients;
using ClassLibrary.Products;
using System.Collections.Generic;

namespace Tests.Shared
{
    public static class TestData
    {
        public const double Tolerance = 0.01;

        public static readonly Ingredient Flour = new("Flour", 364, 1.50, 0.3);
        public static readonly Ingredient Water = new("Water", 0, 0, 0.2);
        public static readonly Ingredient Yeast = new("Yeast", 300, 0.50, 0.01);
        public static readonly Ingredient Salt = new("Salt", 0, 0.20, 0.005);
        public static readonly Ingredient Sugar = new("Sugar", 387, 1.00, 0.05);
        public static readonly Ingredient Butter = new("Butter", 717, 2.50, 0.1);

        public static List<Ingredient> StandardIngredients => [Flour, Water, Yeast, Salt];

        public static readonly BakedProduct ClassicBread = new("Classic Bread", ProductCategory.Bread, 1.2,
            [Flour, Water, Yeast, Salt]);

        public static readonly BakedProduct SweetBun = new("Sweet Bun", ProductCategory.Bun, 1.3,
            [
                new Ingredient("Flour", 364, 1.50, 0.25),
                Sugar,
                Butter
            ]);

        public static readonly BakedProduct MiniBun = new("Mini Bun", ProductCategory.Bun, 1.1,
            [
                Flour,
                new Ingredient("Sugar", 387, 1.00, 0.03)
            ]);

        public static readonly BakedProduct PitaLight = new("Pita Light", ProductCategory.Pita, 1.1,
            [
                new Ingredient("Flour", 364, 1.50, 0.2),
                new Ingredient("Water", 0, 0, 0.15),
                new Ingredient("Salt", 0, 0.20, 0.003)
            ]);

        public static readonly BakedProduct LuxuryLoaf = new("Luxury Loaf", ProductCategory.Loaf, 1.5,
            [
                new Ingredient("Flour", 364, 1.50, 0.35),
                Butter,
                Salt
            ]);

        public static readonly BakedProduct DietBread = new("Diet Bread", ProductCategory.Bread, 1.0,
            [
                Flour,
                new Ingredient("Water", 0, 0, 0.25)
            ]);

        public static readonly BakedProduct BagelMax = new("Bagel Max", ProductCategory.Bagel, 1.4,
            [
                new Ingredient("Flour", 364, 1.50, 0.28),
                Sugar,
                new Ingredient("Yeast", 300, 0.50, 0.015)
            ]);

        public static BakedProduct[] GetSampleProducts() =>
        [
            ClassicBread,
            ClassicBread, 
            SweetBun,
            SweetBun,     
            MiniBun,
            PitaLight,
            PitaLight,    
            LuxuryLoaf,
            DietBread,
            BagelMax
        ];
    }
}
