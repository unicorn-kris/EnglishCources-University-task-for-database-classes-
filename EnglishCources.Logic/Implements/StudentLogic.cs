﻿using EnglishCources.Common;
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
            return _studentRepository.Add(entity);
        }

        public int Delete(int entityId)
        {
            return _studentRepository.Delete(entityId);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int entityId)
        {
            return _studentRepository.GetById(entityId);
        }

        public IEnumerable<Student> GetStudentsByGroup(int groupId)
        {
            return _studentRepository.GetStudentsByGroup(groupId);
        }

        public IEnumerable<Student> GetStudentsByLevel(int levelId)
        {
            return _studentRepository.GetStudentsByLevel(levelId);
        }

        public int Update(int entityId, Student newEntity)
        {
            return _studentRepository.Update(entityId, newEntity);
        }
    }
}
