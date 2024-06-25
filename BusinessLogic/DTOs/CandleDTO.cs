using Newtonsoft.Json;

namespace BusinessLogic.DTOs
{
    public class CandleDTO
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("close")]
        public decimal Close { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }
    }
}
