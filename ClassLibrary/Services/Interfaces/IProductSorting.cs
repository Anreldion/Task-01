using ClassLibrary.Products;

namespace ClassLibrary.Services.Interfaces
{
    public interface IProductSorting
    {
        BakedProduct[] CloneAndSortByCalorie(BakedProduct[] input);
        BakedProduct[] CopyAndSortByPrice(BakedProduct[] input);
    }
}
