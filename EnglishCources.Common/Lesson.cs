namespace EnglishCources.Common
{
    public class Lesson
    {
        public int ID { get; set; }
        public Group Group { get; set; }
        public DateTime Day { get; set; }
        public int Hour { get; set; }
        public Book Book { get; set; }
    }
}
