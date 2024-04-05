using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkBrand = typeCollection.Find(a => true).Any();
            string path = Path.Combine("Data", "SeedData", "type.json");
            if (!checkBrand)
            {
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductType>>(brandsData);
                if (brands != null)
                {
                    foreach (var productBrand in brands)
                    {
                        typeCollection.InsertOneAsync(productBrand);
                    }
                }
            }
        }
    }
}
