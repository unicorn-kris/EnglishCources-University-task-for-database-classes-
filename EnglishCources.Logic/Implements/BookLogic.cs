using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Repository.Contracts;

namespace EnglishCources.Logic.Implements
{
    internal class BookLogic : IBookLogic
    {
        private IBookRepository _bookRepository;

        public BookLogic(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public int Add(Book entity)
        {
            return _bookRepository.Add(entity);
        }

        public int Delete(int entityId)
        {
            return _bookRepository.Delete(entityId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookByLevel(int englishLevel)
        {
            return _bookRepository.GetBookByLevel(englishLevel);
        }

        public Book GetById(int entityId)
        {
            return _bookRepository.GetById(entityId);
        }

        public void Update(int entityId, Book newEntity)
        {
            _bookRepository.Update(entityId, newEntity);
        }
    }
}
