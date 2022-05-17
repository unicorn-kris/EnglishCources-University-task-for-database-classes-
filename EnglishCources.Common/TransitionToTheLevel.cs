namespace EnglishCources.Common
{
    public class TransitionToTheLevel: NotifyPropertyChangedBase
    {
        private int _id;

        private Student _student;

        private EnglishLevel _level;

        private DateTime _date;

        public int Id
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public Student Student
        {
            get => _student;
            set => OnPropertyChanged(value, ref _student);
        }

        public EnglishLevel LevelNew
        {
            get => _level;
            set => OnPropertyChanged(value, ref _level);
        }

        public DateTime Date
        {
            get => _date;
            set => OnPropertyChanged(value, ref _date);
        }
    }
}