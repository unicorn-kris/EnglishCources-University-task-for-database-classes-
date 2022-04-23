using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class TransitionToTheGroupRepository : ITransitionToTheGroupRepository
    {
        private readonly string _connectionString;

        public TransitionToTheGroupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(TransitionToTheGroup entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddTransitionToTheGroup";
                cmd.Parameters.AddWithValue("Student", entity.Student);
                cmd.Parameters.AddWithValue("Date", entity.Date);
                cmd.Parameters.AddWithValue("GroupNew", entity.GroupNew);

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

        public IEnumerable<TransitionToTheGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransitionToTheGroup GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheGroup> GetTransitionToTheGroupsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheGroup> SortedTransitionToTheGroupsByDate()
        {
            throw new NotImplementedException();
        }

        public void Update(int entityId, TransitionToTheGroup newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateTransitionToTheGroup";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Student", newEntity.Student);
                cmd.Parameters.AddWithValue("Date", newEntity.Date);
                cmd.Parameters.AddWithValue("GroupNew", newEntity.GroupNew);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
