using Developoly.Client.Entities;
using Developoly.Client.Services;
using Developoly.Client.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Developoly.Client.UWP.Pages
{


    //
    //
    //
    //
    //
    // CHECK IF WITHOUT PATH ITS OK?
    // CHECK IF CONVERTER ITS OK ?
    //
    //
    //
    //

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page, GamePageInterface
    {
        private Frame _rootFrame;

        private Project _projectSelected;

        private General _general;
        General GamePageInterface.General { get => _general; set => _general = value; }

        private Service _service;

        public GamePage() { }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.InitializeComponent();
            this.DataContext = this;
            _general = (e.Parameter as List<Object>)[0] as General;
            _service = _general.Service as Service;
            _rootFrame = (e.Parameter as List<Object>)[1] as Frame;
            InitializeView();
        }


        private void InitializeView()
        {
            txtTurnOfCompany.Text = _general.MyCompany.Name.ToString();
            txtTurnOfCompany.Tag = _general.MyCompany;
            txtTurnOfCompanyMoney.Text = _general.MyCompany.Money.ToString();
            txtNumberOfTurn.Text = _general.NbTurnActual.ToString();
            txtNumberOfTurnMax.Text = _general.NbTurn.ToString();
            txtNumberOfPlayer.Text = _general.NbPlayerMax.ToString();
            listTheirCompany.ItemsSource = _general.TheirCompanys;
            CheckListEmptyCompany();
            listProjectAvailable.ItemsSource = _general.NewProjects;
            CheckListEmptyProject();
            listDevelopperAvailable.ItemsSource = _general.UnemployedDevs;
            CheckListEmptyDevelopper();
            listAddDev.ItemsSource = _general.MyCompany.Devs;
            CheckListEmptyAddDevelopper();
        }

        private void CheckListEmptyDevelopper()
        {
            if(listDevelopperAvailable.Items.Count == 0)
            {
                gridEmptyDevelopper.Visibility = Visibility.Visible;
            }
        }

        private void CheckListEmptyCompany()
        {
            if (listTheirCompany.Items.Count == 0) { 

                gridEmptyCompany.Visibility = Visibility.Visible;
            }
        }

        private void CheckListEmptyProject()
        {
            if (listProjectAvailable.Items.Count == 0)
            {
                gridEmptyProject.Visibility = Visibility.Visible;
            }
        }

        private void CheckListEmptyAddDevelopper()
        {
            if (listAddDev.Items.Count == 0)
            {
                gridEmptyAddDevelopper.Visibility = Visibility.Visible;
            }
        }

        private void Link_PointerOver(object sender, PointerRoutedEventArgs e)
        {
            (sender as TextBlock).Foreground = new SolidColorBrush((Color)Application.Current.Resources["CadetBlue"]);
        }

        private void Link_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            (sender as TextBlock).Foreground = new SolidColorBrush((Color)Application.Current.Resources["PayneGrey"]);
        }


        async void GamePageInterface.InitializePlayerPlayed(Object company)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                txtTurnOfCompany.Text = (company as Company).Name;
                txtTurnOfCompany.Tag = (company as Company);
                txtTurnOfCompanyMoney.Text = (company as Company).Money.ToString();
            });
        }


        private void Btn_newDev_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            Dev HiredDev = (Dev)_general.UnemployedDevs.Where(dev => dev.Id == (int)button.Tag);
            _service.SendData(new Communication("AddDevToCompany", JsonConvert.SerializeObject((Dev)HiredDev)));
        }


        //private void Btn_signUp_Click(object sender, RoutedEventArgs e)
        //{
        //    Button button = (Button)sender;

        //    if (devsSelected.Count == 1)
        //    {

        //        Course ChoosedCourse = (Course)_general.NewCourses.Where(course => course.Id == (int)button.Tag);
        //        DevToCourse devToCourse = new DevToCourse(ChoosedCourse, devsSelected.First());
        //        _service.SendData(new Communication("AddDevToCourse", JsonConvert.SerializeObject((DevToCourse)devToCourse)));
        //    }
        //    else
        //    {
        //        //Pop Up
        //    }

        //}

        //private void CheckBoxDev_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox checkBox = (CheckBox)sender;
        //    int intDev = (int)checkBox.Tag;

        //    devsSelected.Add((Dev)_general.MyDevs.Where(dev => dev.Id == intDev));

        //}

        //private void CheckBoxDev_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox checkBox = (CheckBox)sender;
        //    int intDev = (int)checkBox.Tag;
        //    devsSelected.Remove((Dev)_general.MyDevs.Where(dev => dev.Id == intDev));
        //}


        //private void SchoolCourses_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    List<Course> coursesEmpty = new List<Course>();
        //    lv_Courses.ItemsSource = coursesEmpty;

        //    lv_Courses.ItemsSource = ((School)e.ClickedItem).Courses;
        //}

        //private void SkillsInfo(List<Skill> skills)
        //{
        //    List<Skill> skillsEmpty = new List<Skill>();
        //    listViewSkills.ItemsSource = skillsEmpty;
        //    listViewSkills2.ItemsSource = skillsEmpty;
        //    listViewSkills3.ItemsSource = skillsEmpty;

        //    skills.RemoveRange(skills.Count() / 2, skills.Count() / 2);
        //    listViewSkills.ItemsSource = skills.Where(s => s.Id <= 3);
        //    listViewSkills2.ItemsSource = skills.Where(s => s.Id > 3 && s.Id <= 6);
        //    listViewSkills3.ItemsSource = skills.Where(s => s.Id > 6);
        //}

        //private void CourseSkills_ItemClick(object sender, ItemClickEventArgs e)
        //{

        //    SkillsInfo(((Course)e.ClickedItem).Skills);
        //}

        //private void ProjectSkills_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    SkillsInfo(((Project)e.ClickedItem).Skills);
        //}

        //private void DevSkills_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    SkillsInfo(((Dev)e.ClickedItem).Skills);
        //}

        public void MyTurnIsOver()
        {

            // A faire, mettre en pause
        }
        public void MyTurnBegins(int IdPlayer)
        {
            //A faire, enlever la pause
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

        private void LinkCompany_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(CompanyPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Company }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void LinkProject_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(ProjectPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Project }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void LinkDevelopper_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(DevelopperPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Dev }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void BtnNextTurn_Click(object sender, RoutedEventArgs e)
        {
            _service.SendData(new Communication("NextTurn", null));
            _general.NbTurnActual += 1;
        }

        private async void AddProjectToCompany_Click(object sender, RoutedEventArgs e)
        {

            await contentAddDev.ShowAsync();
            listAddDev.SelectedItem = null;
            _projectSelected = (sender as Button).Tag as Project;
        }

        private void contentAddDev_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            List<Dev> devSelected = new List<Dev>();
            if (listAddDev.SelectedItems != null)
            {
                devSelected.AddRange(listAddDev.SelectedItems as List<Dev>);
                _service.SendData(new Communication("AddProjectToCompany", JsonConvert.SerializeObject(new DevToProject(_projectSelected, devSelected), _service.jsonSetting)));
            }
        }

        private void AddDevToCompany_Click(object sender, RoutedEventArgs e)
        {
            _service.SendData(new Communication("AddDevToCompany", JsonConvert.SerializeObject((sender as Button).Tag as Dev, _service.jsonSetting)));
            //Method for check is possible in server
            //IF OK AddDevToCompany : Remove from DevUnemployed, AddDevToOtherCompany
        }

        async void GamePageInterface.MyDevelopperNotQualified(string DevsNotQualified)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                List<Dev> devs = JsonConvert.DeserializeObject<List<Dev>>(DevsNotQualified);
               //ERROR DEV NOT QUALIFIED
            });
        }

        async void GamePageInterface.MyProjectAddSuccess(string dTP)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                DevToProject devToProject = JsonConvert.DeserializeObject<DevToProject>(dTP, _service.jsonSetting);
                _general.NewProjects.Remove(devToProject.Project);
                _general.MyCompany.Projects.Add(devToProject.Project);
                //Pop Up + Update 
            });
        }

        async void GamePageInterface.TheirProjectsAddSuccess(string company)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Company companyChooseProject = (Company)JsonConvert.DeserializeObject(company, _service.jsonSetting);
                _general.NewProjects.Remove(companyChooseProject.Projects.Last());
                (_general.TheirCompanys.Where(c => c.Id == companyChooseProject.Id) as Company).Projects.Add(companyChooseProject.Projects.Last());
                //Update
            });
        }


        async void GamePageInterface.MyDevAddSuccess(string dev)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Dev hiredDev = (Dev)JsonConvert.DeserializeObject(dev,_service.jsonSetting);
                _general.UnemployedDevs.Remove(hiredDev);
                _general.MyCompany.Devs.Add(hiredDev);
                // Pop Up + Update
            });
        }

        async void GamePageInterface.HisDevAddSuccess(string company)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Company companyHiredDev = (Company)JsonConvert.DeserializeObject(company, _service.jsonSetting);
                _general.UnemployedDevs.Remove(companyHiredDev.Devs.Last());
                (_general.TheirCompanys.Where(c => c.Id == companyHiredDev.Id) as Company).Devs.Add(companyHiredDev.Devs.Last());
                // Update
            });
        }

    }
}
