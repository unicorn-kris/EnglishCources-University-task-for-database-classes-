using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Student entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddStudent";
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Surname", entity.Surname);
                cmd.Parameters.AddWithValue("EnglishLevel", entity.EnglishLevel);
                cmd.Parameters.AddWithValue("GroupNumber", entity.GroupNumber);

                var id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "ID",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(id);

                connection.Open();

                if (cmd.ExecuteNonQuery() >= 1)
                {
                    addedEntityId = int.Parse(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    throw new IncorrectDataException();
                }
            }
            return addedEntityId;
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

        public void Update(int entityId, Student newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateStudent";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Name", newEntity.Name);
                cmd.Parameters.AddWithValue("Surname", newEntity.Surname);
                cmd.Parameters.AddWithValue("EnglishLevel", newEntity.EnglishLevel);
                cmd.Parameters.AddWithValue("GroupNumber", newEntity.GroupNumber);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
