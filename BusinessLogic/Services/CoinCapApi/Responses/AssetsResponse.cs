using BusinessLogic.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusinessLogic.Services.CoinCapApi.Responses
{
    public class AssetsResponse
    {
        [JsonProperty("data")]
        public IEnumerable<CurrencyDTO> Data { get; set; }
    }
}
