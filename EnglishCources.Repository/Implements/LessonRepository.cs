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

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lesson> GetAll()
        {
            throw new NotImplementedException();
        }

        public Lesson GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lesson> GetLessonsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lesson> GetLessonsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, Lesson newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
