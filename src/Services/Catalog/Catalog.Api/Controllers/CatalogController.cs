using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    IProductRepository _repository;
    ILogger<CatalogController> _logger;

    public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts()
        => Ok(await _repository.GetProductsAsync());

    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult>GetProductById(string id)
    {
        var product = await _repository.GetProductAsync(id.Trim());
        if (product is null)
        {
            _logger.LogError($"Product with id:{id} can not be found");
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    [Route("[action]/{name}", Name = "GetProductByName")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByName(string name)
    {
        var products = await _repository.GetProductsByNameAsync(name.Trim());
        if (products is null || !products.Any())
        {
            _logger.LogError($"Products with name:{name} can not be found");
            return NotFound();
        }
        return Ok(products);
    }

    [HttpGet]
    [Route("[action]/{category}", Name ="GetProductByCategory")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult>GetProductByCategory(string category)
    {
        var products = await _repository.GetProductsByCategoryAsync(category.Trim());
        if (products is null || !products.Any())
        {
            _logger.LogError($"Products with category:{category} can not be found");
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateProduct([FromBody]Product product)
    {
        await _repository.CreateProductAsync(product);
        return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
    }

    [HttpPut]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        => Ok(await _repository.UpdateProductAsync(product));

    [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult>DeleteProductById(string id)
    => Ok(await _repository.DeleteProductAsync(id.Trim()));
}
