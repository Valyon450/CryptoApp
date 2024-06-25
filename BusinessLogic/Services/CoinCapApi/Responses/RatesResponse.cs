using BusinessLogic.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusinessLogic.Services.CoinCapApi.Responses
{
    public class RatesResponse
    {
        [JsonProperty("data")]
        public IEnumerable<RateDTO> Data { get; set; }
    }
}
