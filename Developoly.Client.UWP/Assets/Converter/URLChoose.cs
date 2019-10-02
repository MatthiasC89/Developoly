using Developoly.Client.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Developoly.Client.UWP.Assets.Converter
{
    public class URLChoose : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Dev dev = value as Dev; 
            if (dev.Projet == null) { 
                if (dev.Course == null)
                {
                    return "../Assets/Pictures/Developper/valid.png";
                } else
                {
                    return "../Assets/Pictures/Courses/courses.png";
                }
            } else
            {
                return "../Assets/Pictures/Project/project.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
