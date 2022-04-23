using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class LessonLogic : ILessonLogic
    {
        private ILessonRepository _lessonRepository;

        public LessonLogic(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public int Add(Lesson entity)
        {
            return _lessonRepository.Add(entity);   
        }

        public int Delete(int entityId)
        {
            return _lessonRepository.Delete(entityId);
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _lessonRepository.GetAll();
        }

        public Lesson GetById(int entityId)
        {
            return _lessonRepository.GetById(entityId);
        }

        public IEnumerable<Lesson> GetLessonsByDate(DateTime date)
        {
            return _lessonRepository.GetLessonsByDate(date);
        }

        public IEnumerable<Lesson> GetLessonsByGroup(int groupId)
        {
            return _lessonRepository.GetLessonsByGroup(groupId);
        }

        public void Update(int entityId, Lesson newEntity)
        {
            _lessonRepository.Update(entityId, newEntity);
        }
    }
}
