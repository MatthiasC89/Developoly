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
using Newtonsoft.Json;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Developoly.Client.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProjectPage : Page, ProjectPageInterface
    {
        private Frame _rootFrame;

        private Project _project;

        private General _general;
        General ProjectPageInterface.General { get => _general; set => _general = value; }

        private Service _service;


        public ProjectPage() { }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.InitializeComponent();
            _general = (e.Parameter as List<Object>)[0] as General;
            _service = _general.Service as Service;
            _rootFrame = (e.Parameter as List<Object>)[1] as Frame;
            _project = (e.Parameter as List<Object>)[2] as Project;
            InitializeProject();
        }

        private void InitializeProject()
        {
            txtNameOfProject.Text = _project.Id.ToString();
            txtRewardOfProject.Text = _project.Reward.ToString();
            txtDurationProject.Text = _project.Duration.ToString();
            if (_project.Company != null)
            {
                txtCompanyAffected.Text = _project.Company.Name;
                txtCompanyAffected.Tag = _project.Company;
            } else
            {
                txtCompanyAffected.Text = "Available";
            }
            listDevelopperAffected.ItemsSource = _project.Devs;
            CheckListEmptyDevAffected();
            listAddDevToProject.ItemsSource = _general.MyCompany.Devs.Where(dev => dev.Projet == null && dev.Course == null).ToList();
            CheckListEmptyDevAvailable();
            AffectSkills();
        }

        private void AffectSkills()
        {
            txtLevelC.Text = _project.Skills[0].Level.ToString();
            txtLevelPHP.Text = _project.Skills[1].Level.ToString();
            txtLevelSQL.Text = _project.Skills[2].Level.ToString();
            txtLevelRUBY.Text = _project.Skills[3].Level.ToString();
            txtLevelPYTHON.Text = _project.Skills[4].Level.ToString();
            txtLevelJS.Text = _project.Skills[5].Level.ToString();
            txtLevelCSS.Text = _project.Skills[6].Level.ToString();
            txtLevelSWIFT.Text = _project.Skills[7].Level.ToString();

        }


        private void CheckListEmptyDevAffected()
        {
            if (listDevelopperAffected.Items.Count == 0)
            {
                gridEmptyDevAffected.Visibility = Visibility.Visible;
            }
        }

        private void CheckListEmptyDevAvailable()
        {
            if (listAddDevToProject.Items.Count == 0)
            {
                gridEmptyDevAvailable.Visibility = Visibility.Visible;
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

        private void LinkCompany_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(CompanyPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Company }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });

        }

        private void LinkDevelopper_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(DevelopperPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Dev }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void AddDevToCompany_Click(object sender, RoutedEventArgs e)
        {
            List<Dev> devSelected = new List<Dev>();
            if (listAddDevToProject.SelectedItems != null)
            {
                devSelected.AddRange(listAddDevToProject.SelectedItems as List<Dev>);
                _service.SendData(new Communication("AddProjectToCompany", JsonConvert.SerializeObject(new DevToProject(_project, devSelected), _service.jsonSetting)));
            }
        }
    }
}
