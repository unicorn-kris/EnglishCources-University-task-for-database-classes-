using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace EnglishCources.Presentation.ViewModels
{
    internal class ExamWindowViewModel : NotifyPropertyChangedBase, IWindowViewModel
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

        public ExamWindowViewModel(IExamLogic examLogic, IGroupLogic groupLogic, int entityId)
        {
            _examLogic = examLogic;

            try
            {
                Exam exam = _examLogic.GetById(entityId);

                Group = exam.Group;
                Date = exam.Date;

                Groups = (ObservableCollection<Group>)groupLogic.GetAll();
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
                Groups = (ObservableCollection<Group>)groupLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void SaveCommand()
        {
            Exam exam = new Exam();

            exam.Group = Group;
            exam.Date = Date;

            if (_entityId != null)
            {
                _examLogic.Update((int)_entityId, exam);
            }
            else
            {
                int res = _examLogic.Add(exam);
            }
        }
    }
}