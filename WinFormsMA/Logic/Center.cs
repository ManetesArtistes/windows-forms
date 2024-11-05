using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMA.Logic
{
    internal class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group[] Groups { get; set; }

        public Center() { }

        public Center(int id, string name, Group[] groups)
        {
            this.Id = id;
            this.Name = name;
            this.Groups = groups;
        }

    }
}
