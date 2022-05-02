using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface IBookLogic : IEntityLogic<Book>
    {
        IEnumerable<Book> GetBooksByLevel(int englishLevel);
    }
}
