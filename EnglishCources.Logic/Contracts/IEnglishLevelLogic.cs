using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface IEnglishLevelLogic: IEntityLogic<EnglishLevel>
    {
        IEnumerable<EnglishLevel> SortedEnglishLevels();
    }
}
