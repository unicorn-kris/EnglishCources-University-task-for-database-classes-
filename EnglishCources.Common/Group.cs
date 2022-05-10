namespace EnglishCources.Common
{
    public class Group: NotifyPropertyChangedBase
    {
        private int _id;

        private int _number;

        private EnglishLevel _englishLevel;

        private Teacher _teacher;

        public int ID
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public int Number
        {
            get => _number;
            set => OnPropertyChanged(value, ref _number);
        }

        public EnglishLevel MinLevel
        {
            get => _englishLevel;
            set => OnPropertyChanged(value, ref _englishLevel);
        }

        public Teacher Teacher
        {
            get => _teacher;
            set => OnPropertyChanged(value, ref _teacher);
        }
    }
}