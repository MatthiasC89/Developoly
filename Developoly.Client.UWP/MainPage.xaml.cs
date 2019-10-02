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
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using Developoly.Client.Entities;
using Developoly.Client.Services;
using Developoly.Client.UWP.Pages;
using Developoly.Client.Services.Interfaces;
using Windows.UI.Core;
using Windows.UI.Popups;



// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Developoly.Client.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page, MainPageInterface
    {
        private Service service;

        private General _general = new General();
        General MainPageInterface.General { get => _general; set => _general = value; }

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

       private async void GoToGamePage()
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                StartTimer();
            });      
        }

       async void MainPageInterface.MyCompanyAlreadyExist()
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                txtError.Visibility = Visibility.Visible;
                txtError.Text = "This company name: " + txtCompanyName.Text + " is already taken.";
                txtCompanyName.Text = "";
            });
        }

        

        async void MainPageInterface.LoadingScreen()
        {

            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (_general.NbActualPlayer != _general.NbPlayerMax)
                {
                    gridLoadingScreen.Visibility = Visibility.Visible;
                    txtNumberPlayerActual.Text = _general.NbActualPlayer.ToString();
                    txtNumberPlayerMaximum.Text = _general.NbPlayerMax.ToString();
                    txtNameCompany.Text = _general.MyCompany.Name;
                    txtMoneyCompany.Text = _general.MoneyStart.ToString();
                    txtNbTurn.Text = _general.NbTurn.ToString();
                }
                else
                {
                    GoToGamePage();
                }
            });
        }

        async void MainPageInterface.SetupGame()
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                    txtNumberPlayerMaximum.Text = _general.NbPlayerMax.ToString();
                    txtMoneyCompany.Text = _general.MoneyStart.ToString();
                    txtNbTurn.Text = _general.NbTurn.ToString();
            });
        }

        async void MainPageInterface.ChangeLoading(string nbActualPlayer)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (Convert.ToInt32(nbActualPlayer) != _general.NbPlayerMax)
                {
                    txtNumberPlayerActual.Text = nbActualPlayer;
                } else
                {
                    GoToGamePage();
                }
            });
        }

        private void StartTimer()
        {

            gridLoadingScreen.Visibility = Visibility.Collapsed;
            gridReadyToGo.Visibility = Visibility.Visible;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, object e)
        {
            if (RadialProgressBarReady.Value + 1 < 4)
            {
                RadialProgressBarReady.Value = RadialProgressBarReady.Value + 1;
                txtTimer.Text = (Convert.ToInt16(txtTimer.Text) - 1).ToString();
            }
            else
            {
                this.Frame.Navigate(typeof(MenuPage), _general);
                (sender as DispatcherTimer).Tick -= dispatcherTimer_Tick;
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (txtCompanyName.Text != "")
            {
                MainPageInterface interfaceMain = this;

                service = new Service("10.4.0.37", 1234, interfaceMain);

                _general.Service = service;
                service.SendData(new Communication("AddNewCompany", txtCompanyName.Text));
                
            }
        }

    }

}
