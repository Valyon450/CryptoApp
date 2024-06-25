using Newtonsoft.Json;

namespace BusinessLogic.DTOs
{
    public class RateDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("rateUsd")]
        public decimal RateUsd { get; set; }
    }
}
