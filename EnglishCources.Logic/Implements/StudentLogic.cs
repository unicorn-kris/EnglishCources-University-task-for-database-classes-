using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class StudentLogic : IStudentLogic
    {
        private IStudentRepository _studentRepository;

        public StudentLogic(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public int Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsByLevel(int levelId)
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, Student newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
