using EnglishCources.Common;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace EnglishCources.Repository.Implements
{
    internal class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Book entity)
        {
            var addedEntityId = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddBook";
                cmd.Parameters.AddWithValue("Title", entity.Title);
                cmd.Parameters.AddWithValue("Author", entity.Author);
                cmd.Parameters.AddWithValue("EnglishLevel", entity.EnglishLevel);

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
                cmd.CommandText = "DeleteBook";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }

        public IEnumerable<Book> GetAll()
        {
            List<Book> books = new List<Book>();

            using(var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllBooks";
                
                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book() { ID = (int)reader["Id"],
                        Author = reader["Author"].ToString(),
                        Title = reader["Title"].ToString()});
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel level = new EnglishLevel();

                        level.ID = (int)reader["Id"];
                        level.Number = (int)reader["Number"];
                        level.Letter = (string)reader["Letter"];
                        int bookId = (int)reader["BookId"];

                        Book book = books.FirstOrDefault(b => b.ID == bookId);

                        if (book != null)
                        {
                            book.EnglishLevel = level;
                        }
                    }
                }
            }
            return books;
        }

        public IEnumerable<Book> GetBooksByLevel(int englishLevel)
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectBooksByLevel";
                cmd.Parameters.AddWithValue("EnglishLevel", englishLevel);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book()
                        {
                            ID = (int)reader["Id"],
                            Author = reader["Author"].ToString(),
                            Title = reader["Title"].ToString()
                        });
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel level = new EnglishLevel();

                        level.ID = (int)reader["Id"];
                        level.Number = (int)reader["Number"];
                        level.Letter = (string)reader["Letter"];
                        int bookId = (int)reader["BookId"];

                        Book book = books.FirstOrDefault(b => b.ID == bookId);

                        if (book != null)
                        {
                            book.EnglishLevel = level;
                        }
                    }
                }
            }
            return books;
        }

        public Book GetById(int entityId)
        {
            Book book = new Book();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectBookById";
                cmd.Parameters.AddWithValue("Id", entityId);

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        book.ID = (int)reader["Id"];
                        book.Author = reader["Author"].ToString();
                        book.Title = reader["Title"].ToString();
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        EnglishLevel level = new EnglishLevel();

                        level.ID = (int)reader["Id"];
                        level.Number = (int)reader["Number"];
                        level.Letter = (string)reader["Letter"];

                        book.EnglishLevel = level;
                    }
                }
            }
            return book;
        }

        public void Update(int entityId, Book newEntity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateBook";
                cmd.Parameters.AddWithValue("Id", entityId);
                cmd.Parameters.AddWithValue("Title", newEntity.Title);
                cmd.Parameters.AddWithValue("Author", newEntity.Author);
                cmd.Parameters.AddWithValue("EnglishLevel", newEntity.EnglishLevel);

                connection.Open();

                if (cmd.ExecuteNonQuery() < 1)
                {
                    throw new IncorrectIdException();
                }
            }
        }
    }
}
