using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class GroupLogic : IGroupLogic
    {
        private IGroupRepository _groupRepository;

        public GroupLogic(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public int Add(Group entity)
        {
            return _groupRepository.Add(entity);   
        }

        public int Delete(int entityId)
        {
            return _groupRepository.Delete(entityId);
        }

        public IEnumerable<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group GetById(int entityId)
        {
            return _groupRepository.GetById(entityId);
        }

        public Group GetGroupByNumber(int groupNumber)
        {
            return _groupRepository.GetGroupByNumber(groupNumber);
        }

        public IEnumerable<Group> GetGroupsByLevel(int englishLevel)
        {
            return _groupRepository.GetGroupsByLevel(englishLevel);
        }

        public int Update(int entityId, Group newEntity)
        {
            return _groupRepository.Update(entityId, newEntity);
        }
    }
}
