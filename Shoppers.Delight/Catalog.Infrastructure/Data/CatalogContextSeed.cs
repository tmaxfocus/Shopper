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
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkBrand = productCollection.Find(a => true).Any();
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"Data", "SeedData", "products.json");
            if (!checkBrand)
            {
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<Product>>(brandsData);
                if (brands != null)
                {
                    foreach (var productBrand in brands)
                    {
                        productCollection.InsertOneAsync(productBrand);
                    }
                }
            }
        }
    }
}
