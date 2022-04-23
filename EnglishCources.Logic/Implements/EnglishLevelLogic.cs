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
            return _englishLevelRepository.Add(entity);
        }

        public void Delete(int entityId)
        {
            _englishLevelRepository.Delete(entityId);
        }

        public IEnumerable<EnglishLevel> GetAll()
        {
            return _englishLevelRepository.GetAll();
        }

        public EnglishLevel GetById(int entityId)
        {
            return _englishLevelRepository.GetById(entityId);
        }

        public IEnumerable<EnglishLevel> SortedEnglishLevels()
        {
            return _englishLevelRepository.SortedEnglishLevels();
        }

        public void Update(int entityId, EnglishLevel newEntity)
        {
            _englishLevelRepository.Update(entityId, newEntity);
        }
    }
}
