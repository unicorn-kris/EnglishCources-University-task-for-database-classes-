using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class ExamResultsLogic : IExamResultsLogic
    {
        private IExamResultsRepository _examResultsRepository;

        public ExamResultsLogic(IExamResultsRepository examResultsRepository)
        {
            _examResultsRepository = examResultsRepository;
        }

        public int Add(ExamResults entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResults> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExamResults GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResults> GetExamResultsByMark(int mark)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResults> GetExamResultsByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, ExamResults newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
