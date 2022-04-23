using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class ExamResultsRepository : IExamResultsRepository
    {
        private readonly string _connectionString;

        public ExamResultsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(ExamResults entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddExamResults";
                cmd.Parameters.AddWithValue("Student", entity.Student);
                cmd.Parameters.AddWithValue("Exam", entity.Exam);
                cmd.Parameters.AddWithValue("Mark", entity.Mark);

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

        public void Delete(int entityId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteExamResults";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<ExamResults> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExamResults GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResults> GetExamResultsByMark(int mark)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResults> GetExamResultsByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public void Update(int entityId, ExamResults newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExamResults";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Student", newEntity.Student);
                cmd.Parameters.AddWithValue("Exam", newEntity.Exam);
                cmd.Parameters.AddWithValue("Mark", newEntity.Mark);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
