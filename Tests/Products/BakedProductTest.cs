using ClassLibrary.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.enums;
using ClassLibrary.Ingredients;

namespace Tests.Products;

[TestFixture]
[TestOf(typeof(BakedProduct))]
public class BakedProductTest
{
    private const double Tolerance = 0.01;
    private static Ingredient Flour => new("Flour", calorie: 364, price: 1.50, weight: 0.3);
    private static Ingredient Water => new("Water", calorie: 0, price: 0, weight: 0.2);
    private static Ingredient Yeast => new("Yeast", calorie: 300, price: 0.50, weight: 0.01);
    private static Ingredient Salt => new("Salt", calorie: 0, price: 0.20, weight: 0.005);

    private static List<Ingredient> GetStandardIngredients() => [Flour, Water, Yeast, Salt];

    private static BakedProduct[] GetSampleProducts()
    {
        var product1 = new BakedProduct(
            name: "Classic Bread",
            category: ProductCategory.Bread,
            markup: 1.2,
            ingredients:
            [
                new Ingredient("Flour", 364, 1.50, 0.3),
                new Ingredient("Water", 0, 0, 0.2),
                new Ingredient("Yeast", 300, 0.50, 0.01),
                new Ingredient("Salt", 0, 0.20, 0.005)
            ]);

        var product2 = new BakedProduct(
            name: "Sweet Bun",
            category: ProductCategory.Bun,
            markup: 1.3,
            ingredients:
            [
                new Ingredient("Flour", 364, 1.50, 0.25),
                new Ingredient("Sugar", 387, 1.00, 0.05),
                new Ingredient("Butter", 717, 2.50, 0.1)
            ]);

        var product3 = new BakedProduct(
            name: "Pita Light",
            category: ProductCategory.Pita,
            markup: 1.1,
            ingredients:
            [
                new Ingredient("Flour", 364, 1.50, 0.2),
                new Ingredient("Water", 0, 0, 0.15),
                new Ingredient("Salt", 0, 0.20, 0.003)
            ]);

        return [product1, product2, product3];
    }
    
    [Test]
    public void Constructor_Throws_WhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var item = new BakedProduct(null, ProductCategory.Bread, 0.1, GetStandardIngredients());
        });
    }

    [Test]
    public void Constructor_Throws_WhenIngredientsIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var item = new BakedProduct("Bread", ProductCategory.Bread, 0.1, null);
        });
    }

    [Test]
    public void Constructor_Throws_WhenIngredientsIsEmpty()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            var item = new BakedProduct("Bread", ProductCategory.Bread, 0.1, []);
        });
    }

    [Test]
    public void Constructor_SetsPropertiesCorrectly()
    {
        var ingredients = GetStandardIngredients();
        var item = new BakedProduct("Bread", ProductCategory.Bread, 0.1, ingredients);

        Assert.That(item.Name, Is.EqualTo("Bread"));
        Assert.That(item.ProductCategory, Is.EqualTo(ProductCategory.Bread));
        Assert.That(item.Markup, Is.EqualTo(0.1).Within(Tolerance));
        Assert.That(item.Ingredients, Is.EqualTo(ingredients));
    }


    [Test]
    public void GetCalories_CalculatesCorrectly()
    {
        var calories = new BakedProduct("Bread", ProductCategory.Bread, 1.5, GetStandardIngredients()).GetCalories();
        Assert.That(Math.Abs(calories - 112.2) < Tolerance);
    }

    [Test]
    public void GetPrice_CalculatesCorrectly()
    {
        var price = new BakedProduct("Bread", ProductCategory.Bread, 1.5, GetStandardIngredients()).GetPrice();
        Assert.That(Math.Abs(price - 0.683) < Tolerance);
    }

    [Test]
    public void Clone_ReturnsDeepCopy()
    {
        var bakedProducts = GetSampleProducts();
        var cloned = bakedProducts.Select(x=>(BakedProduct)x.Clone()).ToArray();

        Assert.That(bakedProducts
            .Zip(cloned, (a, b) => a.Equals(b))
            .All(equal => equal));
    }

    [Test]
    public void Clone_ModifyingOriginalDoesNotAffectClone()
    {
        var bakedProducts = GetSampleProducts();
        var cloned = bakedProducts.Select(p => (BakedProduct)p.Clone()).ToArray();

        cloned[1].Name = "Test";
        cloned[1].Markup = 10;
        cloned[1].ProductCategory = ProductCategory.Pita;
        cloned[1].Ingredients = GetStandardIngredients();

        Assert.That(bakedProducts[1].Name != cloned[1].Name &&
                    Math.Abs(bakedProducts[1].Markup - cloned[1].Markup) > Tolerance &&
        bakedProducts[1].ProductCategory != cloned[1].ProductCategory &&
                    bakedProducts[1].Ingredients != cloned[1].Ingredients);
    }

    [Test]
    public void ToString_ReturnsFormattedOutput()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, GetStandardIngredients()).ToString();
        Assert.That(product1 == "Bread (Bread) - 0.05 $ / 112 kcal");
    }

    [Test]
    public void Equals_ReturnsTrue_ForIdenticalProducts()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, GetStandardIngredients());
        var product2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, GetStandardIngredients());
        Assert.That(product1.Equals(product2));
    }

    [Test]
    public void Equals_ReturnsFalse_ForDifferentProducts()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bagel, 0.1, GetStandardIngredients());
        var product2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, GetStandardIngredients());
        Assert.That(!product1.Equals(product2));
    }

    [Test]
    public void GetHashCode_IsEqual_ForEqualProducts()
    {
        var hashCode1 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, GetStandardIngredients()).GetHashCode();
        var hashCode2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, GetStandardIngredients()).GetHashCode();
        Assert.That(hashCode1 == hashCode2);
    }

    [Test]
    public void GetHashCode_Differs_ForDifferentProducts()
    {
        var hashCode1 = new BakedProduct("Bread", ProductCategory.Bagel, 0.1, GetStandardIngredients()).GetHashCode();
        var hashCode2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, GetStandardIngredients()).GetHashCode();
        Assert.That(hashCode1 != hashCode2);
    }

    [Test]
    public void IBakedProduct_CanBeUsedAsInterface()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bagel, 0.1, GetStandardIngredients());
        
        Assert.DoesNotThrow(() =>
        {
            IBakedProduct bakedProduct = product1;
            bakedProduct.GetPrice();
            bakedProduct.GetCalories();
        });
    }
}