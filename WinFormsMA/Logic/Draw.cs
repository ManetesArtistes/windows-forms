using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMA.Logic
{
    internal class Draw
    {

        public int Id { get; set; }
        public string Timestamp { get; set; }
        public string Duration { get; set; }
        public int[] UsedColors { get; set; }
        public int Accuracity { get; set; }

        public Draw() { }

        public Draw(int id, string timestamp, string duration, int[] usedColors, int accuracity)
        {
            this.Id = id;
            this.Timestamp = timestamp; 
            this.Duration = duration;
            this.UsedColors = usedColors;
            this.Accuracity = accuracity;
        }
    }
}
