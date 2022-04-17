namespace EnglishCources.Common
{
    public class ExamResults
    {
        public int ID { get; set; }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public int Mark { get; set; }
    }
}
