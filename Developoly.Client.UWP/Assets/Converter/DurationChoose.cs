using Developoly.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Developoly.Client.UWP.Assets.Converter
{
    public class DurationChoose : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Dev dev = value as Dev;
            if (dev.Projet == null)
            {
                if (dev.Course == null)
                {
                    return "0";
                }
                else
                {
                    return dev.Course.Duration.ToString();
                }
            }
            else
            {
                return dev.Projet.Duration.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
