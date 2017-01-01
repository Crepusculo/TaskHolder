using System;
using Windows.UI.Xaml.Data;

namespace App1.Utils
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var t = (DateTimeOffset) value;
            var ret = t.Year + "/" + t.Month + "/" + t.Day;
            return (string) ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DebugUtil.WriteLine((string) value, "");
            string[] strs = ((string) value).Split('/');
            int[] ints =
            {
                System.Convert.ToInt32(strs[0]), System.Convert.ToInt32(strs[1]),
                System.Convert.ToInt32(strs[2])
            };
            return new DateTimeOffset(ints[0], ints[1], ints[2], 0, 0, 0, TimeSpan.Zero);
        }
    }
}