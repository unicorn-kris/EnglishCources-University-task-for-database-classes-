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
            throw new NotImplementedException();
        }

        public int Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetBookByLevel(int englishLevel)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public int Update(int entityId, Book newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
