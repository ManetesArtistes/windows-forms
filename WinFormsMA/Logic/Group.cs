using Newtonsoft.Json;

namespace WinFormsMA.Logic
{
    public class Group
    {
        [JsonProperty("group_id")]
        public int Id { get; set; }

        [JsonProperty("group_name")]
        public string Name { get; set; }

        [JsonProperty("students")]
        public List<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}