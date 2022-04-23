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
            return _examResultsRepository.Add(entity); 
        }

        public int Delete(int entityId)
        {
            return _examResultsRepository.Delete(entityId);
        }

        public IEnumerable<ExamResults> GetAll()
        {
            return _examResultsRepository.GetAll();
        }

        public ExamResults GetById(int entityId)
        {
           return _examResultsRepository.GetById(entityId);
        }

        public IEnumerable<ExamResults> GetExamResultsByMark(int mark)
        {
            return _examResultsRepository.GetExamResultsByMark(mark);
        }

        public IEnumerable<ExamResults> GetExamResultsByStudent(int studentId)
        {
            return _examResultsRepository.GetExamResultsByStudent(studentId);
        }

        public void Update(int entityId, ExamResults newEntity)
        {
            _examResultsRepository.Update(entityId, newEntity); 
        }
    }
}
