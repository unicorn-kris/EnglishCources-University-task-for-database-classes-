using EnglishCources.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EnglishCources.Presentation.Converters
{
    internal class BookConverter : MarkupExtension, IValueConverter
    {
        private static readonly BookConverter Instance = new BookConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (Book)value;

            return $"{inputValue.Title} author:{inputValue.Author}";
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
