using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface IStudentLogic: IEntityLogic<Student>
    {
        IEnumerable<Student> GetStudentsByLevel(int levelId);
        IEnumerable<Student> GetStudentsByGroup(int groupId);
    }
}
