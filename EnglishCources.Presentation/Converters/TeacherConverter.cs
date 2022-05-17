using EnglishCources.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EnglishCources.Presentation.Converters
{
    internal class TeacherConverter : MarkupExtension, IValueConverter
    {
        private static readonly TeacherConverter Instance = new TeacherConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (Teacher)value;

            return $"{inputValue.Id} {inputValue.Name} {inputValue.Surname} {inputValue.Age} experience: {inputValue.Experience}";
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
