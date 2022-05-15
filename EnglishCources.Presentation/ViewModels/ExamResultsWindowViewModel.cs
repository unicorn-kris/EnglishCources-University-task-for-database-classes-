using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class ExamResultsWindowViewModel : NotifyPropertyChangedBase
    {
        private Student _student;

        private Exam _exam;

        private int _mark;

        public Exam Exam
        {
            get => _exam;
            set => OnPropertyChanged(value, ref _exam);
        }

        public Student Student
        {
            get => _student;
            set => OnPropertyChanged(value, ref _student);
        }

        public int Mark
        {
            get => _mark;
            set => OnPropertyChanged(value, ref _mark);
        }

        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Exam> Exams { get; set; }


        private IExamResultsLogic _examResultsLogic;

        private int? _entityId;

        public ICommand SaveCommand => new RelayCommand(Save);

        public ExamResultsWindowViewModel(IExamResultsLogic examResultsLogic, IStudentLogic studentLogic, IExamLogic examLogic, int entityId)
        {
            _examResultsLogic = examResultsLogic;
            try
            {
                ExamResults examResults = _examResultsLogic.GetById(entityId);

                Student = examResults.Student;
                Mark = examResults.Mark;
                Exam = examResults.Exam;

                Students = new ObservableCollection<Student>(studentLogic.GetAll());
                Exams = new ObservableCollection<Exam>(examLogic.GetAll());
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public ExamResultsWindowViewModel(IExamResultsLogic examResultsLogic, IStudentLogic studentLogic, IExamLogic examLogic)
        {
            _examResultsLogic = examResultsLogic;
            _entityId = null;

            try
            {
                Students = new ObservableCollection<Student>(studentLogic.GetAll());
                Exams = new ObservableCollection<Exam>(examLogic.GetAll());
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void Save(object? obj)
        {
            ExamResults examResults = new ExamResults();

            examResults.Exam = Exam;
            examResults.Student = Student;
            examResults.Mark = Mark;

            if (_entityId != null)
            {
                _examResultsLogic.Update((int)_entityId, examResults);
                ((Window)obj).Close();
            }
            else
            {
                int res = _examResultsLogic.Add(examResults);
                ((Window)obj).Close();
            }
        }
    }
}
