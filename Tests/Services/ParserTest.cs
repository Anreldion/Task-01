using System;
using System.Linq;
using System.Text.Json;
using ClassLibrary.enums;
using ClassLibrary.Products;
using ClassLibrary.Services;
using NUnit.Framework;
using Tests.Shared;

namespace Tests.Services;

[TestFixture]
[TestOf(typeof(Parser))]
public class ParserTest
{

    private Parser _parser;
    private BakedProduct[] _sampleProducts;

    [SetUp]
    public void SetUp()
    {
        _parser = new Parser();
        _sampleProducts = [TestData.BagelMax];
    }
    
    [Test]
    public void Serialize_Throws_WhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(()=>_parser.Serialize(null));
    }

    [Test]
    public void Serialize_ProducesIndentedOutput()
    {
        var serialize = _parser.Serialize(_sampleProducts);
        Assert.That(serialize.Contains('\n'));
    }

    [Test]
    public void Serialize_EnumIsSerializedAsString()
    {
        var serialize = _parser.Serialize(_sampleProducts);
        Assert.That(serialize.Contains("\"Bagel\""));
    }

    [Test]
    public void Deserialize_ReturnsEmptyArray_WhenInputIsEmptyString()
    {
        var deserialize = _parser.Deserialize(string.Empty);
        Assert.That(deserialize.Length == 0);
    }

    [Test]
    public void Deserialize_ReturnsEmptyArray_WhenInputIsNull()
    {
        var deserialize = _parser.Deserialize(null);
        Assert.That(deserialize.Length == 0);
    }

    [Test]
    public void Deserialize_ParsesNestedProperties_IgnoringCase()
    {
        const string json = """
                            [
                              {
                                "name": "Bagel Max",
                                "productCategory": "Bagel",
                                "markup": 1.4,
                                "ingredients": [
                                  {
                                    "name": "Flour",
                                    "calorie": 364,
                                    "price": 1.5,
                                    "weight": 0.28
                                  },
                                  {
                                    "name": "Sugar",
                                    "Calorie": 387,
                                    "Price": 1,
                                    "Weight": 0.05
                                  },
                                  {
                                    "name": "Yeast",
                                    "Calorie": 300,
                                    "Price": 0.5,
                                    "Weight": 0.015
                                  }
                                ]
                              }
                            ]
                            """;
        var deserialize = _parser.Deserialize(json);
        Assert.That(deserialize.Contains(TestData.BagelMax));
    }

    [Test]
    public void Deserialize_ParsesEnumFromString()
    {
        var serialize = _parser.Serialize(_sampleProducts);
        var deserialize = _parser.Deserialize(serialize);
        Assert.That(deserialize[0].ProductCategory == ProductCategory.Bagel);
    }

    [Test]
    public void Deserialize_Throws_ForMalformedJson()
    {
        var serialize = _parser.Serialize(_sampleProducts).Replace("[", "]");
        Assert.Throws<JsonException>(()=>_parser.Deserialize(serialize));
    }
    
    [Test]
    public void Serialize_And_Deserialize_ProduceEqualObjects()
    {
        var serialize = _parser.Serialize(_sampleProducts);
        var deserialize = _parser.Deserialize(serialize);
        Assert.That(deserialize.Contains(TestData.BagelMax));
    }
}
