using Newtonsoft.Json;

namespace WinFormsMA.Logic.Entities
{
    public class Stats
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("draws")]
        public List<Draw> Draws { get; set; }

        public Stats()
        {
            Draws = new List<Draw>();
        }
    }
}