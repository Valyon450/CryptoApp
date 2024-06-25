using BusinessLogic.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusinessLogic.Services.CoinCapApi.Responses
{
    public class MarketsByAssetIdResponse
    {
        [JsonProperty("data")]
        public IEnumerable<MarketByCurrencyDTO> Data { get; set; }
    }
}
