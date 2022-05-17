using System.ComponentModel;

namespace EnglishCources.Common
{
    public class Book : NotifyPropertyChangedBase
    {
        public Book()
        {

        }
        private int _id;

        private string _title;

        private string _author;

        private EnglishLevel _englishLevel;

        public int Id {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public string Title
        {
            get => _title;
            set => OnPropertyChanged(value, ref _title);
        }

        public string Author
        {
            get => _author;
            set => OnPropertyChanged(value, ref _author);
        }

        public EnglishLevel EnglishLevel
        {
            get => _englishLevel;
            set => OnPropertyChanged(value, ref _englishLevel);
        }

    }
}