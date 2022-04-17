using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class EnglishLevelLogic : IEnglishLevelLogic
    {
        private IEnglishLevelRepository _englishLevelRepository;

        public EnglishLevelLogic(IEnglishLevelRepository englishLevelRepository)
        {
            _englishLevelRepository = englishLevelRepository;
        }

        public int Add(EnglishLevel entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnglishLevel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EnglishLevel GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnglishLevel> SortedEnglishLevels()
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, EnglishLevel newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
