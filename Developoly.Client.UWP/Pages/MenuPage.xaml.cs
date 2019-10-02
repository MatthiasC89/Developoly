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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Developoly.Client.Entities;
using Developoly.Client.Services;
using Developoly.Client.Services.Interfaces;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Developoly.Client.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page, MenuPageInterface
    {
        private List<Button> _buttonMenu;
        public List<Button> ButtonMenu { get => _buttonMenu; set => _buttonMenu = value; }

        private General _general;
        General MenuPageInterface.General { get => _general; set => _general = value; }

        private Service _service;

        public MenuPage() { }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.InitializeComponent();
            _general = e.Parameter as General;
            _service = _general.Service as Service;
            rootFrame.Navigate(typeof(GamePage), new List<Object>() { _general, rootFrame }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            ButtonMenu = new List<Button>() { btnGame, btnMyCompany, btnSchools };
            ButtonMenuSelected(btnGame);
        }



        private void btnGame_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(GamePage), new List<Object>() { _general, rootFrame }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            ButtonMenuSelected(btnGame);
        }

        private void btnMyCompany_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(CompanyPage), new List<Object>() { _general, rootFrame }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            ButtonMenuSelected(btnMyCompany);
        }


        private void btnSchools_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(SchoolPage), new List<Object>() { _general, rootFrame }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            ButtonMenuSelected(btnSchools);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                NavigationByArrow(rootFrame.SourcePageType.Name);
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (rootFrame.CanGoForward)
            {
                rootFrame.GoForward();
                NavigationByArrow(rootFrame.SourcePageType.Name);
            }
        }

        private void ButtonMenuSelected(Button buttonSelected)
        {
            ButtonMenu.Where(b => b != buttonSelected).ToList().ForEach(dev =>
            {
                dev.Background = new SolidColorBrush((Color)Application.Current.Resources["MidnightGreen"]);
            });
            buttonSelected.Background = new SolidColorBrush((Color)Application.Current.Resources["PayneGrey"]);
        }

        private void NavigationByArrow(string type)
        {
            switch (type)
            {
                case "GamePage":
                    ButtonMenuSelected(btnGame);
                    break;

                case "CompanyPage":
                    ButtonMenuSelected(btnMyCompany);
                    break;

                case "SchoolPage":
                    ButtonMenuSelected(btnSchools);
                    break;
            }
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
