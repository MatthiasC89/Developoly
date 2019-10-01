using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Server.Services.Entities
{
    public class Course
    {
        private int id;
        private int duration;
        private School school;
        private List<Skill> skills ;
        private Dev dev;
        private int price;

        public int Id { get => id; set => id = value; }
        public int Price { get => price; set => price = value; }
        public School School { get => school; set => school = value; }
        public List<Skill> Skills { get => skills; set => skills = value; }
        public int Duration { get => duration; set => duration = value; }
        public Dev Dev { get => dev; set => dev = value; }

        public Course()
        {

        }

        public Course(int id, School school,int price,int duration,Dev dev)
        {
            Id = id;
            School = school;
            Price = price;
            Duration = duration;            
            Skills = new List<Skill>();
            Dev = null;
        }
    }
}
