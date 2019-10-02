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
    public sealed partial class CompanyPage : Page, CompanyPageInterface
    {
        private Frame _rootFrame;

        private Company _company;

        private General _general;
        General CompanyPageInterface.General { get => _general; set => _general = value; }

        private Service _service;


        public CompanyPage() { }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.InitializeComponent();
            _general = (e.Parameter as List<Object>)[0] as General;
            _service = _general.Service as Service;
            _rootFrame = (e.Parameter as List<Object>)[1] as Frame;
            _company = (e.Parameter as List<Object>)[2] as Company;
            InitializeCompany();
        }

        private void InitializeCompany()
        {
            txtNameCompany.Text = _company.Name;
            txtMoneyCompany.Text = _company.Money.ToString();
          
            listMyDeveloppers.ItemsSource = _company.Devs;
            CheckListEmptyMyDev();
       
            listMyProjects.ItemsSource = _company.Projects;
            CheckListEmptyMyPro();
        }


        private void CheckListEmptyMyDev()
        {
            if (listMyDeveloppers.Items.Count == 0)
            {
                gridEmptyMyDev.Visibility = Visibility.Visible;
            }
        }

        private void CheckListEmptyMyPro()
        {
            if (listMyProjects.Items.Count == 0)
            {
                gridEmptyMyPro.Visibility = Visibility.Visible;
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

        private void LinkDevelopper_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(DevelopperPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Dev }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });

        }

        private void LinkProject_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(ProjectPage), new List<Object>() { _general, _rootFrame, (sender as TextBlock).Tag as Project }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });

        }
    }
}
