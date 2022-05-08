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

        public void Delete(int entityId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteTransitionToTheGroup";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<TransitionToTheGroup> GetAll()
        {
            List<TransitionToTheGroup> transitions = new List<TransitionToTheGroup>();
            
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllTransitionsToTheGroup";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transitions.Add(new TransitionToTheGroup()
                        {
                            ID = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var transition = transitions.FirstOrDefault(x => x.ID == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.GroupNew = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };

                        var transition = transitions.FirstOrDefault(x => x.ID == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.Student = student;
                        }
                    }
                }
            }
            return transitions;
        }

        public TransitionToTheGroup GetById(int entityId)
        {
            TransitionToTheGroup transition = new TransitionToTheGroup();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectTransitionToTheGroupById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transition.ID = reader.GetInt32("Id");
                        transition.Date = reader.GetDateTime("Date");
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        transition.GroupNew = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        transition.Student = new Student()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };
                    }
                }
            }
            return transition;
        }

        public IEnumerable<TransitionToTheGroup> GetTransitionToTheGroupsByGroup(int groupId)
        {
            List<TransitionToTheGroup> transitions = new List<TransitionToTheGroup>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectTransitionsToTheGroupByGroup";
                cmd.Parameters.AddWithValue("GroupId", groupId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transitions.Add(new TransitionToTheGroup()
                        {
                            ID = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var transition = transitions.FirstOrDefault(x => x.ID == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.GroupNew = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };

                        var transition = transitions.FirstOrDefault(x => x.ID == reader.GetInt32("TransitionId"));

                        if (transition != null)
                        {
                            transition.Student = student;
                        }
                    }
                }
            }
            return transitions;
        }

        public IEnumerable<TransitionToTheGroup> SortedTransitionToTheGroupsByDate()
        {
            List<TransitionToTheGroup> transitions = new List<TransitionToTheGroup>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SortTransitionsToTheGroupByDate";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transitions.Add(new TransitionToTheGroup()
                        {
                            ID = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var exRes = transitions.FirstOrDefault(x => x.ID == reader.GetInt32("TransitionId"));

                        if (exRes != null)
                        {
                            exRes.GroupNew = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };

                        var exRes = transitions.FirstOrDefault(x => x.ID == reader.GetInt32("TransitionId"));

                        if (exRes != null)
                        {
                            exRes.Student = student;
                        }
                    }
                }
            }
            return transitions;
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

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
