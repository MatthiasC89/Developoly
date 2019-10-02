using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Entities
{
    public class Skill
    {
        private int id;
        private string name;
        private int level;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }

        public Dev Dev
        {
            get => default;
            set
            {
            }
        }
    }
}