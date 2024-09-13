using Api.Dtos.Stock;
using Api.Helpers;
using Api.Models;

namespace Api.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync(QueryRecord query);
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock?> GetBySymbolAsync(string symbol);

    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequest stockDto);
    Task<Stock?> DeleteAsync(int id);

    Task<bool> StockExists(int id);
}