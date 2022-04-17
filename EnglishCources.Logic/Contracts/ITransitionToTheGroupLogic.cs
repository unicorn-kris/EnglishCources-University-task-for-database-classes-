using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface ITransitionToTheGroupLogic: IEntityLogic<TransitionToTheGroup>
    {
        IEnumerable<TransitionToTheGroup> GetTransitionToTheGroupsByGroup(int groupId);
        IEnumerable<TransitionToTheGroup> SortedTransitionToTheGroupsByDate();
    }
}
