
using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Entities
{
    public class Project
    {

        private int id;
        private int duration;
        int reward;
        private List<Skill> skills;
        private List<Dev> devs;
        private Company company;

        public int Id { get => id; set => id = value; }
        public int Duration { get => duration; set => duration = value; }
        public Company Company { get => company; set => company = value; }
        public List<Skill> Skills { get => skills; set => skills = value; }
        public List<Dev> Devs { get => devs; set => devs = value; }
        public int Reward { get => reward; set => reward = value; }

        public Project()
        {

        }
        public Project(int id, int duration, int reward)
        {
            Id = id;
            Duration = duration;
            Company = null;
            Reward = reward;
            Skills = new List<Skill>();
            Devs = new List<Dev>();
        }
    }
}