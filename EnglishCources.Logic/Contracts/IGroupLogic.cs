using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface IGroupLogic: IEntityLogic<Group>
    {
        Group GetGroupByNumber(int groupNumber);
        IEnumerable<Group> GetGroupsByLevel(int englishLevel);
    }
}
