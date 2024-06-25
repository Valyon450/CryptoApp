using BusinessLogic.DTOs;
using Newtonsoft.Json;

namespace BusinessLogic.Services.CoinCapApi.Responses
{
    public class ExchangeByIdResponse
    {
        [JsonProperty("data")]
        public MarketDTO Data { get; set; }
    }
}
