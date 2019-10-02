using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Developoly.Client.Entities;
using Developoly.Client.Services;
using Developoly.Client.Services.Interfaces;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Developoly.Client.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DevelopperPage : Page, DevelopperPageInterface
    {
        private Frame _rootFrame;

        private Dev _dev;

        private General _general;
        General DevelopperPageInterface.General { get => _general; set => _general = value; }

        private Service _service;

        public DevelopperPage() { }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.InitializeComponent();
            _general = (e.Parameter as List<Object>)[0] as General;
            _service = _general.Service as Service;
            _rootFrame = (e.Parameter as List<Object>)[1] as Frame;
            _dev = (e.Parameter as List<Object>)[2] as Dev;
            InitializeDevelopper();
        }

        private void InitializeDevelopper()
        {
            txtNameOfDevelopper.Text = _dev.Name;
            txtSalary.Text = _dev.Salary.ToString();
            txtHiring.Text = _dev.HiringCost.ToString();
            if (_dev.Company != null)
            {
                txtCompanyAffected.Text = _dev.Company.Name;
                txtCompanyAffected.Tag = _dev.Company;
            }
            else
            {
                txtCompanyAffected.Text = "Available";
            }
            List<Project> oneProject = new List<Project>();
            if(_dev.Projet != null)
            {
                oneProject.Add(_dev.Projet);
            }
            listProjectAffected.ItemsSource = oneProject;
            CheckListEmptyProjectAffected();
            List<Course> oneCourse = new List<Course>();
            if (_dev.Course != null)
            {
                oneCourse.Add(_dev.Course);
            }
            listCourseAffected.ItemsSource = oneCourse;
            CheckListEmptyCourseAffected();
            AffectSkills();
        }

        private void AffectSkills()
        {
            txtLevelC.Text = _dev.Skills[0].Level.ToString();
            txtLevelPHP.Text = _dev.Skills[1].Level.ToString();
            txtLevelSQL.Text = _dev.Skills[2].Level.ToString();
            txtLevelRUBY.Text = _dev.Skills[3].Level.ToString();
            txtLevelPYTHON.Text = _dev.Skills[4].Level.ToString();
            txtLevelJS.Text = _dev.Skills[5].Level.ToString();
            txtLevelCSS.Text = _dev.Skills[6].Level.ToString();
            txtLevelSWIFT.Text = _dev.Skills[7].Level.ToString();
            txtLevelDetermination.Text = _dev.Skills[8].Level.ToString();
            txtLevelMorale.Text = _dev.Skills[9].Level.ToString();
            txtLevelPatience.Text = _dev.Skills[10].Level.ToString();
            txtLevelConcentration.Text = _dev.Skills[11].Level.ToString();
            txtLevelLeadership.Text = _dev.Skills[12].Level.ToString();
            txtLevelTeamwork.Text = _dev.Skills[13].Level.ToString();
        }

        private void CheckListEmptyProjectAffected()
        {
            if (listProjectAffected.Items.Count == 0)
            {
                gridEmptyProjectAffected.Visibility = Visibility.Visible;
            }
        }

        private void CheckListEmptyCourseAffected()
        {
            if (listCourseAffected.Items.Count == 0)
            {
                gridEmptyCourseAffected.Visibility = Visibility.Visible;
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

        private void LinkProject_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(ProjectPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Project }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });

        }

        private void LinkSchool_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        private void LinkCompany_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(CompanyPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Company }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });

        }
    }
}
