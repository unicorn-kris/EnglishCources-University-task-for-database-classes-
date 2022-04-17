using EnglishCources.Common;

namespace EnglishCources.Repository.Contracts
{
    public interface ITransitionToTheGroupRepository: IEntityRepository<TransitionToTheGroup>
    {
        IEnumerable<TransitionToTheGroup> GetTransitionToTheGroupsByGroup(int groupId);
        IEnumerable<TransitionToTheGroup> SortedTransitionToTheGroupsByDate();
    }
}
