using Api.Extentions;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/portfolio")]
[ApiController]
public class PortfolioController(
    UserManager<AppUser> userManager,
    IStockRepository stockRepo,
    IPortfolioRepository portfolioRepo,
    IFMPService fmpService)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserPortfolio()
    {
        var username = User.GetUsername();
        if (username != null)
        {
            var appUser = await userManager.FindByNameAsync(username);
            var userPortfolio = await portfolioRepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }
        return NotFound();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddPortfolio(string symbol)
    {
        var username = User.GetUsername();
        if (username != null)
        {
            var appUser = await userManager.FindByNameAsync(username);
            var stock = await stockRepo.GetBySymbolAsync(symbol);

            if (stock == null)
            {
                stock = await fmpService.FindStockBySymbolAsync(symbol);

                if (stock == null) return BadRequest("Stock does not exists");

                await stockRepo.CreateAsync(stock);
            }

            var userPortfolio = await portfolioRepo.GetUserPortfolio(appUser);

            if (userPortfolio.Any(e => e.Symbol != null && e.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase)))
                return BadRequest("Cannot add same stock to portfolio");

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser?.Id
            };

            await portfolioRepo.CreateAsync(portfolioModel);
        }

        return Created();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeletePortfolio(string symbol)
    {
        var username = User.GetUsername();
        if (username != null)
        {
            var appUser = await userManager.FindByNameAsync(username);

            var userPortfolio = await portfolioRepo.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where(s => s.Symbol != null && s.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase)).ToList();

            if (filteredStock.Count() == 1)
                await portfolioRepo.DeletePortfolio(appUser, symbol);
            else
                return BadRequest("Stock not in your portfolio");
        }

        return Ok();
    }
}