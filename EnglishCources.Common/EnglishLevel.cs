namespace EnglishCources.Common
{
    public class EnglishLevel: NotifyPropertyChangedBase
    {
        private int _id;

        private string _letter;

        private int _number;

        public int ID
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public string Letter
        {
            get => _letter;
            set => OnPropertyChanged(value, ref _letter);
        }

        public int Number
        {
            get => _number;
            set => OnPropertyChanged(value, ref _number);
        }
    }
}