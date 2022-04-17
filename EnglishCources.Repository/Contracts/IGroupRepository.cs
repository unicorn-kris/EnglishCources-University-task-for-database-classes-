using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface IGroupRepository: IEntityRepository<Group>
    {
        Group GetGroupByNumber(int groupNumber);
        IEnumerable<Group> GetGroupsByLevel(int englishLevel);
    }
}
