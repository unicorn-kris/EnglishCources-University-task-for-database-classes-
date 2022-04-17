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
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Group GetGroupByNumber(int groupNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetGroupsByLevel(int englishLevel)
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, Group newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
