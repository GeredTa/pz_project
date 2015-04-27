using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Monitor_kl2.Models;

namespace Monitor_kl2
{
    public class HostStatusToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = Colors.White;

            switch ((Host.Status)value)
            {
                case Host.Status.Activated:
                    color = Colors.Green;
                    break;
                case Host.Status.Disabled:
                    color = Colors.Red;
                    break;
                case Host.Status.AddedToList:
                    color = Colors.LightSalmon;
                    break;
                case Host.Status.DeletedFromList:
                    color = Colors.LightGreen;
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
