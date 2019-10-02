using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Entities
{
    public class Company
    {
        private int id;
        private string name;
        private int money;
        private List<Dev> devs;
        private List<Project> projects;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Money { get => money; set => money = value; }
        public List<Dev> Devs { get => devs; set => devs = value; }
        public List<Project> Projects { get => projects; set => projects = value; }

        public Company()
        {


        }

        public Company(int id, string name, int money)
        {
            Id = id;
            Name = name;
            Money = money;
            Devs = new List<Dev>();
            Projects = new List<Project>();
        }

    }
}