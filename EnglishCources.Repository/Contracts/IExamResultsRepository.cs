using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface IExamResultsRepository: IEntityRepository<ExamResults>
    {
        IEnumerable<ExamResults> GetExamResultsByStudent(int studentId);
        IEnumerable<ExamResults> GetExamResultsByMark(int mark);
    }
}
