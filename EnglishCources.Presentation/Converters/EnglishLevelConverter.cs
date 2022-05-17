using EnglishCources.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EnglishCources.Presentation.Converters
{
    internal class EnglishLevelConverter : MarkupExtension, IValueConverter
    {
        private static readonly EnglishLevelConverter Instance = new EnglishLevelConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (EnglishLevel)value;

            return $"{inputValue.Letter} {inputValue.Number}";
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
