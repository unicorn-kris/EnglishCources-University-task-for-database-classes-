using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class ExamLogic : IExamLogic
    {
        private IExamRepository _examRepository;

        public ExamLogic(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

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
