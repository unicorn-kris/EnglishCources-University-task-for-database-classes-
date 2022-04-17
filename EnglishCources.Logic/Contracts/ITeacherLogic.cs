using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface ITeacherLogic: IEntityLogic<Teacher>
    {
        IEnumerable<Teacher> GetTeachersByLevel(int levelId);
        IEnumerable<Teacher> SortedTeachersByExperience();
    }
}
