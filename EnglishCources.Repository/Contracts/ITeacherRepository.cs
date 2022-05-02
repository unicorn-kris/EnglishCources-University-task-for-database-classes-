using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface ITeacherRepository: IEntityRepository<Teacher>
    {
        IEnumerable<Teacher> SortedTeachersByExperience();
    }
}
