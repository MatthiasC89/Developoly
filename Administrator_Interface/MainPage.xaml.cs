using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Administrator_Interface.Entities;
using Administrator_Interface.Services;
using System.Threading;
using Newtonsoft.Json;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Animation;
using System.Reflection;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Administrator_Interface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Dictionary<string, Page> pages =new Dictionary<string, Page>();

        private Service service = new Service();

        public MainPage()
        {
            this.InitializeComponent();
         }

        private NavigationViewItem _lastItem;
        private void NavigationView_OnItemInvoked(
            Windows.UI.Xaml.Controls.NavigationView sender,
            NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null || item == _lastItem)
                return;
            var clickedView = item.Tag?.ToString();
            if (!NavigateToView(clickedView)) return;
            _lastItem = item;
        }
        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly().GetType($"NavigationView.Views.{clickedView}");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }

            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }


        

        private void NewSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            
            switch ((string)((NavigationViewItem)args.SelectedItem).Tag)
            {
                case "DevParameter":
                    ContentFrame.Navigate(typeof(DevParameter), pages);
                    break;
                case "CompanyParameter":
                    ContentFrame.Navigate(typeof(CompanyParameter), pages);
                    break;
                case "ProjectParameter":
                    ContentFrame.Navigate(typeof(ProjectParameter), pages);
                    break;
                case "SkillParameter":
                    ContentFrame.Navigate(typeof(SkillParameter), pages);
                    break;
                case "CourseParameter":
                    ContentFrame.Navigate(typeof(CourseParameter), pages);
                    break;
                //case "GameParameter":
                //    ContentFrame.Navigate(typeof(GameParameter), new CommGamePArameter(pages, service));
                //    break;
            }

            if (pages.Count == 5)
            {
                gameParameter.Visibility = Visibility.Visible;
            }
        }
    }
}
