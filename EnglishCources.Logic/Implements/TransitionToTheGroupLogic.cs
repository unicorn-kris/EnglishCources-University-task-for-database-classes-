using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class TransitionToTheGroupLogic : ITransitionToTheGroupLogic
    {
        private ITransitionToTheGroupRepository _transitionToTheGroupRepository;

        public TransitionToTheGroupLogic(ITransitionToTheGroupRepository transitionToTheGroupRepository)
        {
            _transitionToTheGroupRepository = transitionToTheGroupRepository;
        }

        public int Add(TransitionToTheGroup entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransitionToTheGroup GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheGroup> GetTransitionToTheGroupsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransitionToTheGroup> SortedTransitionToTheGroupsByDate()
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, TransitionToTheGroup newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
