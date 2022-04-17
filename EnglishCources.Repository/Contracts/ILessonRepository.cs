using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface ILessonRepository: IEntityRepository<Lesson>
    {
        IEnumerable<Lesson> GetLessonsByDate(DateTime date);
        IEnumerable<Lesson> GetLessonsByGroup(int groupId);
    }
}
