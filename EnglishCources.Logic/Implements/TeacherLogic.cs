using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class TeacherLogic : ITeacherLogic
    {
        private ITeacherRepository _teacherRepository;

        public TeacherLogic(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public int Add(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Teacher GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetTeachersByLevel(int levelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> SortedTeachersByExperience()
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, Teacher newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
