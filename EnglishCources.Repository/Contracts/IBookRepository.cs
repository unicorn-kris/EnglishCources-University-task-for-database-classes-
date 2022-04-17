using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface IBookRepository: IEntityRepository<Book>
    {
        Book GetBookByLevel(int englishLevel);
    }
}
