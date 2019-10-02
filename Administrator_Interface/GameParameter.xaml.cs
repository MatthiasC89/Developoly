using Administrator_Interface.Entities;
using Administrator_Interface.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class GameParameter : Page
    {
        private int _nbTurn = 10;
        public int NbTurn { get => _nbTurn; set => _nbTurn = value; }
        private int _nbPlayer = 4;
        public int NbPlayer { get => _nbPlayer; set => _nbPlayer = value; }
        private int _deficitThreshold = -5000;
        public int DeficitThreshold { get => _deficitThreshold; set => _deficitThreshold = value; }

       

        CommGamePArameter commGameParameter;

        private Service service;

        public GameParameter()
        {
            this.InitializeComponent();
        }

       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            commGameParameter = e.Parameter as CommGamePArameter;
            if (!commGameParameter.Pages.ContainsKey("pageGame"))
            {
                commGameParameter.Pages.Add("pageGame", this);
            }
        }

        private void SliderNbTurn_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            NbTurn = Convert.ToInt32(e.NewValue);
        }

        private void SliderNbPlayer_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            NbPlayer = Convert.ToInt32(e.NewValue);
        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            Thread threadClientListen = new Thread(Listen);
            threadClientListen.Start();

            int money = (commGameParameter.Pages["pageCompany"] as CompanyParameter).Money;
            int skillDev = (commGameParameter.Pages["pageDev"] as DevParameter).SkillDev;
            int numberDev = (commGameParameter.Pages["pageDev"] as DevParameter).NbDev;
            int numberTurn = (commGameParameter.Pages["pageGame"] as GameParameter).NbTurn;
            int numberPlayer = (commGameParameter.Pages["pageGame"] as GameParameter).NbPlayer;
            int priceCourse = (commGameParameter.Pages["pageCourse"] as CourseParameter).PriceCourse;
            int minCourse = (commGameParameter.Pages["pageCourse"] as CourseParameter).MinCourse;
            int maxCourse = (commGameParameter.Pages["pageCourse"] as CourseParameter).MaxCourse;
            int salaryDev = (commGameParameter.Pages["pageDev"] as DevParameter).SalaryDev;
            int hiringDev = (commGameParameter.Pages["pageDev"] as DevParameter).HiringDev;
            int rewards = (commGameParameter.Pages["pageProject"] as ProjectParameter).DefaultRewards;
            int skillProject = (commGameParameter.Pages["pageProject"] as ProjectParameter).SkillProject;
            int minDurationProject = (commGameParameter.Pages["pageProject"] as ProjectParameter).MinDuration;
            int maxDurationProject = (commGameParameter.Pages["pageProject"] as ProjectParameter).MaxDuration;
            int multiplierHiringDev = (commGameParameter.Pages["pageDev"] as DevParameter).MultiplierHiringDev;
            int multiplierSalaryDev = (commGameParameter.Pages["pageDev"] as DevParameter).MultiplierSalaryDev;
            int multiplierCourse = (commGameParameter.Pages["pageCourse"] as CourseParameter).MultiplierCourse;
            int winPara = (commGameParameter.Pages["pageCompany"] as CompanyParameter).WinParameter;
            int loosePara = (commGameParameter.Pages["pageCompany"] as CompanyParameter).LooseParameter;

            GameParameters gameParameter = new GameParameters(money, skillDev, numberDev, numberTurn, numberPlayer, priceCourse, minCourse, maxCourse, salaryDev, hiringDev, rewards, skillProject, minDurationProject, maxDurationProject, multiplierHiringDev, multiplierSalaryDev, multiplierCourse, winPara, loosePara);
            (commGameParameter.Services as Service).SendData(new Communication("SetupGame", JsonConvert.SerializeObject(gameParameter))); 
        }

        public async void Listen()
        {
            service = new Service("10.4.0.37", 1234);
            while (true)
            {
                Communication info = service.ReceiveData();
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (info != null)
                    {
                        service.ReceiveInfo(info);
                    }
                });
            }
        }

        private void TxtDeficit_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!Char.IsNumber(Convert.ToChar(e.Key)) && !Char.IsControl(Convert.ToChar(e.Key)))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, (sender as TextBox).Text.Length - 1);
                (sender as TextBox).Select((sender as TextBox).Text.Length, 0);
            }
        }
    }
}
