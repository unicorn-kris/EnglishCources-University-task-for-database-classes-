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
            List<Group> groups = new List<Group>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllGroups";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groups.Add(new Group()
                        {
                            ID = reader.GetInt32("Id"),
                            Number = reader.GetInt32("Number")
                        });
                        
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Teacher teacher = new Teacher()
                        {
                            ID = reader.GetInt32("TeacherId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname"),
                            Age = reader.GetInt32("Age"),
                            Experience = reader.GetInt32("Experience")
                        };

                        Group group = groups.FirstOrDefault(x => x.ID == reader.GetInt32("GroupId"));

                        if (group != null)
                        {
                            group.Teacher = teacher;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel englishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Letter = reader.GetString("Letter"),
                            Number = reader.GetInt32("Number")
                        };

                        Group group = groups.FirstOrDefault(x => x.ID == reader.GetInt32("GroupId"));

                        if (group != null)
                        {
                            group.MinLevel = englishLevel;
                        }
                    }
                }
            }
            return groups;
        }

        public Group GetById(int entityId)
        {
            Group group = new Group();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectGroupById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        group.ID = reader.GetInt32("Id");
                        group.Number = reader.GetInt32("Number");
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                         group.Teacher = new Teacher()
                        {
                            ID = reader.GetInt32("TeacherId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname"),
                            Age = reader.GetInt32("Age"),
                            Experience = reader.GetInt32("Experience")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        group.MinLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Letter = reader.GetString("Letter"),
                            Number = reader.GetInt32("Number")
                        };

                    }
                }
            }
            return group;
        }

        public Group GetGroupByNumber(int groupNumber)
        {
            Group group = new Group();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectGroupByNumber";
                cmd.Parameters.AddWithValue("Number", groupNumber);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        group.ID = reader.GetInt32("Id");
                        group.Number = reader.GetInt32("Number");
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        group.Teacher = new Teacher()
                        {
                            ID = reader.GetInt32("TeacherId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname"),
                            Age = reader.GetInt32("Age"),
                            Experience = reader.GetInt32("Experience")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        group.MinLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Letter = reader.GetString("Letter"),
                            Number = reader.GetInt32("Number")
                        };

                    }
                }
            }
            return group;
        }

        public IEnumerable<Group> GetGroupsByLevel(int englishLevel)
        {
            List<Group> groups = new List<Group>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectGroupsByLevel";
                cmd.Parameters.AddWithValue("EnglishLevel", englishLevel);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groups.Add(new Group()
                        {
                            ID = reader.GetInt32("Id"),
                            Number = reader.GetInt32("Number")
                        });

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Teacher teacher = new Teacher()
                        {
                            ID = reader.GetInt32("TeacherId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname"),
                            Age = reader.GetInt32("Age"),
                            Experience = reader.GetInt32("Experience")
                        };

                        Group group = groups.FirstOrDefault(x => x.ID == reader.GetInt32("GroupId"));

                        if (group != null)
                        {
                            group.Teacher = teacher;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel englishLevelAdded = new EnglishLevel()
                        {
                            ID = englishLevel,
                            Letter = reader.GetString("Letter"),
                            Number = reader.GetInt32("Number")
                        };

                        Group group = groups.FirstOrDefault(x => x.ID == reader.GetInt32("GroupId"));

                        if (group != null)
                        {
                            group.MinLevel = englishLevelAdded;
                        }
                    }
                }
            }
            return groups;
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
