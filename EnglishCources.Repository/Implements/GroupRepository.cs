using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly string _connectionString;

        public GroupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Group entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddGroup";
                cmd.Parameters.AddWithValue("Number", entity.Number);
                cmd.Parameters.AddWithValue("Teacher", entity.Teacher);
                cmd.Parameters.AddWithValue("MinLevel", entity.MinLevel);

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
                cmd.CommandText = "DeleteGroup";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Group GetGroupByNumber(int groupNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetGroupsByLevel(int englishLevel)
        {
            throw new NotImplementedException();
        }

        public void Update(int entityId, Group newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateGroup";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Number", newEntity.Number);
                cmd.Parameters.AddWithValue("Teacher", newEntity.Teacher);
                cmd.Parameters.AddWithValue("MinLevel", newEntity.MinLevel);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
