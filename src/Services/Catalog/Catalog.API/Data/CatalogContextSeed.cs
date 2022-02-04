using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> mongoCollection)
        {
            bool existCollection = mongoCollection.Find(_ => true).Any();
            if (!existCollection)
            {
                mongoCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new Product[]
            {
                new Product
                {
                    Id = "111",
                    Name = "Asus",
                    Category = "Computers",
                    Summary = "Summary",
                    Description = "Description",
                    ImageFile = "ImageFile.png",
                    Price= 54.93M
                }
            };
        }
    }
}
