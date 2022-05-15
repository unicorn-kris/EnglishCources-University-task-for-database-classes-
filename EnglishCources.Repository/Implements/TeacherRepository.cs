using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class TeacherRepository : ITeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Teacher entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddTeacher";
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Surname", entity.Surname);
                cmd.Parameters.AddWithValue("Age", entity.Age);
                cmd.Parameters.AddWithValue("Experience", entity.Experience);

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
                cmd.CommandText = "DeleteTeacher";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllTeachers";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teachers.Add(new Teacher()
                        {
                            ID = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname"),
                            Age = reader.GetInt32("Age"),
                            Experience = reader.GetInt32("Experience")
                        });

                    }

                }
            }
            return teachers;
        }

        public Teacher GetById(int entityId)
        {
            Teacher teacher = new Teacher();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectTeacherById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teacher.ID = reader.GetInt32("Id");
                        teacher.Name = reader.GetString("Name");
                        teacher.Surname = reader.GetString("Surname");
                        teacher.Age = reader.GetInt32("Age");
                        teacher.Experience = reader.GetInt32("Experience");
                    }

                }
            }
            return teacher;
        }

        public IEnumerable<Teacher> SortedTeachersByExperience()
        {
            List<Teacher> teachers = new List<Teacher>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SortTeachersByExperience";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teachers.Add(new Teacher()
                        {
                            ID = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname"),
                            Age = reader.GetInt32("Age"),
                            Experience = reader.GetInt32("Experience")
                        });

                    }

                }
            }
            return teachers;
        }

        public void Update(int entityId, Teacher newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateTeacher";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Name", newEntity.Name);
                cmd.Parameters.AddWithValue("Surname", newEntity.Surname);
                cmd.Parameters.AddWithValue("Age", newEntity.Age);
                cmd.Parameters.AddWithValue("Experience", newEntity.Experience);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
