using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class LessonRepository : ILessonRepository
    {
        private readonly string _connectionString;

        public LessonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Lesson entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddLesson";
                cmd.Parameters.AddWithValue("Book", entity.Book.Id);
                cmd.Parameters.AddWithValue("Day", entity.Day);
                cmd.Parameters.AddWithValue("Hour", entity.Hour);
                cmd.Parameters.AddWithValue("Group", entity.Group.Id);

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
                cmd.CommandText = "DeleteLesson";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<Lesson> GetAll()
        {
            List<Lesson> lessons = new List<Lesson>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllLessons";

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lessons.Add(new Lesson()
                        {
                            Id = reader.GetInt32("Id"),
                            Day = reader.GetDateTime("Day"),
                            Hour = reader.GetInt32("Hour")
                        });

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            Id = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.Id == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Id = reader.GetInt32("BookId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.Id == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book = book;
                        }
                    }
                }
            }
            return lessons;
        }

        public Lesson GetById(int entityId)
        {

            Lesson lesson = new Lesson();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLessonById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lesson.Id = reader.GetInt32("Id");
                        lesson.Day = reader.GetDateTime("Day");
                        lesson.Hour = reader.GetInt32("Hour");

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        lesson.Group = new Group()
                        {
                            Id = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        lesson.Book = new Book()
                        {
                            Id = reader.GetInt32("BookId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                    }

                }
            }
            return lesson;
        }

        public IEnumerable<Lesson> GetLessonsByDate(DateTime date)
        {
            List<Lesson> lessons = new List<Lesson>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLessonsByDate";
                cmd.Parameters.AddWithValue("Date", date);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lessons.Add(new Lesson()
                        {
                            Id = reader.GetInt32("Id"),
                            Day = reader.GetDateTime("Day"),
                            Hour = reader.GetInt32("Hour")
                        });

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            Id = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.Id == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Id = reader.GetInt32("BookId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.Id == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book = book;
                        }
                    }

                }
            }
            return lessons;
        }

        public IEnumerable<Lesson> GetLessonsByGroup(int groupId)
        {
            List<Lesson> lessons = new List<Lesson>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLessonsByGroup";
                cmd.Parameters.AddWithValue("GroupId", groupId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lessons.Add(new Lesson()
                        {
                            Id = reader.GetInt32("Id"),
                            Day = reader.GetDateTime("Day"),
                            Hour = reader.GetInt32("Hour")
                        });

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Group group = new Group()
                        {
                            Id = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.Id == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group = group;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Id = reader.GetInt32("BookId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.Id == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book = book;
                        }
                    }
                }
            }
            return lessons;
        }

        public void Update(int entityId, Lesson newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateLesson";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Book", newEntity.Book);
                cmd.Parameters.AddWithValue("Day", newEntity.Day);
                cmd.Parameters.AddWithValue("Hour", newEntity.Hour);
                cmd.Parameters.AddWithValue("Group", newEntity.Group);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
