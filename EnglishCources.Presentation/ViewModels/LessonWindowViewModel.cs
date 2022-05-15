using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class LessonWindowViewModel : NotifyPropertyChangedBase
    {
        private Group _group;

        private DateTime _day;

        private int _hour;

        private Book _book;

        public ObservableCollection<Group> Groups { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        public Group Group
        {
            get => _group;

            set => OnPropertyChanged(value, ref _group);
        }

        public DateTime Day
        {
            get => _day;

            set => OnPropertyChanged(value, ref _day);
        }

        public int Hour
        {
            get => _hour;
            set => OnPropertyChanged(value, ref _hour);
        }

        public Book Book
        {
            get => _book;
            set => OnPropertyChanged(value, ref _book);
        }

        private ILessonLogic _lessonLogic;

        private int? _entityId;

        public ICommand _saveCommand => new RelayCommand(SaveCommand);

        public LessonWindowViewModel(ILessonLogic lessonLogic, IGroupLogic groupLogic, IBookLogic bookLogic, int entityId)
        {
            _entityId = entityId;
            _lessonLogic = lessonLogic;

            try
            {
                Lesson lesson = _lessonLogic.GetById(entityId);

                Group = lesson.Group;
                Day = lesson.Day;
                Hour = lesson.Hour;
                Book = lesson.Book;

                Groups = (ObservableCollection<Group>)groupLogic.GetAll();
                Books = (ObservableCollection<Book>)bookLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public LessonWindowViewModel(ILessonLogic lessonLogic, IGroupLogic groupLogic, IBookLogic bookLogic)
        {
            _entityId = null;
            _lessonLogic = lessonLogic;

            try
            {
                Groups = (ObservableCollection<Group>)groupLogic.GetAll();
                Books = (ObservableCollection<Book>)bookLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void SaveCommand(object? obj)
        {
            Lesson lesson = new Lesson();

            lesson.Hour = Hour;
            lesson.Day = Day;
            lesson.Book = Book;
            lesson.Group = Group;

            if (_entityId != null)
            {
                _lessonLogic.Update((int)_entityId, lesson);
            }
            else
            {
                int res = _lessonLogic.Add(lesson);
            }
        }
    }
}
