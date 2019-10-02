using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Entities
{
    public class Course
    {
        private int id;
        private int duration;
        private School school;
        private List<Skill> skills;
        private List<Dev> devs;
        private int price;

        public int Id { get => id; set => id = value; }
        public int Price { get => price; set => price = value; }
        public School School { get => school; set => school = value; }
        public List<Skill> Skills { get => skills; set => skills = value; }
        public int Duration { get => duration; set => duration = value; }
        public List<Dev> Devs { get => devs; set => devs = value; }

        public Course()
        {

        }

        public Course(int id, School school, int price, int duration)
        {
            Id = id;
            School = school;
            Price = price;
            Duration = duration;
            Skills = new List<Skill>();
            Devs = new List<Dev>();
        }
    }
}
