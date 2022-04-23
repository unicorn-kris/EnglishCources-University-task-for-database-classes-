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
            return _teacherRepository.Add(entity);
        }

        public int Delete(int entityId)
        {
            return _teacherRepository.Delete(entityId);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetById(int entityId)
        {
            return _teacherRepository.GetById(entityId);
        }

        public IEnumerable<Teacher> GetTeachersByLevel(int levelId)
        {
            return _teacherRepository.GetTeachersByLevel(levelId);
        }

        public IEnumerable<Teacher> SortedTeachersByExperience()
        {
            return _teacherRepository.SortedTeachersByExperience();
        }

        public int Update(int entityId, Teacher newEntity)
        {
            return _teacherRepository.Update(entityId, newEntity);  
        }
    }
}
