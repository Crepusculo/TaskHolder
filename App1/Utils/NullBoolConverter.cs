﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace App1.Utils
{   
    public class IsDoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool?)value ?? false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (bool)value;
        }
    }
}
