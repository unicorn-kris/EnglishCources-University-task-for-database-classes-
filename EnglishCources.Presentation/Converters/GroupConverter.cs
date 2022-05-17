using EnglishCources.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EnglishCources.Presentation.Converters
{
    internal class GroupConverter : MarkupExtension, IValueConverter
    {
        private static readonly GroupConverter Instance = new GroupConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (Group)value;

            return $"group: {inputValue.Number} english min level: {inputValue.MinLevel.Letter} {inputValue.MinLevel.Number}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
    }
}
