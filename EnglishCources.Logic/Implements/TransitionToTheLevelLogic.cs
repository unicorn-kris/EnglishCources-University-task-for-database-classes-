using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class TransitionToTheLevelLogic : ITransitionToTheLevelLogic
    {
        private ITransitionToTheLevelRepository _transitionToTheLevelRepository;

        public TransitionToTheLevelLogic(ITransitionToTheLevelRepository transitionToTheLevelRepository)
        {
            _transitionToTheLevelRepository = transitionToTheLevelRepository;
        }

        public int Add(TransitionToTheLevel entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheLevel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransitionToTheLevel GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheLevel> GetTransitionToTheLevelsByLevel(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheLevel> SortedTransitionToTheLevelsByDate()
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, TransitionToTheLevel newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
