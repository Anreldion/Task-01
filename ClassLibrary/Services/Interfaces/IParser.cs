using ClassLibrary.Products;

namespace ClassLibrary.Services.Interfaces
{
    public interface IParser
    {
        string Serialize(BakedProduct[] input);
        BakedProduct[] Deserialize(string input);
    }
}
