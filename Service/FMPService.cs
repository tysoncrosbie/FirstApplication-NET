using Api.Dtos.Stock;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Newtonsoft.Json;

namespace Api.Service;

public class FMPService : IFMPService
    {
        private HttpClient _httpClient;
        private IConfiguration _config;
        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<Stock?> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_config["FMPKey"]}");
                
                if (!result.IsSuccessStatusCode) return null;
                
                var content = await result.Content.ReadAsStringAsync();
                var fmpstock = JsonConvert.DeserializeObject<FMPStock[]>(content);
                var stock = fmpstock![0];

                return stock.ToStockFromFMP();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
    