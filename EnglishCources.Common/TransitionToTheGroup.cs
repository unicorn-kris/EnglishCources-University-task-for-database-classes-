namespace EnglishCources.Common
{
    public class TransitionToTheGroup: NotifyPropertyChangedBase
    {
        private int _id;

        private Student _student;

        private Group _group;

        private DateTime _date;

        public int ID
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public Student Student
        {
            get => _student;
            set => OnPropertyChanged(value, ref _student);
        }

        public Group GroupNew
        {
            get => _group;
            set => OnPropertyChanged(value, ref _group);
        }

        public DateTime Date
        {
            get => _date;
            set => OnPropertyChanged(value, ref _date);
        }
    }
}