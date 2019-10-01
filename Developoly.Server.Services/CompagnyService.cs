using Developoly.Server.Entities;
using Developoly.Server.Services.Entities;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Developoly.Server.Services
{
    public partial class Service
    {
        public List<Communication> CreateCompany(string name, int clientID)
        {
            if (Companies.Count(company => company.Name == name) == 0)
            {  
                Company company = new Company(clientID, name, Money);
                Companies.Add(company);
                General generalClient = new General(company, StartGeneral.UnemployedDevs, StartGeneral.NewProjects, StartGeneral.Schools, Clients.Count, NumberPlayer, Money, NumberTurn);
                return new List<Communication>() { new Communication("MyCompanyAddSuccess", JsonConvert.SerializeObject(generalClient, jsonSetting)), new Communication("AddNewPlayerSuccess", Clients.Count.ToString()) };            
            }
            return new List<Communication>() { new Communication("MyCompanyAlreadyExist", null) };

        }

        public List<Communication> AddDevToCompany(Company company, Dev dev)
        {
            if(dev.Company == null)
            {
                dev.Company = company;
                company.Devs.Add(dev);
                if(AlterMoney(company.Money, -(dev.HiringCost)) != null)
                {
                    company.Money = Convert.ToInt32(AlterMoney(company.Money, -(dev.HiringCost)));
                    return new List<Communication>() { new Communication("MyDevAddSuccess", JsonConvert.SerializeObject(dev, jsonSetting)), new Communication("HisDevAddSuccess", JsonConvert.SerializeObject(dev, jsonSetting)) };
                }
                return new List<Communication>() { new Communication("MyDevAddNotEnoughMoney", null) };

            }
            return new List<Communication>() { new Communication("MyDevAddAlreadyExist", null) };

        }



        public List<Communication> AddProjectToCompany(Company company, Project project)
        {
            if (project.Company == null)
            {
                project.Company = company;
                company.Projects.Add(project);
                return new List<Communication>() { new Communication("MyProjectAddSuccess", JsonConvert.SerializeObject(project, jsonSetting)),
                new Communication("TheirProjectsAddSuccess", JsonConvert.SerializeObject(project, jsonSetting)) };
            }
            return new List<Communication>() { new Communication("MyProjectAddAlreadyExist", null) };
        }



        public int? AlterMoney(int moneyCompany, int moneyLessOrMore)
        {
            if (moneyCompany + moneyLessOrMore >= LooseParameter)
            {               
                if (moneyCompany >= WinParameter)
                {
                    return WinParameter;
                }
                return moneyCompany += moneyLessOrMore;
            }
            else
            {
                return LooseParameter;
            }
        }

    }
}
