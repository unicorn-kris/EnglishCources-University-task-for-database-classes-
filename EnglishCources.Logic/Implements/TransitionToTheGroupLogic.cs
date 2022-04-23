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
            return _transitionToTheGroupRepository.Add(entity);
        }

        public int Delete(int entityId)
        {
            return _transitionToTheGroupRepository.Delete(entityId);
        }

        public IEnumerable<TransitionToTheGroup> GetAll()
        {
            return _transitionToTheGroupRepository.GetAll();
        }

        public TransitionToTheGroup GetById(int entityId)
        {
            return _transitionToTheGroupRepository.GetById(entityId);
        }

        public IEnumerable<TransitionToTheGroup> GetTransitionToTheGroupsByGroup(int groupId)
        {
            return _transitionToTheGroupRepository.GetTransitionToTheGroupsByGroup(groupId);
        }

        public IEnumerable<TransitionToTheGroup> SortedTransitionToTheGroupsByDate()
        {
            return _transitionToTheGroupRepository.SortedTransitionToTheGroupsByDate();
        }

        public void Update(int entityId, TransitionToTheGroup newEntity)
        {
            _transitionToTheGroupRepository.Update(entityId, newEntity);
        }
    }
}
