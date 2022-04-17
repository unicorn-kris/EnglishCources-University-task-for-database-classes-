using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface ILessonLogic: IEntityLogic<Lesson>
    {
        IEnumerable<Lesson> GetLessonsByDate(DateTime date);
        IEnumerable<Lesson> GetLessonsByGroup(int groupId);
    }
}
