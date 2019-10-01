using System.Collections.Generic;

namespace Developoly.Server.Services.Entities
{
    public class Skill
    {
        private int id;
        private string name;
        private int level;
        private List<Course> courses;
        private List<Project> projects;
        private List<Dev> devs;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public List<Course> Courses { get => courses; set => courses = value; }
        public List<Project> Projects { get => projects; set => projects = value; }
        public List<Dev> Devs { get => devs; set => devs = value; }

        public Skill()
        {

        }

        public Skill(int id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
            //Courses = new List<Course>();
            //Projects = new List<Project>();
            //Devs = new List<Dev>();
        }
    }
}