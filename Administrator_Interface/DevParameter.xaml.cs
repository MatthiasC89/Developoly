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
    public sealed partial class DevParameter : Page
    {
        private int _skillDev = 30;
        public int SkillDev { get => _skillDev; set => _skillDev = value; }
        private int _nbDev = 0;
        public int NbDev { get => _nbDev; set => _nbDev = value; }
        private int _salaryDev = 1500;
        public int SalaryDev { get => _salaryDev; set => _salaryDev = value; }
        private int _hiringDev = 800;
        public int HiringDev { get => _hiringDev; set => _hiringDev = value; }
        private int _multiplierHiringDev = 2;
        public int MultiplierHiringDev { get => _multiplierHiringDev; set => _multiplierHiringDev = value; }
        private int _multiplierSalaryDev = 2;
        public int MultiplierSalaryDev { get => _multiplierSalaryDev; set => _multiplierSalaryDev = value; }

        public DevParameter()
        {
            this.InitializeComponent();
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!(e.Parameter as Dictionary<string, Page>).ContainsKey("pageDev"))
            {
                (e.Parameter as Dictionary<string, Page>).Add("pageDev", this);
            }
        }

        private void ComboBoxSkillsDev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (comboBoxSkillsDev.SelectedIndex)
            {
                case 0:
                    SkillDev = 15;
                    break;

                case 1:
                    SkillDev = 30;
                    break;

                case 2:
                    SkillDev = 50;
                    break;

                default:
                    break;
            }

        }

        private void SliderNbDev_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            NbDev = Convert.ToInt32(e.NewValue);
        }

        private void SalaryDeveloper_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SalaryDev = Convert.ToInt32(e.NewValue);
        }

        private void HiringDeveloper_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            HiringDev = Convert.ToInt32(e.NewValue);
        }

        private void MultiplierHiringDeveloper_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MultiplierHiringDev = Convert.ToInt32(e.NewValue);
        }

        private void MultiplierSalaryDeveloper_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MultiplierSalaryDev = Convert.ToInt32(e.NewValue);
        }
    }
}
