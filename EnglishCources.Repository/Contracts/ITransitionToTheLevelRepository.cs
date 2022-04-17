using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface ITransitionToTheLevelRepository: IEntityRepository<TransitionToTheLevel>
    {
        IEnumerable<TransitionToTheLevel> GetTransitionToTheLevelsByLevel(int groupId);
        IEnumerable<TransitionToTheLevel> SortedTransitionToTheLevelsByDate();
    }
}
