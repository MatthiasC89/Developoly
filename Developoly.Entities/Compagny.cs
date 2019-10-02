using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Entities
{
    public class Compagny
    {
        private int id;
        private string name;
        private int money;
        private List<Dev> lesdevs;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Money { get => money; set => money = value; }
        public List<Dev> Lesdevs { get => lesdevs; set => lesdevs = value; }

        public Projet Projet
        {
            get => default;
            set
            {
            }
        }

        public Dev Dev
        {
            get => default;
            set
            {
            }
        }
    }
}