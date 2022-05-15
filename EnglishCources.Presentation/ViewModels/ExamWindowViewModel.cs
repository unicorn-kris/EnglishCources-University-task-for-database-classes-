using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class ExamWindowViewModel : NotifyPropertyChangedBase
    {
        private Group _group;

        private DateTime _date;

        public Group Group
        {
            get => _group;

            set => OnPropertyChanged(value, ref _group);
        }

        public DateTime Date
        {
            get => _date;

            set => OnPropertyChanged(value, ref _date);
        }

        public ObservableCollection<Group> Groups { get; set; }


        private IExamLogic _examLogic;


        private int? _entityId;

        public ICommand SaveCommand => new RelayCommand(Save);

        public ExamWindowViewModel(IExamLogic examLogic, IGroupLogic groupLogic, int entityId)
        {
            _examLogic = examLogic;

            try
            {
                Exam exam = _examLogic.GetById(entityId);

                Group = exam.Group;
                Date = exam.Date;

                Groups = new ObservableCollection<Group>(groupLogic.GetAll());
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public ExamWindowViewModel(IExamLogic examLogic, IGroupLogic groupLogic)
        {
            _entityId = null;
            _examLogic = examLogic;

            try
            {
                Groups = new ObservableCollection<Group>(groupLogic.GetAll());
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void Save(object? obj)
        {
            Exam exam = new Exam();

            exam.Group = Group;
            exam.Date = Date;

            if (_entityId != null)
            {
                _examLogic.Update((int)_entityId, exam);
                ((Window)obj).Close();
            }
            else
            {
                int res = _examLogic.Add(exam);
                ((Window)obj).Close();
            }
        }
    }
}