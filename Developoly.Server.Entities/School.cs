using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Server.Services.Entities
{
    public class School
    {
        private static int nextId = 1;

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

        public School(string name)
        {
            Id = School.nextId++;
            Name = name;
            Courses = new List<Course>();
        }
    }
}
