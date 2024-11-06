using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMA.Logic
{
    internal class JsonBase
    {
        public class Center
        {
            public int CenterId { get; set; }
            public string CenterName { get; set; }
            public List<Group> Groups { get; set; }
        }

        public class Group
        {
            public int GroupId { get; set; }
            public string GroupName { get; set; }
            public List<Student> Students { get; set; }
        }

        public class Student
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public Stats Stats { get; set; }
        }

        public class Stats
        {
            public int Score { get; set; }
            public List<Draw> Draws { get; set; }
        }

        public class Draw
        {
            public int DrawId { get; set; }
            public string Timestamp { get; set; }
            public string Duration { get; set; }
            public List<int> UsedColors { get; set; }
            public int Accuracity { get; set; }
        }

        public class Root
        {
            public List<Center> Centers { get; set; }
        }
    }
}