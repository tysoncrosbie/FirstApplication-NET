using Api.Dtos.Stock;
using Api.Helpers;
using Api.Models;

namespace Api.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync(QueryRecord query);
    Task<Stock?> GetIdAsync(int id);
    Task<Stock> CreateAsync(Stock stock);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequest stockRequest);
    Task<Stock?> DeleteAsync(int id);
    Task<bool> StockExists(int id);
}