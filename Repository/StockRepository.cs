using Api.Data;
using Api.Dtos.Stock;
using Api.Helpers;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class StockRepository(AppDbContext context) : IStockRepository

{
    public async Task<List<Stock>> GetAllAsync(QueryRecord query)
    {
        var stocks = context.Stocks.Include(c => c.Comments).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.CompanyName))
            stocks = stocks.Where(x => x.Symbol.Contains(query.CompanyName));

        if (!string.IsNullOrWhiteSpace(query.Symbol)) stocks = stocks.Where(x => x.Symbol.Contains(query.Symbol));

        if (!string.IsNullOrWhiteSpace(query.SortBy))
            if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                stocks = query.IsDecsending
                    ? stocks.OrderByDescending(s => s.Symbol)
                    : stocks.OrderBy(s => s.Symbol);
        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Stock?> GetBySymbolAsync(string symbol)
    {
        return await context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
    }

    public async Task<Stock> CreateAsync(Stock stockRequest)
    {
        await context.Stocks.AddAsync(stockRequest);
        await context.SaveChangesAsync();
        return stockRequest;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStock stockRequest)
    {
        var stock = await context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (stock == null) return null;

        stock.Symbol = stockRequest.Symbol;
        stock.CompanyName = stockRequest.CompanyName;
        stock.Purchase = stockRequest.Purchase;
        stock.LastDiv = stockRequest.LastDiv;
        stock.Industry = stockRequest.Industry;
        stock.MarketCap = stockRequest.MarketCap;

        await context.SaveChangesAsync();

        return stock;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stock = context.Stocks.FirstOrDefault(s => s.Id == id);

        if (stock == null) return null;

        context.Stocks.Remove(stock);
        await context.SaveChangesAsync();

        return stock;
    }

    public Task<bool> StockExists(int id)
    {
        return context.Stocks.AnyAsync(x => x.Id == id);
    }
}