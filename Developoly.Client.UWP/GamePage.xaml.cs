using Developoly.Client.Entities;
using Developoly.Client.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Developoly.Client.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page, GamePageInterface
    {
        private List<Dev> devsSelected;
        private General _general;
        General GamePageInterface.General { get => _general; set => _general = value; }
        private Service _service;

        public GamePage()
        {

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.InitializeComponent();
            _general = e.Parameter as General;
            _service = _general.Service as Service;
            txtCompName.Text = e.Parameter.ToString();
            txtMoney.Text = "10K";
            Skill skill = new Skill() { Id = 1, Name = "PHP", Level = 1 };
            Skill skill1 = new Skill() { Id = 2, Name = "CSS", Level = 20 };
            Dev dev = new Dev(1, "Girard", 1, 100);
            Dev dev2 = new Dev(2, "Royer", 1, 100);

            string stringJson = "{\"skills\":[{\"Id\":1,\"Name\":\"C#\",\"Level\":0,\"Courses\":null},{\"Id\":2,\"Name\":\"C++\",\"Level\":86,\"Courses\":null},{\"Id\":3,\"Name\":\"PHP\",\"Level\":73,\"Courses\":null},{\"Id\":4,\"Name\":\"JAVA\",\"Level\":53,\"Courses\":null},{\"Id\":5,\"Name\":\"RUBY\",\"Level\":44,\"Courses\":null},{\"Id\":6,\"Name\":\"PYTHON\",\"Level\":0,\"Courses\":null},{\"Id\":7,\"Name\":\"SQL\",\"Level\":32,\"Courses\":null},{\"Id\":8,\"Name\":\"C\",\"Level\":0,\"Courses\":null}],\"Id\":1,\"Name\":\"BOB\",\"Salary\":1596,\"Company\":null,\"Skills\":[{\"Id\":1,\"Name\":\"C#\",\"Level\":48,\"Courses\":null},{\"Id\":2,\"Name\":\"C++\",\"Level\":86,\"Courses\":null},{\"Id\":3,\"Name\":\"PHP\",\"Level\":73,\"Courses\":null},{\"Id\":4,\"Name\":\"JAVA\",\"Level\":53,\"Courses\":null},{\"Id\":5,\"Name\":\"RUBY\",\"Level\":44,\"Courses\":null},{\"Id\":6,\"Name\":\"PYTHON\",\"Level\":63,\"Courses\":null},{\"Id\":7,\"Name\":\"SQL\",\"Level\":32,\"Courses\":null},{\"Id\":8,\"Name\":\"C\",\"Level\":0,\"Courses\":null}],\"HiringCost\":2394,\"Course\":null,\"Projet\":null}";
            var deserializedJson = JsonConvert.DeserializeObject<Dev>(stringJson);
            dev = deserializedJson;
            string stringJson2 = "{\"skills\":[{\"Id\":1,\"Name\":\"C#\",\"Level\":70,\"Courses\":null},{\"Id\":2,\"Name\":\"C++\",\"Level\":0,\"Courses\":null},{\"Id\":3,\"Name\":\"PHP\",\"Level\":0,\"Courses\":null},{\"Id\":4,\"Name\":\"JAVA\",\"Level\":55,\"Courses\":null},{\"Id\":5,\"Name\":\"RUBY\",\"Level\":70,\"Courses\":null},{\"Id\":6,\"Name\":\"PYTHON\",\"Level\":40,\"Courses\":null},{\"Id\":7,\"Name\":\"SQL\",\"Level\":70,\"Courses\":null},{\"Id\":8,\"Name\":\"C\",\"Level\":55,\"Courses\":null}],\"Id\":1,\"Name\":\"ROGER\",\"Salary\":1596,\"Company\":null,\"Skills\":[{\"Id\":1,\"Name\":\"C#\",\"Level\":48,\"Courses\":null},{\"Id\":2,\"Name\":\"C++\",\"Level\":86,\"Courses\":null},{\"Id\":3,\"Name\":\"PHP\",\"Level\":73,\"Courses\":null},{\"Id\":4,\"Name\":\"JAVA\",\"Level\":53,\"Courses\":null},{\"Id\":5,\"Name\":\"RUBY\",\"Level\":44,\"Courses\":null},{\"Id\":6,\"Name\":\"PYTHON\",\"Level\":63,\"Courses\":null},{\"Id\":7,\"Name\":\"SQL\",\"Level\":32,\"Courses\":null},{\"Id\":8,\"Name\":\"C\",\"Level\":0,\"Courses\":null}],\"HiringCost\":2394,\"Course\":null,\"Projet\":null}";
            deserializedJson = JsonConvert.DeserializeObject<Dev>(stringJson2);
            dev2 = deserializedJson;


            //dev.Skills.Add(skill);
            Company compagny = new Company(1, "Player1", 10);
            Company compagny2 = new Company(2, "Player2", 10);
            List<Company> compagnies = new List<Company>();
            compagnies.Add(compagny);
            compagnies.Add(compagny2);
            Project projet = new Project(1, 12, 1200);
            projet.Skills.Add(skill);
            projet.Skills.Add(skill1);
            List<Project> projets = new List<Project>();
            projets.Add(projet);
            compagny.Devs.Add(dev);
            compagny.Devs.Add(dev2);
            School school = new School(1, "St be");
            Course course = new Course(1, school, 200, 6);
            Course course1 = new Course(2, school, 100, 5);
            school.Courses.Add(course);
            school.Courses.Add(course1);
            List<School> schools = new List<School>();
            schools.Add(school);
            course.Skills.Add(skill);
            course1.Skills.Add(skill1);
            MyDevListView.ItemsSource = compagny.Devs;
            NewDev.ItemsSource = compagny.Devs;
            NewProject.ItemsSource = projets;
            OtherCompDev.ItemsSource = compagny.Devs;
            School.ItemsSource = schools;
            devsSelected = new List<Dev>();
        }

        private void Next_Turn(object sender, RoutedEventArgs e)
        {
            _service.SendData(new Communication("NextTurn", null));
            numberOfTurn.Text = "1";
        }

        private void Btn_newDev_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = (Button)sender;
            Dev HiredDev = (Dev)_general.UnemployedDevs.Where(dev => dev.Id == (int)button.Tag);
            _service.SendData(new Communication("AddDevToCompany", JsonConvert.SerializeObject((Dev)HiredDev)));
        }
        private void Btn_newProjects_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = (Button)sender;
            Project ChoosedProject = (Project)_general.NewProjects.Where(project => project.Id == (int)button.Tag);
            _service.SendData(new Communication("AddProjectToCompany", JsonConvert.SerializeObject((Project)ChoosedProject)));
        }

        private void Btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (devsSelected.Count == 1)
            {
                
                Course ChoosedCourse = (Course)_general.NewCourses.Where(course => course.Id == (int)button.Tag);
                DevToCourse devToCourse = new DevToCourse(ChoosedCourse, devsSelected.First());
            _service.SendData(new Communication("AddDevToCourse", JsonConvert.SerializeObject((DevToCourse)devToCourse)));
            }
            else
            {
                //Pop Up
            }

        }

        private void CheckBoxDev_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int intDev = (int)checkBox.Tag;

            devsSelected.Add((Dev)_general.MyDevs.Where(dev => dev.Id == intDev));

        }

        private void CheckBoxDev_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int intDev = (int)checkBox.Tag;
            devsSelected.Remove((Dev)_general.MyDevs.Where(dev => dev.Id == intDev));
        }


        private void SchoolCourses_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Course> coursesEmpty = new List<Course>();
            lv_Courses.ItemsSource = coursesEmpty;

            lv_Courses.ItemsSource = ((School)e.ClickedItem).Courses;
        }

        private void SkillsInfo(List<Skill> skills)
        {
            List<Skill> skillsEmpty = new List<Skill>();
            listViewSkills.ItemsSource = skillsEmpty;
            listViewSkills2.ItemsSource = skillsEmpty;
            listViewSkills3.ItemsSource = skillsEmpty;

            skills.RemoveRange(skills.Count() / 2, skills.Count() / 2);
            listViewSkills.ItemsSource = skills.Where(s => s.Id <= 3);
            listViewSkills2.ItemsSource = skills.Where(s => s.Id > 3 && s.Id <= 6);
            listViewSkills3.ItemsSource = skills.Where(s => s.Id > 6);
        }

        private void CourseSkills_ItemClick(object sender, ItemClickEventArgs e)
        {

            SkillsInfo(((Course)e.ClickedItem).Skills);
        }

        private void ProjectSkills_ItemClick(object sender, ItemClickEventArgs e)
        {
            SkillsInfo(((Project)e.ClickedItem).Skills);
        }

        private void DevSkills_ItemClick(object sender, ItemClickEventArgs e)
        {
            SkillsInfo(((Dev)e.ClickedItem).Skills);
        }

        public void MyTurnIsOver()
        {

            // A faire, mettre en pause
        }
        public void MyTurnBegins(int IdPlayer)
        {
            //A faire, enlever la pause
        }
        public void MyDevAddSuccess(string dev)
        {
            Dev hiredDev = (Dev)JsonConvert.DeserializeObject(dev);
            _general.UnemployedDevs.Remove(hiredDev);
            _general.MyDevs.Add(hiredDev);
            // Pop Up + Update
        }
        public void HisDevAddSuccess(string dev)
        {
            Dev hiredDev = (Dev)JsonConvert.DeserializeObject(dev);
            _general.UnemployedDevs.Remove(hiredDev);
            // Update
        }

        public void MyProjectAddSuccess(string project)
        {

            Project choosedProject = (Project)JsonConvert.DeserializeObject(project);
            _general.NewProjects.Remove(choosedProject);
            _general.MyProjects.Add(choosedProject);
            //Pop Up + Update 
        }

        public void TheirProjectsAddSuccess(string project)
        {
            Project choosedProject = (Project)JsonConvert.DeserializeObject(project);
            _general.NewProjects.Remove(choosedProject);
            //Update
        }

        public void MyDevAddAlreadyExist()
        {
            // PopUp
        }
        public void MyDevAddNotEnoughMoney()
        {
            // PopUp
        }
        public void MyDevToCourseSuccess(string devAndCourse)
        {
            DevToCourse devToCourse = (DevToCourse)JsonConvert.DeserializeObject(devAndCourse);
            _general.NewCourses.Remove(devToCourse.Course);
            // Display info
        }
        public void HisDevToCourseSuccess(string devAndCourse)
        {
            DevToCourse devToCourse = (DevToCourse)JsonConvert.DeserializeObject(devAndCourse);
            _general.NewCourses.Remove(devToCourse.Course);
        }
        public void MyProjectAddAlreadyExist()
        {
            //PopUp
        }

        public void WinGame()
        {

        }

        public void ACompanyLost()
        {

        }

        public void GameOver()
        {

        }
    }
}
