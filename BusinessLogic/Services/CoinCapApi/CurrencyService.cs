using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Services.CoinCapApi.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CoinCapApi
{
    public class CurrencyService : ICurrencyService
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _baseUrl = "https://api.coincap.io/v2/assets/";

        public async Task<CurrencyDTO> GetCurrencyInfo(string assetId)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}{assetId}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<AssetByIdResponse>(json);
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

        public async Task<IEnumerable<CurrencyDTO>> GetCurrencies(string limit)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}?limit={limit}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<AssetsResponse>(json);
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

        public async Task<CurrencyDTO> SearchCurrencyByNameOrSymbol(string query, string limit)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}?limit={limit}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<AssetsResponse>(json);

                    var result = data.Data.FirstOrDefault(
                    currency => currency.Name.Equals(query, StringComparison.OrdinalIgnoreCase) ||
                                currency.Symbol.Equals(query, StringComparison.OrdinalIgnoreCase)
                    );

                    return result;
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

        public async Task<IEnumerable<MarketByCurrencyDTO>> GetMarketsByCurrency(string assetId, string limit)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}{assetId}/markets?limit={limit}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<MarketsByAssetIdResponse>(json);
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

