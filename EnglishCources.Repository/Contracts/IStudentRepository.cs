using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface IStudentRepository: IEntityRepository<Student>
    {
        IEnumerable<Student> GetStudentsByLevel(int levelId);
        IEnumerable<Student> GetStudentsByGroup(int groupId);
    }
}
