namespace EnglishCources.Common
{
    public class ExamResults : NotifyPropertyChangedBase
    {
        private int _id;

        private Student _student;

        private Exam _exam;

        private int _mark;

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

        public Exam Exam
        {
            get => _exam;
            set => OnPropertyChanged(value, ref _exam);
        }

        public int Mark
        {
            get => _mark;
            set => OnPropertyChanged(value, ref _mark);
        }
    }
}