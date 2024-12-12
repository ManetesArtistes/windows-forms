using Newtonsoft.Json;

namespace WinFormsMA.Logic.Entities
{
    public class Center
    {
        [JsonProperty("center_id")]
        public int Id { get; set; }

        [JsonProperty("center_name")]
        public string Name { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        public Center()
        {
            Groups = new List<Group>();
        }
    }
}