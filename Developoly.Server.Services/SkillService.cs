using Developoly.Server.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Developoly.Server.Services
{
    public partial class Service
    {

        public List<Skill> SumSkills(List<Dev> devs)
        {
            List<Skill> skills = new List<Skill>();
            if (devs.Count > 0)
            {
                if (devs.Count > 1)
                {
                    devs.First().Skills.ForEach(skillFirstDev =>
                    {
                        int valeurMax = 0;
                        devs.ForEach(developper => developper.Skills.Where(dS => dS.Id == skillFirstDev.Id && dS.Level >= valeurMax).ToList().ForEach(skillUp => valeurMax = skillUp.Level));
                        skills.Add(new Skill(skillFirstDev.Id, skillFirstDev.Name, valeurMax));
                    });
                } else
                {
                    return devs.First().Skills;
                }
            }
            
            return skills;
        }

        public List<Skill> GenerateListOfSkill(int minSkillValue)
        {
            List<Skill> theSkills = new List<Skill>();

            this.SkillsNames.ForEach(b => theSkills.Add(new Skill(theSkills.Count + 1, b, (random.Next(1, 100) < minSkillValue ? 0 : random.Next(minSkillValue, 100)))));
                //{
                //    Id = theSkills.Count + 1,
                //    Name = b,
                //    Level = (random.Next(1, 100) < minSkillValue ? 0 : random.Next(minSkillValue, 100))
                //}
                //));
            
            return theSkills;
        }

        public List<Skill> GenerateListOfSkillBlank()
        {
            List<Skill> theSkills = new List<Skill>();
            this.SkillsNames.ForEach(b => theSkills.Add(
                new Skill
                {
                    Id = theSkills.Count + 1,
                    Name = b,
                    Level = 0
                }
                ));
            return theSkills;
        }


        public List<Skill> generateOneSkill(List<Skill> skills, int idSkill)
        {
            skills.Where(s => s.Id == idSkill).First().Level = (random.Next(1, 100) < SkillDevLevel ? 0 : random.Next(SkillDevLevel, 100));
            return skills;
        }

        public bool CompareSkills(List<Skill> projectSkill, List<Skill> devSkill)
        {

            bool devQualified = true;
            if(devSkill.Where(developperS => developperS.Level < projectSkill.Where(project => project.Id == developperS.Id).FirstOrDefault().Level).ToList().Count >0)
            {
                devQualified = false;
            }
            return devQualified;

        }
    }
}
