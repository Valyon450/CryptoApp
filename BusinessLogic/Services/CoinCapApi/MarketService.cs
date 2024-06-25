using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Services.CoinCapApi.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CoinCapApi
{
    public class MarketService : IMarketService
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _baseUrl = "https://api.coincap.io/v2/exchanges/";

        public async Task<MarketDTO> GetMarketInfo(string exchangeId)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}{exchangeId}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ExchangeByIdResponse>(json);
                    var marketData = data.Data;
                    var updatedDateTime = DateTimeOffset.FromUnixTimeMilliseconds(marketData.Updated).UtcDateTime;
                    return data.Data;
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching the currency data: {ex.Message}");
            }

            return null;
        }
    }
}

