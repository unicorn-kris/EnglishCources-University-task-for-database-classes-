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
                cmd.Parameters.AddWithValue("Book", entity.Book);
                cmd.Parameters.AddWithValue("Day", entity.Day);
                cmd.Parameters.AddWithValue("Hour", entity.Hour);
                cmd.Parameters.AddWithValue("Group", entity.Group);

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
                cmd.CommandText = "DeleteLesson";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() != 1)
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
                            ID = reader.GetInt32("Id"),
                            Day = reader.GetDateTime("Day"),
                            Hour = reader.GetInt32("Hour")
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group = group;
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group.MinLevel = englishLevel;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book = book;
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book.EnglishLevel = englishLevel;
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

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lesson.ID = reader.GetInt32("Id");
                        lesson.Day = reader.GetDateTime("Day");
                        lesson.Hour = reader.GetInt32("Hour");

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        lesson.Group = new Group()
                        {
                            ID = reader.GetInt32("GroupId"),
                            Number = reader.GetInt32("Number")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        lesson.Group.MinLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        lesson.Book = new Book()
                        {
                            ID = reader.GetInt32("BookId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        lesson.Book.EnglishLevel = new EnglishLevel()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Number = reader.GetInt32("Number"),
                            Letter = reader.GetString("Letter")
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

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lessons.Add(new Lesson()
                        {
                            ID = reader.GetInt32("Id"),
                            Day = reader.GetDateTime("Day"),
                            Hour = reader.GetInt32("Hour")
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group = group;
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group.MinLevel = englishLevel;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book = book;
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book.EnglishLevel = englishLevel;
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

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lessons.Add(new Lesson()
                        {
                            ID = reader.GetInt32("Id"),
                            Day = reader.GetDateTime("Day"),
                            Hour = reader.GetInt32("Hour")
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group = group;
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Group.MinLevel = englishLevel;
                        }
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            ID = reader.GetInt32("EnglishLevelId"),
                            Author = reader.GetString("Author"),
                            Title = reader.GetString("Title")
                        };

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book = book;
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

                        var lesson = lessons.FirstOrDefault(x => x.ID == reader.GetInt32("LessonId"));

                        if (lesson != null)
                        {
                            lesson.Book.EnglishLevel = englishLevel;
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

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
