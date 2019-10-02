using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Entities
{
    public class Dev
    {
        private int id;
        private System.Collections.Generic.List<Developoly.Entities.Dev> skills;
        private string firstname;
        private string name;
        private int salary;

        public string Firstname { get => firstname; set => firstname = value; }
        public string Name { get => name; set => name = value; }
        public int Salary { get => salary; set => salary = value; }
        public int Id { get => id; set => id = value; }
        public List<Dev> Skills { get => skills; set => skills = value; }
    }
}