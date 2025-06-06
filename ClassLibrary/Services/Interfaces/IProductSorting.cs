using ClassLibrary.Products;

namespace ClassLibrary.Services.Interfaces
{
    public interface IProductSorting
    {
        BakedProduct[] CloneAndSortByCalories(BakedProduct[] products);
        BakedProduct[] CopyAndSortByPrice(BakedProduct[] products);
    }
}
