using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface ITeacherRepository: IEntityRepository<Teacher>
    {
        IEnumerable<Teacher> GetTeachersByLevel(int levelId);
        IEnumerable<Teacher> SortedTeachersByExperience();
    }
}
