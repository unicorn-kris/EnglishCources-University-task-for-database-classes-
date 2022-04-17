using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface IBookLogic: IEntityLogic<Book>
    {
        Book GetBookByLevel(int englishLevel);
    }
}
