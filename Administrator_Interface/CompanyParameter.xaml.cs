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
    public sealed partial class CompanyParameter : Page
    {
        private int _money = 25000;
        public int Money { get => _money; set => _money = value; }
        private int _winParameter = 50000;
        public int WinParameter { get => _winParameter; set => _winParameter = value; }
        private int _looseParameter = -5000;
        public int LooseParameter { get => _looseParameter; set => _looseParameter = value; }

        public CompanyParameter()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!(e.Parameter as Dictionary<string, Page>).ContainsKey("pageCompany")) { 
                (e.Parameter as Dictionary<string, Page>).Add("pageCompany", this);
            }
        }

        private void TxtMoney_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!Char.IsNumber(Convert.ToChar(e.Key)) && !Char.IsControl(Convert.ToChar(e.Key)))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, (sender as TextBox).Text.Length - 1);
                (sender as TextBox).Select((sender as TextBox).Text.Length, 0);
            }
        }

        private void TxtWin_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!Char.IsNumber(Convert.ToChar(e.Key)) && !Char.IsControl(Convert.ToChar(e.Key)))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, (sender as TextBox).Text.Length - 1);
                (sender as TextBox).Select((sender as TextBox).Text.Length, 0);
            }
        }

        private void TxtLoose_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!Char.IsNumber(Convert.ToChar(e.Key)) && !Char.IsControl(Convert.ToChar(e.Key)))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, (sender as TextBox).Text.Length - 1);
                (sender as TextBox).Select((sender as TextBox).Text.Length, 0);
            }
        }
    }
}
