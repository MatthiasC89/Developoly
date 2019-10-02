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
    public sealed partial class SchoolPage : Page, SchoolPageInterface
    {
        private Frame _rootFrame;

        private General _general;
        General SchoolPageInterface.General { get => _general; set => _general = value; }

        private Service _service;

        public SchoolPage() { }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.InitializeComponent();
            _general = (e.Parameter as List<Object>)[0] as General;
            _service = _general.Service as Service;
            _rootFrame = (e.Parameter as List<Object>)[1] as Frame;
        }

        private void Link_PointerOver(object sender, PointerRoutedEventArgs e)
        {
            (sender as TextBlock).Foreground = new SolidColorBrush((Color)Application.Current.Resources["CadetBlue"]);
        }

        private void Link_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            (sender as TextBlock).Foreground = new SolidColorBrush((Color)Application.Current.Resources["PayneGrey"]);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await contentAddDev.ShowAsync();
        }

        private void contentAddDev_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Add DEV
        }

        private void LinkDevelopper_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _rootFrame.Navigate(typeof(DevelopperPage), new List<Object> { _rootFrame, "Developper" }, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }


    }
}
