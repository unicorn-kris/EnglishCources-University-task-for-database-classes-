using EnglishCources.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EnglishCources.Presentation.Converters
{
    internal class ExamConverter : MarkupExtension, IValueConverter
    {
        private static readonly ExamConverter Instance = new ExamConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (Exam)value;

            return $"group: {inputValue.Group.Number} {inputValue.Date}";
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
