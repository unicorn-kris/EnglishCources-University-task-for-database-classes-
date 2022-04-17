namespace EnglishCources.Common
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public Group GroupNumber { get; set; }
    }
}