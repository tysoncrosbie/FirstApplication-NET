using Api.Dtos.Stock;
using Api.Models;

namespace Api.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        var stockDto = new StockDto(
            stockModel.Id,
            stockModel.Symbol,
            stockModel.CompanyName,
            stockModel.LastDiv,
            stockModel.Purchase,
            stockModel.Industry,
            stockModel.MarketCap,
            stockModel.Comments.Select(c => c.ToCommentDto()).ToList());

        return stockDto;
    }

    public static Stock ToStockFromDto(this CreateStockRequest stockRequest)
    {
        return new Stock
        {
            Symbol = stockRequest.Symbol,
            CompanyName = stockRequest.CompanyName,
            LastDiv = stockRequest.LastDiv,
            Purchase = stockRequest.Purchase,
            Industry = stockRequest.Industry,
            MarketCap = stockRequest.MarketCap
        };
    }
}