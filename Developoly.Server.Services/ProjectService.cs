using Developoly.Server.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Developoly.Server.Services
{
    public partial class Service
    {

        public List<Project> CreateProject(int quantity)
        {
            List<Project> projects = new List<Project>();
            while (quantity > 0)//try to use linq instead of while...?
            {
                List<Skill> skillProjet = this.GenerateListOfSkill(SkillProjectLevel);
                //projects.Add(new Project
                //{
                //    Id = projects.Count + 1,
                //    Skills = skillProjet,
                //    Reward = skillProjet.Sum(s => s.Level) * RewardProject,
                //    Duration = random.Next(DurationMinimumTurnProject, DurationMaximumTurnProject)

                //});
                projects.Add(new Project(projects.Count + 1, random.Next(DurationMinimumTurnProject, DurationMaximumTurnProject), skillProjet.Sum(s => s.Level) * RewardProject, skillProjet));
                quantity--;
            }
            return projects;
        }

        public void ReduceProjectTurnCounter(int clientId)
        {


            this.Companies.Where(c => c.Id == clientId).First().Projects.ForEach(p => p.Duration--);
            //return this.Companies.Where(c => c.Id == clientId).Select(c => c.Projects).Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        public void EarnCompleteProjectReward(int clientId)
        {

            this.Companies.Where(c => c.Id == clientId).First().Money += this.Companies.Where(c => c.Id == clientId).First().Projects.Where(p => p.Duration == 0).Sum(p => p.Reward);

        }

        /// <summary>
        ///  set the Project value of each participating dev to null , delete the project from the company's list of project
        /// </summary>
        /// <param name="clientId"></param>
        public void RecoverDevFromProject(int clientId)
        {
            var proj = this.Companies.Where(c => c.Id == clientId).First().Projects;
            proj.Where(p => p.Duration == 0).ToList().ForEach(p => RemoveDevFromProject(p));
            proj.RemoveAll(p => p.Duration == 0);
        }
    }
}
