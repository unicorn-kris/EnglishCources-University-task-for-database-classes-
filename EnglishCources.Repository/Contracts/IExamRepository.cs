using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface IExamRepository: IEntityRepository<Exam>
    {
        IEnumerable<Exam> GetExamsByDay(DateTime day);
        IEnumerable<Exam> GetExamsByGroup(int groupId);
    }
}
