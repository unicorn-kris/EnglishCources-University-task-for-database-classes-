using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface IExamLogic: IEntityLogic<Exam>
    {
        IEnumerable<Exam> GetExamsByDay(DateTime day);
        IEnumerable<Exam> GetExamsByGroup(int groupId);
    }
}
