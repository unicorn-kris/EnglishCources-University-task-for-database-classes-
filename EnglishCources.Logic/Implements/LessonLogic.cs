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
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lesson> GetAll()
        {
            throw new NotImplementedException();
        }

        public Lesson GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lesson> GetLessonsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lesson> GetLessonsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, Lesson newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
