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

        public void Delete(int entityId)
        {
            _teacherRepository.Delete(entityId);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetById(int entityId)
        {
            return _teacherRepository.GetById(entityId);
        }

        public IEnumerable<Teacher> SortedTeachersByExperience()
        {
            return _teacherRepository.SortedTeachersByExperience();
        }

        public void Update(int entityId, Teacher newEntity)
        {
            _teacherRepository.Update(entityId, newEntity);  
        }
    }
}
