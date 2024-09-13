using Api.Dtos.Stock;
using Api.Helpers;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController(IStockRepository stockRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryRecord query)
    {
        var stocks = await stockRepo.GetAllAsync(query);
        var stockDto = stocks.Select(s => s.ToStockDto()).ToList();

        return Ok(stockDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await stockRepo.GetByIdAsync(id);

        if (stock == null) return NotFound();

        return Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStock stockRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var stockModel = stockRequest.ToStockFromDto();
        await stockRepo.CreateAsync(stockModel);

        return CreatedAtAction(nameof(GetById),
            new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStock stockRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var stockModel = await stockRepo.UpdateAsync(id, stockRequest);

        if (stockModel == null) return NotFound();

        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var stockModel = await stockRepo.DeleteAsync(id);

        if (stockModel == null) return NotFound();

        return NoContent();
    }
}