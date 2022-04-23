using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class TeacherRepository : ITeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Teacher entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddTeacher";
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Surname", entity.Surname);
                cmd.Parameters.AddWithValue("Age", entity.Age);
                cmd.Parameters.AddWithValue("Experience", entity.Experience);

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

        public void Update(int entityId, Teacher newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateTeacher";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Name", newEntity.Name);
                cmd.Parameters.AddWithValue("Surname", newEntity.Surname);
                cmd.Parameters.AddWithValue("Age", newEntity.Age);
                cmd.Parameters.AddWithValue("Experience", newEntity.Experience);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
