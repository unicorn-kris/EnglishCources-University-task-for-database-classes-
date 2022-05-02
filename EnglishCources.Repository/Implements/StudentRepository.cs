using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Student entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddStudent";
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Surname", entity.Surname);
                cmd.Parameters.AddWithValue("EnglishLevel", entity.EnglishLevel);
                cmd.Parameters.AddWithValue("GroupNumber", entity.GroupNumber);

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
                cmd.CommandText = "DeleteStudent";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllStudents";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student()
                        {
                            ID = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("SurName")
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

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.GroupNumber = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel englishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.GroupNumber.MinLevel = englishLevel;
                        }
                    }

                    while (reader.Read())
                    {
                        EnglishLevel englishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.EnglishLevel = englishLevel;
                        }
                    }
                }
            }
            return students;
        }

        public Student GetById(int entityId)
        {

            Student student = new Student();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectStudentById";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        student.ID = reader.GetInt32("Id");
                        student.Name = reader.GetString("Name");
                        student.Surname = reader.GetString("SurName");
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        student.GroupNumber = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        student.GroupNumber.MinLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };
                    }

                    while (reader.Read())
                    {
                        student.EnglishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };
                    }
                }
            }
            return student;
        }

        public IEnumerable<Student> GetStudentsByGroup(int groupId)
        {
            List<Student> students = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectStudentsByGroup";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student()
                        {
                            ID = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("SurName")
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

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.GroupNumber = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel englishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.GroupNumber.MinLevel = englishLevel;
                        }
                    }

                    while (reader.Read())
                    {
                        EnglishLevel englishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.EnglishLevel = englishLevel;
                        }
                    }
                }
            }
            return students;
        }

        public IEnumerable<Student> GetStudentsByLevel(int levelId)
        {
            List<Student> students = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectStudentsByLevel";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student()
                        {
                            ID = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("SurName")
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

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.GroupNumber = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel englishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.GroupNumber.MinLevel = englishLevel;
                        }
                    }

                    while (reader.Read())
                    {
                        EnglishLevel englishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                        var student = students.FirstOrDefault(x => x.ID == reader.GetInt32("StudentId"));

                        if (student != null)
                        {
                            student.EnglishLevel = englishLevel;
                        }
                    }
                }
            }
            return students;
        }

        public void Update(int entityId, Student newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateStudent";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Name", newEntity.Name);
                cmd.Parameters.AddWithValue("Surname", newEntity.Surname);
                cmd.Parameters.AddWithValue("EnglishLevel", newEntity.EnglishLevel);
                cmd.Parameters.AddWithValue("GroupNumber", newEntity.GroupNumber);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
