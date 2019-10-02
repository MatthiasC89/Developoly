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

namespace Administrator_Interface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CourseParameter : Page
    {
        private int _priceCourse = 200;
        public int PriceCourse { get => _priceCourse; set => _priceCourse = value; }
        private int _multiplierCourse = 2;
        public int MultiplierCourse { get => _multiplierCourse; set => _multiplierCourse = value; }
        private int _minCourse = 1;
        public int MinCourse { get => _minCourse; set => _minCourse = value; }
        private int _maxCourse;
        public int MaxCourse { get => _maxCourse; set => _maxCourse = value; }

        public CourseParameter()
        {
            this.InitializeComponent();
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!(e.Parameter as Dictionary<string, Page>).ContainsKey("pageCourse"))
            {
                (e.Parameter as Dictionary<string, Page>).Add("pageCourse", this);
            }
        }


        private void SliderMinCourse_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MinCourse = Convert.ToInt32(e.NewValue);
        }

        private void SliderMaxCourse_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MaxCourse = Convert.ToInt32(e.NewValue);
        }

        private void SliderMultiplierCourse_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MultiplierCourse = Convert.ToInt32(e.NewValue);
        }

        private void SliderPriceCourse_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            PriceCourse = Convert.ToInt32(e.NewValue);
        }
    }
}
