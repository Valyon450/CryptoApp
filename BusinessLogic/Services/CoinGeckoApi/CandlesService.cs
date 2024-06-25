using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CoinGeckoApi
{
    public class CandlesService : ICandlesService
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _baseUrl = "https://api.coingecko.com/api/v3/";

        public async Task<IEnumerable<CandleDTO>> GetCandles(string coinId, string vsCurrency, int days)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}coins/{coinId}/ohlc?vs_currency={vsCurrency}&days={days}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject < List < List<object> >> (json);

                    // Converting a List of Lists to a CandleDTO List
                    var candles = new List<CandleDTO>();
                    foreach (var item in data)
                    {
                        candles.Add(new CandleDTO
                        {
                            Time = Convert.ToInt64(item[0]),
                            Open = Convert.ToDecimal(item[1]),
                            High = Convert.ToDecimal(item[2]),
                            Low = Convert.ToDecimal(item[3]),
                            Close = Convert.ToDecimal(item[4])
                        });
                    }

                    return candles;
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
