using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fog.Converters
{
    public class FileNameWithoutExtension : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DirectoryInfo info = new DirectoryInfo((string)value);
            return info.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DirectoryInfo info = new DirectoryInfo((string)value);
            return info.Name;
        }
    }
}
