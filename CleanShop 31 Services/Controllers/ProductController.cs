using CleanShop.Common.Business;
using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Services.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductReadFacade _readFacade;
    private readonly IProductWriteFacade _writeFacade;

    public ProductController(IProductReadFacade readFacade, IProductWriteFacade writeFacade)
    {
        _readFacade = readFacade;
        _writeFacade = writeFacade;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAll()
        => await _readFacade.GetAllAsync().ConfigureAwait(false);

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        Product? product = await _readFacade.GetByIdAsync(id).ConfigureAwait(false);
        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Product product)
    {
        await _writeFacade.AddAsync(product).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        await _writeFacade.UpdateAsync(product).ConfigureAwait(false);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _writeFacade.RemoveAsync(id).ConfigureAwait(false);
        return NoContent();
    }
}
