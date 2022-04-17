using EnglishCources.Common;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Repository.Implements
{
    internal class ExamRepository : IExamRepository
    {
        public int Add(Exam entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetAll()
        {
            throw new NotImplementedException();
        }

        public Exam GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExamsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExamsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, Exam newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
