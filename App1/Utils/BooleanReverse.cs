using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace App1.Utils
{
    class BooleanReverse : BooleanConverter<bool>
    {
        public BooleanReverse() :
            base(false, true)
        { }
    }
}
