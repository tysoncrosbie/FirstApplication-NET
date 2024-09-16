using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class PortfolioRepository(AppDbContext context) : IPortfolioRepository
{
    public async Task<Portfolio> CreateAsync(Portfolio portfolio)
    {
        await context.Portfolios.AddAsync(portfolio);
        await context.SaveChangesAsync();
        return portfolio;
    }

    public async Task<Portfolio?> DeletePortfolio(AppUser? appUser, string symbol)
    {
        var portfolioModel = await context.Portfolios.FirstOrDefaultAsync(x =>
            appUser != null && x.AppUserId == appUser.Id 
                            && x.Stock != null
                            && x.Stock.Symbol != null
                            && x.Stock.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase));

        if (portfolioModel == null) return null;

        context.Portfolios.Remove(portfolioModel);
        await context.SaveChangesAsync();
        return portfolioModel;
    }

    public async Task<List<Stock>> GetUserPortfolio(AppUser? user)
    {
       return await context.Portfolios.Where(u => user != null && u.AppUserId == user.Id)
            .Select(stock => new Stock
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Industry = stock.Stock.Industry,
                MarketCap = stock.Stock.MarketCap
            }).ToListAsync();
    }
}