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
            return _transitionToTheLevelRepository.Add(entity);
        }

        public int Delete(int entityId)
        {
            return _transitionToTheLevelRepository.Delete(entityId);
        }

        public IEnumerable<TransitionToTheLevel> GetAll()
        {
            return _transitionToTheLevelRepository.GetAll();
        }

        public TransitionToTheLevel GetById(int entityId)
        {
            return _transitionToTheLevelRepository.GetById(entityId);
        }

        public IEnumerable<TransitionToTheLevel> GetTransitionToTheLevelsByLevel(int groupId)
        {
            return _transitionToTheLevelRepository.GetTransitionToTheLevelsByLevel(groupId);
        }

        public IEnumerable<TransitionToTheLevel> SortedTransitionToTheLevelsByDate()
        {
            return _transitionToTheLevelRepository.SortedTransitionToTheLevelsByDate();
        }

        public void Update(int entityId, TransitionToTheLevel newEntity)
        {
            _transitionToTheLevelRepository.Update(entityId, newEntity); 
        }
    }
}
