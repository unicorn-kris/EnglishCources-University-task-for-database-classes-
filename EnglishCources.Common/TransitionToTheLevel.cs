namespace EnglishCources.Common
{
    public class TransitionToTheLevel
    {
        public int ID { get; set; }
        public Student Student { get; set; }
        public EnglishLevel LevelNew { get; set; }
        public DateTime Date { get; set; }
    }
}
