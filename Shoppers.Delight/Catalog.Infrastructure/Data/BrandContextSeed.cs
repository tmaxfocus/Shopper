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
    public  static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrand = brandCollection.Find(a => true).Any();
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "brand.json");
            if (!checkBrand)
            {
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null)
                {
                    foreach (var productBrand in brands)
                    {
                        brandCollection.InsertOneAsync(productBrand);
                    }
                }
            }
        }
    }
}
