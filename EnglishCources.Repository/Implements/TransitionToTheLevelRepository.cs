using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class TransitionToTheLevelRepository : ITransitionToTheLevelRepository
    {
        private readonly string _connectionString;

        public TransitionToTheLevelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(TransitionToTheLevel entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddTransitionToTheLevel";
                cmd.Parameters.AddWithValue("Student", entity.Student);
                cmd.Parameters.AddWithValue("Date", entity.Date);
                cmd.Parameters.AddWithValue("LevelNew", entity.LevelNew);

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

        public IEnumerable<TransitionToTheLevel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransitionToTheLevel GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheLevel> GetTransitionToTheLevelsByLevel(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheLevel> SortedTransitionToTheLevelsByDate()
        {
            throw new NotImplementedException();
        }

        public void Update(int entityId, TransitionToTheLevel newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateTransitionToTheLevel";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Student", newEntity.Student);
                cmd.Parameters.AddWithValue("Date", newEntity.Date);
                cmd.Parameters.AddWithValue("LevelNew", newEntity.LevelNew);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
