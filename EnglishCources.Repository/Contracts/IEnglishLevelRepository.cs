using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface IEnglishLevelRepository: IEntityRepository<EnglishLevel>
    {
        IEnumerable<EnglishLevel> SortedEnglishLevels();
    }
}
