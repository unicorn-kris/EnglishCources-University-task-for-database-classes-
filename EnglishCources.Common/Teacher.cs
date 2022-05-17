namespace EnglishCources.Common
{
    public class Teacher: NotifyPropertyChangedBase
    {
        private int _id;

        private string _name;

        private string _surname;

        private int _age;

        private int _experience;

        public int Id
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
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

        public int Age
        {
            get => _age;
            set => OnPropertyChanged(value, ref _age);
        }

        public int Experience
        {
            get => _experience;
            set => OnPropertyChanged(value, ref _experience);
        }
    }
}