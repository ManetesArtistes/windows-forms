using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinFormsMA.Logic.Entities
{
    public class DrawImage
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("draw_colored_image")]
        public string image { get; set; }

        [JsonProperty("square_background_image")]
        public string background { get; set; }

        public DrawImage(){ }
    }
}
