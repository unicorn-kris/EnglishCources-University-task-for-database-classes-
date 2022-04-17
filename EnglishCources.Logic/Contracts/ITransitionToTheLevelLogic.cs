using EnglishCources.Common;

namespace EnglishCources.Logic.Contracts
{
    public interface ITransitionToTheLevelLogic: IEntityLogic<TransitionToTheLevel>
    {
        IEnumerable<TransitionToTheLevel> GetTransitionToTheLevelsByLevel(int groupId);
        IEnumerable<TransitionToTheLevel> SortedTransitionToTheLevelsByDate();
    }
}
