using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class EnglishLevelRepository : IEnglishLevelRepository
    {
        private readonly string _connectionString;

        public EnglishLevelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(EnglishLevel entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddEnglishLevel";
                cmd.Parameters.AddWithValue("Letter", entity.Letter);
                cmd.Parameters.AddWithValue("Number", entity.Number);

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
                cmd.CommandText = "DeleteEnglishLevel";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<EnglishLevel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EnglishLevel GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnglishLevel> SortedEnglishLevels()
        {
            throw new NotImplementedException();
        }

        public void Update(int entityId, EnglishLevel newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEnglishLevel";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Letter", newEntity.Letter);
                cmd.Parameters.AddWithValue("Number", newEntity.Number);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
