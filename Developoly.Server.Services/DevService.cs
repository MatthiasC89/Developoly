using Developoly.Server.Entities;
using Developoly.Server.Services.Entities;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace Developoly.Server.Services
{
    public partial class Service
    {

        public Dev CreateDev(string name)
        {
            if (Devs.Count == 0 || Devs.Count(d => d != null && d.Name == name) == 0)
            {
                Dev dev = new Dev(Devs.Count + 1, name, _salary, _hiringCost);
                dev.Skills = this.GenerateListOfSkill(SkillDevLevel);
                dev.HiringCost = HiringCost + (dev.Skills.Where(s => s.Level > SkillDevLevel).Sum(s => s.Level) * MultiHiring);
                dev.Salary = Salary + (dev.Skills.Sum(s => s.Level) * MultiSalary);
                return dev;
            }
            return null;
        }



        public List<Communication> AddDevToProject(Company company, Project project, List<Dev> devs)
        {
            List<Communication> alreadyBusy = CheckAvailability(devs);
            if (alreadyBusy == null && CompareSkills(project.Skills, SumSkills(devs)))
            {
                devs.ForEach(dev =>
                {
                    dev.Projet = project;
                    project.Devs.Add(dev);
                    // Initialize turn system
                });
                return new List<Communication>() { new Communication("MyDevToProjectSuccess", JsonConvert.SerializeObject(new DevToProject(project, devs), jsonSetting)), new Communication("HisDevToProjectSuccess", JsonConvert.SerializeObject(new DevToProject(project, devs), jsonSetting)) };
            }
            return alreadyBusy;
        }

        public void RemoveDevFromProject(Project project)
        {
            project.Devs.ForEach(d => d.Projet = null);
            project.Devs.RemoveRange(0, project.Devs.Count);
        }

        public List<Communication> AddDevToCourse(Company company, Course course, Dev dev)
        {
            List<Communication> alreadyBusy = CheckAvailability(dev);
            if (alreadyBusy == null)
            {
                dev.Course = course;
                course.Dev = dev;
                if (AlterMoney(company.Money, -(course.Price)) != null)
                {
                    company.Money = Convert.ToInt32(AlterMoney(company.Money, -(course.Price)));
                    return new List<Communication>() { new Communication("MyDevToCourseSuccess", JsonConvert.SerializeObject(new DevToCourse(course, dev), jsonSetting)), new Communication("HisDevToCourseSuccess", JsonConvert.SerializeObject(new DevToCourse(course, dev), jsonSetting)) };

                }
                // Initialize turn system and win at every turn level/duration
                return new List<Communication>() { new Communication("MyDevToCourseNotEnoughMoney", null) };
            }
            return alreadyBusy;
        }
        public void RemoveDevFromCourse(Dev dev)
        {
            var theCourse = dev.Course;
            dev.Skills.ForEach(devSkill =>
            dev.Course.Skills.ForEach(courseSkill =>
            { if (devSkill.Id == courseSkill.Id) { devSkill.Level += courseSkill.Level; } }
            )
            );
            dev.Course.Dev = null;
            dev.Course = null;
            dev.Skills.ForEach(s => { if (s.Level > 100) { s.Level = 100; } });


        }

        private List<Communication> CheckAvailability(List<Dev> devs)
        {
            List<Dev> devNotAvailable = devs.Where(dev => dev.Course != null || dev.Projet != null).ToList();
            if (devNotAvailable.Count > 0)
            {
                return new List<Communication>() { new Communication("MyDevsAlreadyBusy", JsonConvert.SerializeObject(devNotAvailable, jsonSetting)) };
            }
            return null;
        }

        private List<Communication> CheckAvailability(Dev dev)
        {
            if (dev.Course != null || dev.Projet != null)
            {
                return new List<Communication>() { new Communication("MyDevsAlreadyBusy", JsonConvert.SerializeObject(dev, jsonSetting)) };
            }
            return null;
        }

        public void PayDevSalary(int clientId)
        {
            this.Companies.Where(c => c.Id == clientId).First().Devs.ForEach(d =>d.Company.Money = (int)this.AlterMoney(d.Company.Money,d.Salary));
        }
    }
}
