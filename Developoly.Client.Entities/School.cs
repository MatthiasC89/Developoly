using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Entities
{
    public class School
    {
        private int id;
        private string name;
        private List<Course> courses;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<Course> Courses { get => courses; set => courses = value; }

        public School()
        {

        }

        public School(int id, string name)
        {
            Id = id;
            Name = name;
            Courses = new List<Course>();
        }
    }
}
