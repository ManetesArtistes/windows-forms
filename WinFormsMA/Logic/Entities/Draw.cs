using Newtonsoft.Json;

namespace WinFormsMA.Logic.Entities
{
    public class Draw
    {
        [JsonProperty("draw_id")]
        public int Id { get; set; }

        [JsonProperty("durationSeconds")]
        public int Duration { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("usedColorsAmount")]
        public int UsedColors { get; set; }
    }
}