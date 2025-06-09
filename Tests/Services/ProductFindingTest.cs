using System;
using System.Linq;
using ClassLibrary.enums;
using ClassLibrary.Ingredients;
using ClassLibrary.Products;
using ClassLibrary.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Tests.Shared;

namespace Tests.Services;

[TestFixture]
[TestOf(typeof(ProductFinding))]
public class ProductFindingTest
{

    private ProductFinding _service;

    [SetUp]
    public void SetUp()
    {
        _service = new ProductFinding();
    }

    // ---------- FindByPriceAndCalories ----------

    [Test]
    public void FindByPriceAndCalories_ReturnsMatchingProducts()
    {
        var items = TestData.GetSampleProducts();
        var bakedProducts = _service.FindByPriceAndCalories(items, 0.54, 112.2);
        Assert.That(() =>
        {
            var result = bakedProducts.Contains(TestData.ClassicBread);
            return result;
        });
    }

    [Test]
    public void FindByPriceAndCalories_ReturnsEmpty_WhenNoMatches()
    {
        var items = TestData.GetSampleProducts();
        var result = _service.FindByPriceAndCalories(items, 1000, 10000);
        Assert.That(result.Length == 0);
    }

    [Test]
    public void FindByPriceAndCalories_Throws_WhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(()=>
        {
            _service.FindByPriceAndCalories(null, 100, 100);
        });
    }

    [Test]
    public void FindByPriceAndCalories_Throws_WhenPriceIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            _service.FindByPriceAndCalories(TestData.GetSampleProducts(), -100, 100);
        });
    }

    [Test]
    public void FindByPriceAndCalories_Throws_WhenCalorieIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            _service.FindByPriceAndCalories(TestData.GetSampleProducts(), 100, -100);
        });
    }


    [Test]
    public void FindByIngredientWeightThreshold_ReturnsMatchingProducts()
    {
        var items = TestData.GetSampleProducts();
        var bakedProducts = _service.FindByIngredientWeightThreshold(items, "Flour",0.1);
        Assert.That(() =>
        {
            var result = bakedProducts.Contains(TestData.BagelMax);
            return result;
        });
    }

    [Test]
    public void FindByIngredientWeightThreshold_ReturnsEmpty_WhenNoMatches()
    {
        var items = TestData.GetSampleProducts();
        var bakedProducts = _service.FindByIngredientWeightThreshold(items, "Name", 0.1);
        Assert.That(bakedProducts.Length == 0);
    }

    [Test]
    public void FindByIngredientWeightThreshold_Throws_WhenProductsIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _service.FindByIngredientWeightThreshold(null, "test", 1);
        });
    }

    [Test]
    public void FindByIngredientWeightThreshold_Throws_WhenIngredientNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _service.FindByIngredientWeightThreshold(TestData.GetSampleProducts(), null, 1);
        });
    }

    [Test]
    public void FindByIngredientWeightThreshold_Throws_WhenMinWeightIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            _service.FindByIngredientWeightThreshold(TestData.GetSampleProducts(), "test", -1);
        });
    }

    [Test]
    public void FindByIngredientCountThreshold_ReturnsMatchingProducts()
    {
        var items = TestData.GetSampleProducts();
        var bakedProducts = _service.FindByIngredientCountThreshold(items, 3);
        Assert.That(() =>
        {
            var result = bakedProducts.Contains(TestData.ClassicBread);
            return result;
        });
    }

    [Test]
    public void FindByIngredientCountThreshold_ReturnsEmpty_WhenNoMatches()
    {
        var items = TestData.GetSampleProducts();
        var bakedProducts = _service.FindByIngredientCountThreshold(items, 10);
        Assert.That(bakedProducts.Length == 0);
    }

    [Test]
    public void FindByIngredientCountThreshold_Throws_WhenProductsIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _service.FindByIngredientCountThreshold( null, 1);
        });

    }

    [Test]
    public void FindByIngredientCountThreshold_Throws_WhenCountIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            _service.FindByIngredientCountThreshold(TestData.GetSampleProducts(), -1);
        });
    }
}