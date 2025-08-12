using CleanShop.Common.Business;
using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Services.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderLineController : ControllerBase
{
    private readonly IOrderLineReadFacade _readFacade;
    private readonly IOrderLineWriteFacade _writeFacade;

    public OrderLineController(IOrderLineReadFacade readFacade, IOrderLineWriteFacade writeFacade)
    {
        _readFacade = readFacade;
        _writeFacade = writeFacade;
    }

    [HttpGet]
    public async Task<IEnumerable<OrderLine>> GetAll()
        => await _readFacade.GetAllAsync().ConfigureAwait(false);

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderLine>> GetById(int id)
    {
        OrderLine? orderLine = await _readFacade.GetByIdAsync(id).ConfigureAwait(false);
        if (orderLine == null)
        {
            return NotFound();
        }

        return orderLine;
    }

    [HttpPost]
    public async Task<ActionResult> Create(OrderLine orderLine)
    {
        await _writeFacade.AddAsync(orderLine).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetById), new { id = orderLine.Id }, orderLine);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, OrderLine orderLine)
    {
        if (id != orderLine.Id)
        {
            return BadRequest();
        }

        await _writeFacade.UpdateAsync(orderLine).ConfigureAwait(false);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _writeFacade.RemoveAsync(id).ConfigureAwait(false);
        return NoContent();
    }
}
