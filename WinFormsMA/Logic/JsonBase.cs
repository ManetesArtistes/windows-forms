using Newtonsoft.Json;

namespace WinFormsMA.Logic
{
    public class JsonBase
    {
        [JsonProperty("centers")]
        public List<Center> Centers { get; set; }

        public JsonBase()
        {
            Centers = new List<Center>();
        }
    }
}