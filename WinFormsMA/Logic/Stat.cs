using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMA.Logic
{
    internal class Stat
    {
        public int Score {  get; set; }
        public Draw[] Draws { get; set; }

        public Stat() { }

        public Stat(int score, Draw[] draws)
        {
            this.Score = score;
            this.Draws = draws;
        }
    }
}
