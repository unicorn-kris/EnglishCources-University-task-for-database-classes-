using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class BookWindowViewModel : NotifyPropertyChangedBase
    {
        private string _title;

        private string _autor;

        private EnglishLevel _englishLevel;

        public string Title
        {
            get => _title;

            set => OnPropertyChanged(value, ref _title);
        }

        public string Author
        {
            get => _autor;

            set => OnPropertyChanged(value, ref _autor);
        }

        public EnglishLevel EnglishLevel
        {
            get => _englishLevel;

            set => OnPropertyChanged(value, ref _englishLevel);
        }

        public ObservableCollection<EnglishLevel> EnglishLevels { get; set; }

        public ICommand _saveCommand => new RelayCommand(SaveCommand);

        private IBookLogic _bookLogic;

        private int? _entityId;

        public BookWindowViewModel(IBookLogic bookLogic, IEnglishLevelLogic englishLevelLogic, int entityId)
        {

            _bookLogic = bookLogic; 
            try
            {
                Book book = _bookLogic.GetById(entityId);

                if (book != null)
                {
                    Title = book.Title;
                    Author = book.Author;
                    EnglishLevel = book.EnglishLevel;
                    _entityId = entityId;
                }

                EnglishLevels = (ObservableCollection<EnglishLevel>)englishLevelLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public BookWindowViewModel(IBookLogic bookLogic, IEnglishLevelLogic englishLevelLogic)
        {
            _entityId = null;
            _bookLogic = bookLogic;

            try
            {
                EnglishLevels = (ObservableCollection<EnglishLevel>)englishLevelLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void SaveCommand(object? obj)
        {
            Book newBook = new Book();

            newBook.Title = Title;
            newBook.Author = Author;
            newBook.EnglishLevel = EnglishLevel;

            if (_entityId != null)
            {
                _bookLogic.Update((int)_entityId, newBook);
            }
            else
            {
                int res = _bookLogic.Add(newBook);
            }
        }
    }
}
