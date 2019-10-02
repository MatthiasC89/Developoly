using System;
using System.Collections.Generic;
using System.Text;
namespace Developoly.Client.Entities
{
    public class Dev
    {

        private int id;
        private string name;
        private List<Skill> skills;
        private int salary;
        private int hiringCost;
        private Company company;
        private Course course;
        private Project projet;


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Salary { get => salary; set => salary = value; }
        public Company Company { get => company; set => company = value; }
        public List<Skill> Skills { get => skills; set => skills = value; }
        public int HiringCost { get => hiringCost; set => hiringCost = value; }
        public Course Course { get => course; set => course = value; }
        public Project Projet { get => projet; set => projet = value; }

        public Dev()
        {

        }

        public Dev(int id, string name, int salary, int hiringCost)
        {
            Id = id;
            Name = name;
            Salary = salary;
            HiringCost = hiringCost;
            Course = null;
            Company = null;
            Projet = null;
            Skills = new List<Skill>();

        }



    }
}