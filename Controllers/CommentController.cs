using Api.Dtos.Comment;
using Api.Extentions;
using Api.Helpers;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController(
    ICommentRepository commentRepo,
    IStockRepository stockRepo,
    IFMPService fmpService,
    UserManager<AppUser> userManager
) : ControllerBase

{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] CommentQueryObject queryObject)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var comments = await commentRepo.GetAllAsync(queryObject);

        var commentDto = comments.Select(s => s.ToCommentDto());

        return Ok(commentDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await commentRepo.GetIdAsync(id);

        if (comment == null) return NotFound();

        return Ok(comment);
    }

    [HttpPost]
    [Route("{symbol:alpha}")]
    public async Task<IActionResult> Create([FromRoute] string symbol, CreateComment commentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stock = await stockRepo.GetBySymbolAsync(symbol);

        if (stock == null)
        {
            stock = await fmpService.FindStockBySymbolAsync(symbol);

            if (stock == null) return BadRequest("Stock does not exists");

            await stockRepo.CreateAsync(stock);
        }

        var username = User.GetUsername();

        if (username == null) return NotFound();

        var appUser = await userManager.FindByNameAsync(username);
        var commentModel = commentDto.ToCommentFromDto(stock.Id);

        commentModel.AppUserId = appUser?.Id;

        await commentRepo.CreateAsync(commentModel);

        return CreatedAtAction(nameof(GetById),
            new { id = commentModel.Id }, commentModel.ToCommentDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateComment commentRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var comment = await commentRepo.UpdateAsync(id, commentRequest.ToCommentFromUpdate());

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