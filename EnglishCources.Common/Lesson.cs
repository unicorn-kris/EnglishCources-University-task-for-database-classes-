namespace EnglishCources.Common
{
    public class Lesson: NotifyPropertyChangedBase
    {
        private int _id;

        private Group _group;

        private DateTime _day;

        private int _hour;

        private Book _book;

        public int Id
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public Group Group
        {
            get => _group;
            set => OnPropertyChanged(value, ref _group);
        }

        public DateTime Day
        {
            get => _day;
            set => OnPropertyChanged(value, ref _day);
        }

        public int Hour
        {
            get => _hour;
            set => OnPropertyChanged(value, ref _hour);
        }

        public Book Book
        {
            get => _book;
            set => OnPropertyChanged(value, ref _book);
        }
    }
}