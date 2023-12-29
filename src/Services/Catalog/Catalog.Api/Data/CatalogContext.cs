
namespace Catalog.Api.Data;

public class CatalogContext : ICatalogContext
{
    IConfiguration _configuration;
    public CatalogContext(IConfiguration configuration)
    {
        _configuration = configuration;
        var client = new MongoClient(GetConfigurationValue("ConnectionString"));
        var database = client.GetDatabase(GetConfigurationValue("DatabaseName"));
        Products = database.GetCollection<Product>(GetConfigurationValue("CollectionName"));
        CatalogContextSeed.SeedData(Products);
    }
    public IMongoCollection<Product> Products { get;}

    private string GetConfigurationValue(string value)
        => _configuration.GetValue<string>($"ConnectionStrings:{value}");
}
