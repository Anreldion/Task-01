using ClassLibrary.Ingredients;
using NUnit.Framework;
using System;
using Tests.Shared;

namespace Tests.Ingredients;

[TestFixture]
[TestOf(typeof(Ingredient))]
public class IngredientTest
{

    [Test]
    public void Constructor_CallWithoutParameters()
    {
        var product = new Ingredient();
        Assert.That(() => product.Name == null &&
                          product.Calorie == 0 &&
                          product.Price == 0 &&
                          product.Weight == 0);
    }

    [Test]
    public void Constructor_Throws_WhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var item = new Ingredient(name:null, calorie: 364, price: 1.50, weight: 0.3);
        });
    }

    [Test]
    public void Constructor_Throws_WhenCalorieIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var item = new Ingredient(name: "Flour", calorie: -1, price: 1.50, weight: 0.3);
        });
    }

    [Test]
    public void Constructor_Throws_WhenPriceIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var item = new Ingredient(name: "Flour", calorie: 0, price: -1.50, weight: 0.3);
        });
    }

    [Test]
    public void Constructor_Throws_WhenWeightIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var item = new Ingredient(name: "Flour", calorie: 0, price: 1.50, weight: -0.3);
        });
    }

    [Test]
    public void Constructor_SetsPropertiesCorrectly()
    {
        var item = new Ingredient(name: "Flour", calorie: 0, price: 1.50, weight: 0.3);

        Assert.That(item.Name, Is.EqualTo("Flour"));
        Assert.That(item.Calorie, Is.EqualTo(0).Within(TestData.Tolerance));
        Assert.That(item.Price, Is.EqualTo(1.50).Within(TestData.Tolerance));
        Assert.That(item.Weight, Is.EqualTo(0.3).Within(TestData.Tolerance));
    }

    [Test]
    public void Clone_ReturnsEqualObject()
    {
        var item = TestData.Flour.Clone();
        Assert.That(item.Equals(TestData.Flour));
    }

    [Test]
    public void Clone_ReturnsDifferentReference()
    {
        var item = TestData.Flour.Clone();
        Assert.That(item != TestData.Flour);
    }

    [Test]
    public void Equals_ReturnsTrue_ForIdenticalValues()
    {
        var item = new Ingredient("Flour", calorie: 364, price: 1.50, weight: 0.3);
        Assert.That(item.Equals(TestData.Flour));
    }

    [Test]
    public void Equals_ReturnsFalse_ForDifferentValues()
    {
        Assert.That(!TestData.Water.Equals(TestData.Flour));
    }

    [Test]
    public void Equals_ReturnsFalse_WhenComparedWithNull()
    {
        Assert.That(!TestData.Water.Equals(null));
    }

    [Test]
    public void GetHashCode_ReturnsSame_ForEqualObjects()
    {
        var hashCode1 = new Ingredient("Flour", calorie: 364, price: 1.50, weight: 0.3).GetHashCode();
        var hashCode2 = new Ingredient("Flour", calorie: 364, price: 1.50, weight: 0.3).GetHashCode();
        Assert.That(hashCode1 == hashCode2);
    }

    [Test]
    public void GetHashCode_Differs_ForDifferentObjects()
    {
        var hashCode1 = TestData.Water.GetHashCode();
        var hashCode2 = TestData.Flour.GetHashCode();
        Assert.That(hashCode1 != hashCode2);
    }


    [Test]
    public void ToString_ReturnsFormattedString()
    {
        var item = TestData.Water.ToString();
        Assert.That(item == "Water (0.2) - 0.00 $ / 0 kcal");
    }


}