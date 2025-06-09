using ClassLibrary.Products;
using NUnit.Framework;
using System;
using System.Linq;
using ClassLibrary.enums;
using Tests.Shared;

namespace Tests.Products;

[TestFixture]
[TestOf(typeof(BakedProduct))]
public class BakedProductTest
{
    [Test]
    public void Constructor_Throws_WhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var item = new BakedProduct(null, ProductCategory.Bread, 0.1, TestData.StandardIngredients);
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
        var ingredients = TestData.StandardIngredients;
        var item = new BakedProduct("Bread", ProductCategory.Bread, 0.1, ingredients);

        Assert.That(item.Name, Is.EqualTo("Bread"));
        Assert.That(item.ProductCategory, Is.EqualTo(ProductCategory.Bread));
        Assert.That(item.Markup, Is.EqualTo(0.1).Within(TestData.Tolerance));
        Assert.That(item.Ingredients, Is.EqualTo(ingredients));
    }

    [Test]
    public void Constructor_CallWithoutParameters()
    {
        var product = new BakedProduct();
        Assert.That(() => product.ProductCategory == default &&
                          product.Markup == 0 &&
                          product.Name == null &&
                          product.Ingredients == null);
    }


    [Test]
    public void GetCalories_CalculatesCorrectly()
    {
        var calories = new BakedProduct("Bread", ProductCategory.Bread, 1.5, TestData.StandardIngredients).GetCalories();
        Assert.That(Math.Abs(calories - 112.2) < TestData.Tolerance);
    }

    [Test]
    public void GetPrice_CalculatesCorrectly()
    {
        var price = new BakedProduct("Bread", ProductCategory.Bread, 1.5, TestData.StandardIngredients).GetPrice();
        Assert.That(Math.Abs(price - 0.683) < TestData.Tolerance);
    }

    [Test]
    public void Clone_ReturnsDeepCopy()
    {
        var bakedProducts = TestData.GetSampleProducts();
        var cloned = bakedProducts.Select(x=>(BakedProduct)x.Clone()).ToArray();

        Assert.That(bakedProducts
            .Zip(cloned, (a, b) => a.Equals(b))
            .All(equal => equal));
    }

    [Test]
    public void Clone_ModifyingOriginalDoesNotAffectClone()
    {
        var bakedProducts = TestData.GetSampleProducts();
        var cloned = bakedProducts.Select(p => (BakedProduct)p.Clone()).ToArray();

        cloned[1].Name = "Test";
        cloned[1].Markup = 10;
        cloned[1].ProductCategory = ProductCategory.Pita;
        cloned[1].Ingredients = TestData.StandardIngredients;

        Assert.That(bakedProducts[1].Name != cloned[1].Name &&
                    Math.Abs(bakedProducts[1].Markup - cloned[1].Markup) > TestData.Tolerance &&
        bakedProducts[1].ProductCategory != cloned[1].ProductCategory &&
                    bakedProducts[1].Ingredients != cloned[1].Ingredients);
    }

    [Test]
    public void ToString_ReturnsFormattedOutput()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, TestData.StandardIngredients).ToString();
        Assert.That(product1 == "Bread (Bread) - 0.05 $ / 112 kcal");
    }

    [Test]
    public void Equals_ReturnsTrue_ForIdenticalProducts()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, TestData.StandardIngredients);
        var product2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, TestData.StandardIngredients);
        Assert.That(product1.Equals(product2));
    }

    [Test]
    public void Equals_ReturnsFalse_ForDifferentProducts()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bagel, 0.1, TestData.StandardIngredients);
        var product2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, TestData.StandardIngredients);
        Assert.That(!product1.Equals(product2));
    }

    [Test]
    public void GetHashCode_IsEqual_ForEqualProducts()
    {
        var hashCode1 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, TestData.StandardIngredients).GetHashCode();
        var hashCode2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, TestData.StandardIngredients).GetHashCode();
        Assert.That(hashCode1 == hashCode2);
    }

    [Test]
    public void GetHashCode_Differs_ForDifferentProducts()
    {
        var hashCode1 = new BakedProduct("Bread", ProductCategory.Bagel, 0.1, TestData.StandardIngredients).GetHashCode();
        var hashCode2 = new BakedProduct("Bread", ProductCategory.Bread, 0.1, TestData.StandardIngredients).GetHashCode();
        Assert.That(hashCode1 != hashCode2);
    }

    [Test]
    public void IBakedProduct_CanBeUsedAsInterface()
    {
        var product1 = new BakedProduct("Bread", ProductCategory.Bagel, 0.1, TestData.StandardIngredients);
        
        Assert.DoesNotThrow(() =>
        {
            IBakedProduct bakedProduct = product1;
            bakedProduct.GetPrice();
            bakedProduct.GetCalories();
        });
    }
}