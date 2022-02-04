using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var dbSettings = configuration.GetSection("DatabasedSettings");
            var client = new MongoClient(dbSettings.GetValue<string>("ConnnectionString"));
            var db = client.GetDatabase(dbSettings.GetValue<string>("DatabaseName"));

            Products = db.GetCollection<Product>(dbSettings.GetValue<string>("CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
