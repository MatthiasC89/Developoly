
using Developoly.Server.Services.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Developoly.Server.Services;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Developoly.Server.Entities;

namespace Developoly.Server.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
         Service service = new Service();
        
        [TestMethod]
        public void TestMethodTurn()
        {
               
            service.StartGame();
            Company company = new Company(1, "testName", 5000);
            Dev dev1 = new Dev(1, "Damien MILLOT", service.Salary, service.HiringCost); 
            dev1.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 50, true), new Skill(2, "PHP", 50, true), new Skill(3, "SQL", 50, true), new Skill(4, "RUBY", 50, true), new Skill(5, "PYTHON", 50, true), new Skill(6, "JS", 50, true), new Skill(7, "CSS", 50, true), new Skill(8, "SWIFT", 50, true) });
            Dev dev2 = new Dev(2, "Nathan GAGNIARRE", service.Salary, service.HiringCost);
            dev2.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 99, true), new Skill(2, "PHP", 99, true), new Skill(3, "SQL", 99, true), new Skill(4, "RUBY", 99, true), new Skill(5, "PYTHON", 99, true), new Skill(6, "JS", 99, true), new Skill(7, "CSS", 99, true), new Skill(8, "SWIFT", 99, true) });
            Dev dev3 = new Dev(3, "Bob BOBBER", service.Salary, service.HiringCost);
            dev3.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 99, true), new Skill(2, "PHP", 99, true), new Skill(3, "SQL", 99, true), new Skill(4, "RUBY", 99, true), new Skill(5, "PYTHON", 99, true), new Skill(6, "JS", 99, true), new Skill(7, "CSS", 99, true), new Skill(8, "SWIFT", 99, true) });
            List<Dev> devs = new List<Dev>() { dev1, dev2 };
            service.Skills = new List<Skill>() { new Skill(1, "C#", 99, true), new Skill(2, "PHP", 99, true), new Skill(3, "SQL", 99, true), new Skill(4, "RUBY", 99, true), new Skill(5, "PYTHON", 99, true), new Skill(6, "JS", 99, true), new Skill(7, "CSS", 99, true), new Skill(8, "SWIFT", 99, true) };

            List<Skill> skills = service.SumSkills(devs);
            company.Devs.Add(dev1);
            company.Devs.Add(dev2);
            company.Devs.Add(dev3);
            company.Devs.ForEach(d => d.Company = company);
            company.Projects = service.CreateProject(6);
            service.Companies.Add(company);
            School school = new School(1, "testName");
            Skill skillCourse = service.generateOneSkill(service.generateListOfSkillBlank(),4);
            Course course = new Course() { Id = 1, Duration = 3, Price = 100, School = school, Skill = skillCourse, Dev = null };
            school.Courses.Add(course);
            service.AddDevToCourse(company,course,dev1);
            
            company.Projects.First().Duration = 1; //this project end 

            dev2.Projet = company.Projects.First();
            dev3.Projet = company.Projects.First();
        

            List<Dev> devsListForProject = new List<Dev> {dev2,dev3};//add both dev to the project in AddDevToProject, 
            service.AddDevToProject(company, company.Projects.First(), devsListForProject);
            service.BeginTurn(1);//1 = client id
            

        }
        [TestMethod]
        public void TestMethodStartCourse()
        {
            #region InitializeTest
           

            service.StartGame();

            #endregion

        }
       

        [TestMethod]
        public void TestMethodCompany()
        {
            #region InitializeTest

            service.StartGame();
            Company company = new Company(4, "testName", 200);

            #endregion

            #region CreationCompanyTest

            List<Communication> addCompanySuccessExpected = new List<Communication>() { new Communication("MyCompanyAddSuccess", JsonConvert.SerializeObject(company, service.jsonSetting)), new Communication("HisCompanyAddSuccess", JsonConvert.SerializeObject(company, service.jsonSetting)) };
            List<Communication> addCompanySuccessActual = service.CreateCompany("testName", 4);
            Assert.AreEqual(addCompanySuccessExpected[0].Data, addCompanySuccessActual[0].Data);
            Assert.AreEqual(addCompanySuccessExpected[0].Action, addCompanySuccessActual[0].Action);

            Assert.AreEqual(addCompanySuccessExpected[1].Data, addCompanySuccessActual[1].Data);
            Assert.AreEqual(addCompanySuccessExpected[1].Action, addCompanySuccessActual[1].Action);

            List<Communication> addCompanyAlreadyExistExpected = new List<Communication>() { new Communication("MyCompanyAlreadyExist", null) };
            List<Communication> addCompanyAlreadyExistActual = service.CreateCompany("testName", 4);
            Assert.AreEqual(addCompanyAlreadyExistExpected[0].Action, addCompanyAlreadyExistActual[0].Action);
            Assert.AreEqual(addCompanyAlreadyExistExpected[0].Data, addCompanyAlreadyExistActual[0].Data);

            #endregion

            #region ManagementMoney
            
            Assert.AreEqual(100, service.AlterMoney(200, -100, company));
            Assert.AreEqual(300, service.AlterMoney(200, 100, company));

            #endregion

            #region AddDevToCompany

            Dev dev = new Dev(1, "Damien MILLOT", 2000, 0);
            dev.Company = company;
            List<Communication> addDevToCompanySuccessExpected = new List<Communication>() { new Communication("MyDevAddSuccess", JsonConvert.SerializeObject(dev, service.jsonSetting)), new Communication("HisDevAddSuccess", JsonConvert.SerializeObject(dev, service.jsonSetting)) };
            dev.Company = null;
            List<Communication> addDevToCompanySuccessActual = service.AddDevToCompany(company,dev);
            Assert.AreEqual(addDevToCompanySuccessExpected[0].Data, addDevToCompanySuccessActual[0].Data);
            Assert.AreEqual(addDevToCompanySuccessExpected[0].Action, addDevToCompanySuccessActual[0].Action);

            Assert.AreEqual(addDevToCompanySuccessExpected[1].Data, addDevToCompanySuccessActual[1].Data);
            Assert.AreEqual(addDevToCompanySuccessExpected[1].Action, addDevToCompanySuccessActual[1].Action);

            List<Communication> addDevToCompanyFailedExpected = new List<Communication>() { new Communication("MyDevAddAlreadyExist", null)};
            List<Communication> addDevToCompanyFailedActual = service.AddDevToCompany(company, dev);
            Assert.AreEqual(addDevToCompanyFailedExpected[0].Data, addDevToCompanyFailedActual[0].Data);
            Assert.AreEqual(addDevToCompanyFailedExpected[0].Action, addDevToCompanyFailedActual[0].Action);

            #endregion

            //#region AddProjectToCompany

            //Project project = new Project(1, 3, 1200);
            //project.Company = company;
            //List<Communication> addProjectToCompanySuccessExpected = new List<Communication>() { new Communication("MyProjectAddSuccess", JsonConvert.SerializeObject(project, service.jsonSetting)), new Communication("HisProjectAddSuccess", JsonConvert.SerializeObject(project, service.jsonSetting)) };
            //project.Company = null;
            //List<Communication> addProjectToCompanySuccessActual = service.AddProjectToCompany(company, project);
            //Assert.AreEqual(addProjectToCompanySuccessExpected[0].Data, addProjectToCompanySuccessActual[0].Data);
            //Assert.AreEqual(addProjectToCompanySuccessExpected[0].Action, addProjectToCompanySuccessActual[0].Action);

            //Assert.AreEqual(addProjectToCompanySuccessExpected[1].Data, addProjectToCompanySuccessActual[1].Data);
            //Assert.AreEqual(addProjectToCompanySuccessExpected[1].Action, addProjectToCompanySuccessActual[1].Action);

            //List<Communication> addProjectToCompanyFailedExpected = new List<Communication>() { new Communication("MyProjectAddAlreadyExist", null) };
            //List<Communication> addProjectToCompanyFailedActual = service.AddProjectToCompany(company, project);
            //Assert.AreEqual(addProjectToCompanyFailedExpected[0].Data, addProjectToCompanyFailedActual[0].Data);
            //Assert.AreEqual(addProjectToCompanyFailedExpected[0].Action, addProjectToCompanyFailedActual[0].Action);

            //#endregion

        }

        [TestMethod]
        public void TestMethodSchool()
        {
            #region InitializeTest

            service.StartGame();

            #endregion

            #region CreationSchoolTest

            School addSchoolSuccessActual = service.CreateNewSchool("testName");
            service.Schools.Add(addSchoolSuccessActual);
            Assert.AreEqual(7, addSchoolSuccessActual.Id);
            Assert.AreEqual("testName", addSchoolSuccessActual.Name);
            School addSchoolFailedActual = service.CreateNewSchool("testName");
            Assert.AreEqual(null, addSchoolFailedActual);

            #endregion


        }

        [TestMethod]
        public void TestMethodCourse()
        {
            #region InitializeTest

            service.StartGame();
            School school = new School(1, "testName");

            #endregion

            #region CreationCourseTest

            List<Course> addCourseSuccessActual = service.CreateCourse(school);
            Assert.AreEqual(1, addCourseSuccessActual[0].Id);
            Assert.AreEqual(school.Id, addCourseSuccessActual[0].School.Id);

            #endregion

        }


        [TestMethod]
        public void TestMethodProject()
        {
            #region InitializeTest

            service.StartGame();

            #endregion

            #region CreationProjectTest
            List<Project> addProjectSuccessActual = service.CreateProject(6);
            Assert.AreEqual(1, addProjectSuccessActual[0].Id);
            Assert.AreEqual(2, addProjectSuccessActual[1].Id);
            #endregion

        }

        [TestMethod]
        public void TestMethodDev()
        {
            #region InitializeTest

            service.StartGame();
            Company company = new Company(4, "testName", 200);
            Project project = new Project(1, 3, 1200);
            project.Skills = new List<Skill>() { new Skill(1, "C#", 50,true), new Skill(2, "PHP", 60, true) };
            Dev dev1 = new Dev(1, "Damien MILLOT", service.Salary, service.HiringCost);
            dev1.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 70, true), new Skill(2, "PHP", 20, true) });
            Dev dev2 = new Dev(2, "Nathan GAGNIARRE", service.Salary, service.HiringCost);
            dev2.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 50, true), new Skill(2, "PHP", 80, true) });
            List<Dev> devs = new List<Dev>() { dev1, dev2 };

            School school = new School(1, "testName");
            
            Course course = new Course(1, school, 20, 2);
            //Skill skill =new Skill(2, "PHP", 60) ;
            //course.Skill = skill;

            #endregion

            #region CreationDevTest
            Dev addDevSuccessActual = service.CreateDev("Kim DOLE");
            Assert.AreEqual(32, addDevSuccessActual.Id);
            Assert.AreEqual("Kim DOLE", addDevSuccessActual.Name);
            Dev addDevFailedActual = service.CreateDev("GEOFFREY"); 
            Assert.AreEqual(null, addDevFailedActual);
            #endregion

            #region DevToProject
            List<Communication> addDevToProjectSuccess = service.AddDevToProject(company, project, devs);
            Assert.AreEqual("MyDevToProjectSuccess", addDevToProjectSuccess[0].Action);
            List<Communication> addDevToProjectFailed = service.AddDevToProject(company, project, devs);
            Assert.AreEqual("MyDevsAlreadyBusy", addDevToProjectFailed[0].Action);
            #endregion

            #region DevToCourse

            dev1 = new Dev(1, "Damien MILLOT", service.Salary, service.HiringCost);
            dev1.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 70, true), new Skill(2, "PHP", 20, true) });
            List<Communication> addDevToCourseSuccess = service.AddDevToCourse(company, course, dev1);
            Assert.AreEqual("MyDevToCourseSuccess", addDevToCourseSuccess[0].Action);
            List<Communication> addDevToCourseFailed = service.AddDevToCourse(company, course, dev1);
            Assert.AreEqual("MyDevsAlreadyBusy", addDevToProjectFailed[0].Action);
            #endregion

        }

        [TestMethod]
        public void TestMethodSkill()
        {
            #region InitializeTest

            service.StartGame();

            #endregion

            #region SumSkill

            Dev dev1 = new Dev(1, "Damien MILLOT", service.Salary, service.HiringCost);
            dev1.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 70, true), new Skill(2, "PHP", 20, true) });
            Dev dev2 = new Dev(2, "Nathan GAGNIARRE", service.Salary, service.HiringCost);
            dev2.Skills.AddRange(new List<Skill>() { new Skill(1, "C#", 50, true), new Skill(2, "PHP", 80, true) });
            List<Dev> devs = new List<Dev>() { dev1, dev2 };
            service.Skills = new List<Skill>() { new Skill(1, "C#", 0, true), new Skill(2, "PHP", 0, true) };
            List<Skill> skills = service.SumSkills(devs);
            Assert.AreEqual(70, skills[0].Level);
            Assert.AreEqual(80, skills[1].Level);
            #endregion

            #region CompareSkill
            List<Skill> skillProject = new List<Skill>() { new Skill(1, "C#", 50, true), new Skill(2, "PHP", 10, true) };
            Assert.AreEqual(true, service.CompareSkills(skillProject, skills));
            skillProject = new List<Skill>() { new Skill(1, "C#", 80, true), new Skill(2, "PHP", 10, true) };
            Assert.AreEqual(false, service.CompareSkills(skillProject, skills));
            #endregion

        }

        

    }
}
