using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface IExamResultsLogic: IEntityLogic<ExamResults>
    {
        IEnumerable<ExamResults> GetExamResultsByStudent(int studentId);
        IEnumerable<ExamResults> GetExamResultsByMark(int mark);
    }
}
