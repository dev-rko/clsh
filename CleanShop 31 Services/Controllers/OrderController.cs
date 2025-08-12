using CleanShop.Common.Business;
using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Services.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderReadFacade _readFacade;
    private readonly IOrderWriteFacade _writeFacade;

    public OrderController(IOrderReadFacade readFacade, IOrderWriteFacade writeFacade)
    {
        _readFacade = readFacade;
        _writeFacade = writeFacade;
    }

    [HttpGet]
    public async Task<IEnumerable<Order>> GetAll()
        => await _readFacade.GetAllAsync().ConfigureAwait(false);

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        Order? order = await _readFacade.GetByIdAsync(id).ConfigureAwait(false);
        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Order order)
    {
        await _writeFacade.AddAsync(order).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        await _writeFacade.UpdateAsync(order).ConfigureAwait(false);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _writeFacade.RemoveAsync(id).ConfigureAwait(false);
        return NoContent();
    }
}
