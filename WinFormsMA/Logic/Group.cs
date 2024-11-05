using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMA.Logic
{
    internal class Group
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Student[] Students { get; set; }

        public Group() { }

        public Group(int id, string name, Student[] students)
        {
            this.Id = id;
            this.Name = name;
            this.Students = students;
        }
    
    }
}
