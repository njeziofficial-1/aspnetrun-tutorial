
using Catalog.Api.Data;

namespace Catalog.Api.Repositories;

public class ProductRepository : IProductRepository
{
    readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task CreateProductAsync(Product product)
    => await _context.Products.InsertOneAsync(product);

    public async Task<bool> DeleteProductAsync(string id)
    {
        var filter = Builders<Product>.Filter.Eq(p=> p.Id, id);
        var deletedResult = await _context.Products.DeleteOneAsync(filter);
        return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
    }

    public async Task<Product> GetProductAsync(string id)
    => await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsAsync()
    => await _context.Products.Find(p => true).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoty)
    => await _context.Products.Find(x => x.Category.ToLower().Equals(categoty.ToLower())).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    => await _context.Products.Find(x => x.Name.ToLower().Equals(name.ToLower())).ToListAsync();

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updatedResult = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
        return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
    }
}
