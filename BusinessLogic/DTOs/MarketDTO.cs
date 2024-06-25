using Newtonsoft.Json;

namespace BusinessLogic.DTOs
{
    public class MarketDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("percentTotalVolume")]
        public decimal? PercentTotalVolume { get; set; }

        [JsonProperty("volumeUsd")]
        public decimal? VolumeUsd { get; set; }

        [JsonProperty("tradingPairs")]
        public int? TradingPairs { get; set; }

        [JsonProperty("socket")]
        public bool Socket { get; set; }

        [JsonProperty("exchangeUrl")]
        public string URL { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }
    }
}
