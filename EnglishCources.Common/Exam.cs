namespace EnglishCources.Common
{
    public class Exam: NotifyPropertyChangedBase
    {
        private int _id;

        private Group _group;

        private DateTime _date;

        public int ID
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public Group Group
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