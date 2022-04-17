using EnglishCources.Common;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Repository.Implements
{
    internal class LessonRepository : ILessonRepository
    {
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
