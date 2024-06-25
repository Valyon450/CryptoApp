using BusinessLogic.DTOs;
using Newtonsoft.Json;

namespace BusinessLogic.Services.CoinCapApi.Responses
{
    public class AssetByIdResponse
    {
        [JsonProperty("data")]
        public CurrencyDTO Data { get; set; }
    }
}
