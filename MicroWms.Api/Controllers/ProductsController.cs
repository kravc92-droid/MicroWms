using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroWms.Api.Data;
using MicroWms.Api.DTOs;
using MicroWms.Domain.Entities;

namespace MicroWms.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly WmsDbContext _dbContext;

    public ProductsController(WmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(
        CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Article = request.Article.Trim(),
            Name = request.Name.Trim()
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProducts),
            new { id = product.Id },
            product);
    }
}
