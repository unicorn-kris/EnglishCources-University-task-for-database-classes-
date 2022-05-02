using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface IBookRepository : IEntityRepository<Book>
    {
        IEnumerable<Book> GetBooksByLevel(int englishLevel);
    }
}
