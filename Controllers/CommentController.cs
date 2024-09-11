using Api.Dtos.Comment;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController(
    ICommentRepository commentRepo,
    IStockRepository stockRepo
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await commentRepo.GetAllAsync();
        var commentDtos = comments.Select(s => s.ToCommentDto());

        return Ok(commentDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await commentRepo.GetIdAsync(id);

        if (comment == null) return NotFound();

        return Ok(comment);
    }

    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentRequest createRequest)
    {
        if (!await stockRepo.StockExists(stockId)) return BadRequest("Stock does not exist");
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var commentModel = createRequest.ToCommentFromDto(stockId);

        await commentRepo.CreateAsync(commentModel);

        return CreatedAtAction(nameof(GetById),
            new { id = commentModel.Id }, commentModel.ToCommentDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequest updateRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var comment = await commentRepo.UpdateAsync(id, updateRequest.ToCommentFromUpdate());

        if (comment == null) return NotFound();

        return Ok(comment.ToCommentDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var comment = await commentRepo.DeleteAsync(id);

        if (comment == null) return NotFound();

        return NoContent();
    }
}