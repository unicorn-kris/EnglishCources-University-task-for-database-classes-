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
            return _examRepository.Add(entity);
        }

        public void Delete(int entityId)
        {
            _examRepository.Delete(entityId);
        }

        public IEnumerable<Exam> GetAll()
        {
            return _examRepository.GetAll();
        }

        public Exam GetById(int entityId)
        {
            return _examRepository.GetById(entityId);   
        }

        public IEnumerable<Exam> GetExamsByDay(DateTime day)
        {
            return _examRepository.GetExamsByDay(day);
        }

        public IEnumerable<Exam> GetExamsByGroup(int groupId)
        {
            return _examRepository.GetExamsByGroup(groupId);
        }

        public void Update(int entityId, Exam newEntity)
        {
            _examRepository.Update(entityId, newEntity);
        }
    }
}
