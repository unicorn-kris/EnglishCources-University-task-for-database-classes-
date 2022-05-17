namespace EnglishCources.Common
{
    public class Student: NotifyPropertyChangedBase
    {
        private int _id;

        private string _name;

        private string _surname;

        private EnglishLevel _englishLevel;

        private Group _groupNumber;

        private int _age;

        public int Id
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public int Age
        {
            get => _age;
            set => OnPropertyChanged(value, ref _age);
        }

        public string Name
        {
            get => _name;
            set => OnPropertyChanged(value, ref _name);
        }

        public string Surname
        {
            get => _surname;
            set => OnPropertyChanged(value, ref _surname);
        }

        public EnglishLevel EnglishLevel
        {
            get => _englishLevel;
            set => OnPropertyChanged(value, ref _englishLevel);
        }

        public Group GroupNumber
        {
            get => _groupNumber;
            set => OnPropertyChanged(value, ref _groupNumber);
        }
    }
}