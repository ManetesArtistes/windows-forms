using Newtonsoft.Json;

namespace WinFormsMA.Logic.Entities
{
    public class Student
    {
        [JsonProperty("student_id")]
        public int Id { get; set; }

        [JsonProperty("student_name")]
        public string Name { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        public Student()
        {
            Stats = new Stats();
        }
    }
}