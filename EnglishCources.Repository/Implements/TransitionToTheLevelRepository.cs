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
                cmd.Parameters.AddWithValue("Student", entity.Student.Id);
                cmd.Parameters.AddWithValue("Date", entity.Date);
                cmd.Parameters.AddWithValue("LevelNew", entity.LevelNew.Id);

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
                cmd.CommandText = "DeleteTransitionToTheLevel";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<TransitionToTheLevel> GetAll()
        {
            List<TransitionToTheLevel> transitions = new List<TransitionToTheLevel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllTransitionsToTheLevel";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transitions.Add(new TransitionToTheLevel()
                        {
                            Id = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel level = new EnglishLevel()
                        {
                            Id = reader.GetInt32("LevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var transition = transitions.FirstOrDefault(x => x.Id == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.LevelNew = level;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            Id = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };

                        var transition = transitions.FirstOrDefault(x => x.Id == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.Student = student;
                        }
                    }
                }
            }
            return transitions;
        }

        public TransitionToTheLevel GetById(int entityId)
        {
            TransitionToTheLevel transition = new TransitionToTheLevel();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectTransitionToTheLevelById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transition.Id = reader.GetInt32("Id");
                        transition.Date = reader.GetDateTime("Date");
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        transition.LevelNew = new EnglishLevel()
                        {
                            Id = reader.GetInt32("LevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        transition.Student = new Student()
                        {
                            Id = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };
                    }
                }
            }
            return transition;
        }

        public IEnumerable<TransitionToTheLevel> GetTransitionToTheLevelsByLevel(int levelId)
        {
            List<TransitionToTheLevel> transitions = new List<TransitionToTheLevel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectTransitionsToTheLevelByLevel";
                cmd.Parameters.AddWithValue("LevelId", levelId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transitions.Add(new TransitionToTheLevel()
                        {
                            Id = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel level = new EnglishLevel()
                        {
                            Id = reader.GetInt32("LevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var transition = transitions.FirstOrDefault(x => x.Id == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.LevelNew = level;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            Id = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };

                        var transition = transitions.FirstOrDefault(x => x.Id == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.Student = student;
                        }
                    }
                }
            }
            return transitions;
        }

        public IEnumerable<TransitionToTheLevel> SortedTransitionToTheLevelsByDate()
        {
            List<TransitionToTheLevel> transitions = new List<TransitionToTheLevel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SortTransitionsToTheLevelByDate";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transitions.Add(new TransitionToTheLevel()
                        {
                            Id = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel level = new EnglishLevel()
                        {
                            Id = reader.GetInt32("LevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var transition = transitions.FirstOrDefault(x => x.Id == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.LevelNew = level;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            Id = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };

                        var transition = transitions.FirstOrDefault(x => x.Id == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.Student = student;
                        }
                    }
                }
            }
            return transitions;
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

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
