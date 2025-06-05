using System;
using ClassLibrary.Products;
using System.Collections.Generic;

namespace ClassLibrary.Services.Interfaces
{
    public interface IParser
    {
        string Serialize(BakeryProduct[] input);
        BakeryProduct[] Deserialize(string input);
    }
}
