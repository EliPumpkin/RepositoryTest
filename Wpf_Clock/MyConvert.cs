using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
namespace Wpf_Clock
{
    class MTypeConvert : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if(value is string)
            {
                Human h = new Human();
                h.Name = value as string;
                return h;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    [ValueConversion(typeof(bool),typeof(int))]
    class MValueConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value == true) return 1;

            return 0;

        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }  
    }
}
