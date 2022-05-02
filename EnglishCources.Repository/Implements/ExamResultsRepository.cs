using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class ExamResultsRepository : IExamResultsRepository
    {
        private readonly string _connectionString;

        public ExamResultsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(ExamResults entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddExamResults";
                cmd.Parameters.AddWithValue("Student", entity.Student);
                cmd.Parameters.AddWithValue("Exam", entity.Exam);
                cmd.Parameters.AddWithValue("Mark", entity.Mark);

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
                cmd.CommandText = "DeleteExamResults";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<ExamResults> GetAll()
        {
            List<ExamResults> examsRes = new List<ExamResults>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllExamResults";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        examsRes.Add(new ExamResults()
                        {
                            ID = reader.GetInt32("Id"),
                            Mark = reader.GetInt32("Mark")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Exam exam = new Exam()
                        {
                            ID = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        };

                        var exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));
                        
                        if (exRes != null)
                        {
                            exRes.Exam = exam;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Exam.Group = group;
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

                        ExamResults exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Student = student;
                        }
                    }
                }
            }
            return examsRes;
        }

        public ExamResults GetById(int entityId)
        {
            ExamResults examResult = new ExamResults();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectExamResultsById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        examResult.ID = reader.GetInt32("Id");
                        examResult.Mark = reader.GetInt32("Mark");
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        examResult.Exam = new Exam()
                        {
                            ID = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        };

                        
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        examResult.Exam.Group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        examResult.Student = new Student()
                        {
                            ID = reader.GetInt32("StudentId"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname")
                        };

                    }
                }
            }
            return examResult;
        }

        public IEnumerable<ExamResults> GetExamResultsByMark(int mark)
        {
            List<ExamResults> examsRes = new List<ExamResults>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectExamResultsByMark";
                cmd.Parameters.AddWithValue("Mark", mark);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        examsRes.Add(new ExamResults()
                        {
                            ID = reader.GetInt32("Id"),
                            Mark = reader.GetInt32("Mark")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {

                        Exam exam = new Exam()
                        {
                            ID = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        };

                        var exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Exam = exam;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Exam.Group = group;
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

                        ExamResults exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Student = student;
                        }
                    }
                }
            }
            return examsRes;
        }

        public IEnumerable<ExamResults> GetExamResultsByStudent(int studentId)
        {
            List<ExamResults> examsRes = new List<ExamResults>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectExamResultsByStudent";
                cmd.Parameters.AddWithValue("StudentId", studentId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        examsRes.Add(new ExamResults()
                        {
                            ID = reader.GetInt32("Id"),
                            Mark = reader.GetInt32("Mark")
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {

                        Exam exam = new Exam()
                        {
                            ID = reader.GetInt32("Id"),
                            Date = reader.GetDateTime("Date")
                        };

                        var exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Exam = exam;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Exam.Group = group;
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

                        ExamResults exRes = examsRes.FirstOrDefault(x => x.ID == reader.GetInt32("ExamResultsId"));

                        if (exRes != null)
                        {
                            exRes.Student = student;
                        }
                    }
                }
            }
            return examsRes;
        }

        public void Update(int entityId, ExamResults newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExamResults";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Student", newEntity.Student);
                cmd.Parameters.AddWithValue("Exam", newEntity.Exam);
                cmd.Parameters.AddWithValue("Mark", newEntity.Mark);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
