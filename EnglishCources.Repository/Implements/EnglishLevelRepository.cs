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

                var returnValue = new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(returnValue);

                connection.Open();
                cmd.ExecuteNonQuery();

                if ((int)returnValue.Value != -1 && returnValue.Value != null)
                {
                    addedEntityId = (int)returnValue.Value;
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

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<EnglishLevel> GetAll()
        {
            List<EnglishLevel> englishLevels = new List<EnglishLevel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllEnglishLevels";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        englishLevels.Add(new EnglishLevel()
                        {
                            Id = reader.GetInt32("Id"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        });
                    }
                }
            }

            return englishLevels;
        }

        public EnglishLevel GetById(int entityId)
        {
            EnglishLevel englishLevel = new EnglishLevel();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectEnglishLevelById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        englishLevel.Id = reader.GetInt32("Id");
                        englishLevel.Number = reader.GetInt32("Number");
                        englishLevel.Letter = reader.GetString("Letter");
                    }
                }
            }

            return englishLevel;
        }

        public IEnumerable<EnglishLevel> SortedEnglishLevels()
        {
            List<EnglishLevel> englishLevels = new List<EnglishLevel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SortEnglishLevels";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        englishLevels.Add(new EnglishLevel()
                        {
                            Id = reader.GetInt32("Id"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        });
                    }
                }
            }

            return englishLevels;
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

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
