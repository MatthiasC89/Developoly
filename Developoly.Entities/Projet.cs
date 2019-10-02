using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Entities
{
    public class Projet
    {
        private int id;
        private System.Collections.Generic.List<Developoly.Entities.Dev> skills;
        private int success;
        private int effectif;
        private int payement;

        public int Id { get => id; set => id = value; }
        public int Success { get => success; set => success = value; }
        public int Effectif { get => effectif; set => effectif = value; }
        public int Payement { get => payement; set => payement = value; }
        public List<Dev> Skills { get => skills; set => skills = value; }

        public Skill Skill
        {
            get => default;
            set
            {
            }
        }
    }
}