using LibGit2Sharp;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fog.Converters
{
    public class ChangedFIleStatusBorderBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            if ((FileStatus)value == FileStatus.ModifiedInIndex || (FileStatus)value == FileStatus.ModifiedInWorkdir)
            {
                return new SolidColorBrush(Windows.UI.Color.FromArgb(1, 191, 191, 0));

            }
            else if ((FileStatus)value == FileStatus.NewInIndex || (FileStatus)value == FileStatus.NewInWorkdir)
            {
                return new SolidColorBrush(new Windows.UI.Color
                {
                    A = 1,
                    R = 0,
                    G = 198,
                    B = 21
                });
            }
            else if ((FileStatus)value == FileStatus.DeletedFromIndex || (FileStatus)value == FileStatus.DeletedFromWorkdir)
            {
                return new SolidColorBrush(new Windows.UI.Color
                {
                    A = 1,
                    R = 176,
                    G = 27,
                    B = 0
                });
            }
            else
            {
                return new SolidColorBrush(new Windows.UI.Color
                {
                    A = 1,
                    R = 144,
                    G = 144,
                    B = 144
                });
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
