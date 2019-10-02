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
    public sealed partial class ProjectParameter : Page
    {
        private int _defaultRewards = 1500;
        public int DefaultRewards { get => _defaultRewards; set => _defaultRewards = value; }
        private int _skillProject = 25;
        public int SkillProject { get => _skillProject; set => _skillProject = value; }
        private int _minDuration =1;
        public int MinDuration { get => _minDuration; set => _minDuration = value; }
        private int _maxDuration = 4;
        public int MaxDuration { get => _maxDuration; set => _maxDuration = value; }


        public ProjectParameter()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!(e.Parameter as Dictionary<string, Page>).ContainsKey("pageProject"))
            {
                (e.Parameter as Dictionary<string, Page>).Add("pageProject", this);
            }
        }

        private void SliderDefaultrRewards_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            DefaultRewards = Convert.ToInt32(e.NewValue);
        }

        private void SliderMaxDurationProject_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MaxDuration = Convert.ToInt32(e.NewValue);
        }

        private void ComboBoxSkillProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (comboBoxSkillProject.SelectedIndex)
            {
                case 0:
                    SkillProject = 10;
                    break;

                case 1:
                    SkillProject = 25;
                    break;

                case 2:
                    SkillProject = 45;
                    break;

                default:
                    break;
            }
        }

        private void SliderMinDurationProject_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MinDuration = Convert.ToInt32(e.NewValue);
        }
    }
}
