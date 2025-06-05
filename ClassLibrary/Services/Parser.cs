using ClassLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using ClassLibrary.Products;

namespace ClassLibrary.Services
{
    public class Parser : IParser
    {
        public BakeryProduct[] Deserialize(string input)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<BakeryProduct>>(input, options).ToArray();
        }

        public string Serialize(BakeryProduct[] input)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Serialize(input, options);
        }
    }
}
