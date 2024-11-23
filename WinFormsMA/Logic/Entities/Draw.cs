using Newtonsoft.Json;

namespace WinFormsMA.Logic.Entities
{
    public class Draw
    {
        [JsonProperty("draw_id")]
        public int Id { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("usedColors")]
        public List<int> UsedColors { get; set; }

        [JsonProperty("accuracity")]
        public int Accuracity { get; set; }
    }
}