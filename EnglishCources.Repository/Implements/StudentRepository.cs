using EnglishCources.Common;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Repository.Implements
{
    internal class StudentRepository : IStudentRepository
    {
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
