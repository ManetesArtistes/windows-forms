using Newtonsoft.Json;
using WinFormsMA.Logic.Entities;

namespace WinFormsMA.Logic.Utilities
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