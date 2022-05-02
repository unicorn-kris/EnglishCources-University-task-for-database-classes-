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

        public void Delete(int entityId)
        {
            _bookRepository.Delete(entityId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public IEnumerable<Book> GetBooksByLevel(int englishLevel)
        {
            return _bookRepository.GetBooksByLevel(englishLevel);
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
