using ClassLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using ClassLibrary.Products;
using System.Text.Json.Serialization;
using ClassLibrary.Utilities;

namespace ClassLibrary.Services
{
    /// <summary>
    /// Provides functionality to convert baked product arrays to and from JSON,
    /// including support for enums and case-insensitive properties.
    /// </summary>
    public class Parser : IParser
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
        };

        static Parser()
        {
            Options.Converters.Add(new JsonStringEnumConverter());
        }

        public BakedProduct[] Deserialize(string input)
        {
            return string.IsNullOrWhiteSpace(input)
                ? []
                : JsonSerializer.Deserialize<List<BakedProduct>>(input, Options).ToArray();
        }

        public string Serialize(BakedProduct[] input)
        {
            Guard.NotNull(input, nameof(input));

            return JsonSerializer.Serialize(input, Options);
        }
    }
}
