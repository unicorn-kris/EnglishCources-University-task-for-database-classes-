using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class ExamRepository : IExamRepository
    {
        private readonly string _connectionString;

        public ExamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Exam entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddExam";
                cmd.Parameters.AddWithValue("Group", entity.Group);
                cmd.Parameters.AddWithValue("Date", entity.Date);

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
                cmd.CommandText = "DeleteExam";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<Exam> GetAll()
        {
            List<Exam> exams = new List<Exam>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllExams";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam()
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

                        Exam exam = exams.FirstOrDefault(x => x.ID == reader.GetInt32("ExamId"));

                        if (exam != null)
                        {
                            exam.Group = group;
                        }
                    }
                }
            }
            return exams;
        }

        public Exam GetById(int entityId)
        {
            Exam exam = new Exam();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectExamById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam.ID = reader.GetInt32("Id");
                        exam.Date = reader.GetDateTime("Date");
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        exam.Group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        exam.Group.MinLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };
                    }

                    //reader.NextResult();

                    //while (reader.Read())
                    //{
                    //    exam.Group.Teacher = new Teacher()
                    //    {
                    //        ID = reader.GetInt32("GroupId"),
                    //        Name = reader.GetString("Name"),
                    //        Surname = reader.GetString("Surname"),
                    //        Age = reader.GetInt32("Age"),
                    //        Experience = reader.GetInt32("Experience")
                    //    };
                    //}

                }
            }
            return exam;
        }

        public IEnumerable<Exam> GetExamsByDay(DateTime day)
        {
            List<Exam> exams = new List<Exam>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectExamsByDay";
                cmd.Parameters.AddWithValue("Day", day);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam()
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

                        Exam exam = exams.FirstOrDefault(x => x.ID == reader.GetInt32("ExamId"));

                        if (exam != null)
                        {
                            exam.Group = group;
                        }
                    }
                }
            }
            return exams;
        }

        public IEnumerable<Exam> GetExamsByGroup(int groupId)
        {
            List<Exam> exams = new List<Exam>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectExamsByGroup";
                cmd.Parameters.AddWithValue("GroupId", groupId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam()
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

                        Exam exam = exams.FirstOrDefault(x => x.ID == reader.GetInt32("ExamId"));

                        if (exam != null)
                        {
                            exam.Group = group;
                        }
                    }
                }
            }
            return exams;
        }

        public void Update(int entityId, Exam newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExam";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Group", newEntity.Group);
                cmd.Parameters.AddWithValue("Date", newEntity.Date);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
