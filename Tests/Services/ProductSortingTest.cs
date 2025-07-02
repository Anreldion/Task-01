using ClassLibrary.Products;
using ClassLibrary.Services;
using ClassLibrary.Services.Interfaces;
using NUnit.Framework;
using System;
using System.Linq;
using Tests.Shared;

namespace Tests.Services;

[TestFixture]
[TestOf(typeof(ProductSorting))]
public class ProductSortingTest
{

    private IProductSorting _service;
    private BakedProduct[] _products;

    [SetUp]
    public void SetUp()
    {
        _service = new ProductSorting();
        _products = TestData.GetSampleProducts();
    }

    [Test]
    public void CloneAndSortByCalories_ReturnsSortedArray()
    {
        var products = _service.CloneAndSortByCalories(_products);
        var calorie = products.First().GetCalories();
        var result = true;

        foreach (var product in products)
        {
            if (calorie > product.GetCalories())
            {
                result = false;
                break;
            }
            calorie = product.GetCalories();
        }

        Assert.That(result, Is.True);
    }

    [Test]
    public void CloneAndSortByCalories_DoesNotAffectOriginalArray()
    {
        var products = _service.CloneAndSortByCalories(_products);
        Assert.That(products, Is.Not.SameAs(_products));
    }

    [Test]
    public void CloneAndSortByCalories_Throws_WhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _service.CloneAndSortByCalories(null));
    }

    [Test]
    public void CopyAndSortByPrice_ReturnsSortedArray()
    {
        var products = _service.CopyAndSortByPrice(_products);
        var price = products.First().GetPrice();
        var result = true;

        foreach (var product in products)
        {
            if (price > product.GetPrice())
            {
                result = false;
                break;
            }
            price = product.GetPrice();
        }

        Assert.That(result, Is.True);
    }

    [Test]
    public void CopyAndSortByPrice_DoesNotAffectOriginalArray()
    {
        var products = _service.CopyAndSortByPrice(_products);
        Assert.That(products, Is.Not.SameAs(_products));
    }

    [Test]
    public void CopyAndSortByPrice_Throws_WhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _service.CopyAndSortByPrice(null));
    }
}