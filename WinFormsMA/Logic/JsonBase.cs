using Newtonsoft.Json;

namespace WinFormsMA.Logic
{
    public class JsonBase
    {
        public class Center
        {
            [JsonProperty("center_id")]
            public int CenterId { get; set; }

            [JsonProperty("center_name")]
            public string CenterName { get; set; }
            public List<Group> Groups { get; set; }
        }

        public class Group
        {
            [JsonProperty("group_id")]
            public int GroupId { get; set; }

            [JsonProperty("group_name")]
            public string GroupName { get; set; }
            public List<Student> Students { get; set; }
        }

        public class Student
        {
            [JsonProperty("student_id")]
            public int StudentId { get; set; }

            [JsonProperty("student_name")]
            public string StudentName { get; set; }
            public Stats Stats { get; set; }
        }

        public class Stats
        {
            [JsonProperty("score")]
            public int Score { get; set; }

            [JsonProperty("draws")]
            public List<Draw> Draws { get; set; }
        }

        public class Draw
        {
            [JsonProperty("draw_id")]
            public int DrawId { get; set; }

            [JsonProperty("timestamp")]
            public string Timestamp { get; set; }

            [JsonProperty("duration")]
            public string Duration { get; set; }

            [JsonProperty("usedColors")]
            public List<int> UsedColors { get; set; }

            [JsonProperty("accuracity")]
            public int Accuracity { get; set; }
        }

        public class Root
        {
            public List<Center> Centers { get; set; }
        }
    }
}