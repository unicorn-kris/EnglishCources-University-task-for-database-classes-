using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class ExamRepository : IExamRepository
    {
        private readonly string _connectionString;

        public ExamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Exam entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddExam";
                cmd.Parameters.AddWithValue("Group", entity.Group);
                cmd.Parameters.AddWithValue("Date", entity.Date);

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

        public IEnumerable<Exam> GetAll()
        {
            throw new NotImplementedException();
        }

        public Exam GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExamsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExamsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public void Update(int entityId, Exam newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExam";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Group", newEntity.Group);
                cmd.Parameters.AddWithValue("Date", newEntity.Date);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
