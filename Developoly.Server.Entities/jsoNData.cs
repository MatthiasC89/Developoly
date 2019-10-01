using Developoly.Server.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Server.Entities
{
    public class JsonData
    {
        private List<string> skillNames;
        private List<string> devNames;
        private List<string> schoolNames;


        public List<string> SkillNames { get => skillNames; set => skillNames = value; }
        public List<string> DevNames { get => devNames; set => devNames = value; }
        public List<string> SchoolNames { get => schoolNames; set => schoolNames = value; }

        public JsonData()
        {
            skillNames = new List<string>();
            devNames = new List<string>();
            schoolNames = new List<string>();
        }

        
    }
}
