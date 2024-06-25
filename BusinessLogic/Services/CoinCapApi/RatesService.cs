using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Services.CoinCapApi.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CoinCapApi
{
    public class RatesService : IRatesService
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _baseUrl = "https://api.coincap.io/v2/rates";

        public async Task<IEnumerable<RateDTO>> GetCurrencyRatesAsync()
        {
            try
            {
                var response = await _client.GetAsync(_baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<RatesResponse>(json);
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
