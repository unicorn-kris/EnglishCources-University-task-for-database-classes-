using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class MainWindowViewModel : NotifyPropertyChangedBase, IWindowViewModel
    {
        public MainWindowViewModel(IStudentLogic studentLogic,
            ITeacherLogic teacherLogic,
            ILessonLogic lessonLogic,
            IExamLogic examLogic,
            IEnglishLevelLogic englishLevelLogic, 
            IExamResultsLogic examResultsLogic, 
            IGroupLogic groupLogic,
            ITransitionToTheGroupLogic transitionToTheGroupLogic,
            ITransitionToTheLevelLogic transitionToTheLevelLogic)

        {
            Teachers = new ObservableCollection<Teacher>(teacherLogic.GetAll());
            Students = new ObservableCollection<Student>(studentLogic.GetAll());
            Lessons = new ObservableCollection<Lesson>(lessonLogic.GetAll());
            Exams = new ObservableCollection<Exam>(examLogic.GetAll());
            ExamResults = new ObservableCollection<ExamResults>(examResultsLogic.GetAll());
            Groups = new ObservableCollection<Group>(groupLogic.GetAll());
            EnglishLevels = new ObservableCollection<EnglishLevel>(englishLevelLogic.GetAll());

            AddBookCommand = new RelayCommand(AddBook);
            AddEnglishLevelCommand = new RelayCommand(AddEnglishLevel);
            AddExamCommand = new RelayCommand(AddExam);
            AddExamResultsCommand = new RelayCommand(AddExamResults);
            AddGroupCommand = new RelayCommand(AddGroup);
            AddLessonCommand = new RelayCommand(AddLesson);
            AddStudentCommand = new RelayCommand(AddStudent);
            AddTeacherCommand = new RelayCommand(AddTeacher);

            DeleteBookCommand = new RelayCommand(DeleteBook);
            DeleteEnglishLevelCommand = new RelayCommand(DeleteEnglishLevel);
            DeleteExamCommand = new RelayCommand(DeleteExam);
            DeleteExamResultsCommand = new RelayCommand(DeleteExamResults);
            DeleteGroupCommand = new RelayCommand(DeleteGroup);
            DeleteLessonCommand = new RelayCommand(DeleteLesson);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            DeleteTeacherCommand = new RelayCommand(DeleteTeacher);

            UpdateBookCommand = new RelayCommand(UpdateBook);
            UpdateEnglishLevelCommand = new RelayCommand(UpdateEnglishLevel);
            UpdateExamCommand = new RelayCommand(UpdateExam);
            UpdateExamResultsCommand = new RelayCommand(UpdateExamResults);
            UpdateGroupCommand = new RelayCommand(UpdateGroup);
            UpdateLessonCommand = new RelayCommand(UpdateLesson);
            UpdateStudentCommand = new RelayCommand(UpdateStudent);
            UpdateTeacherCommand = new RelayCommand(UpdateTeacher);

            TransitionsCommand = new RelayCommand(Transitions);

            SortTeachersForExperienceCommand = new RelayCommand(SortTeachersForExperience);
        }

        public ObservableCollection<Teacher> Teachers { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<Lesson> Lessons { get; set; }

        public ObservableCollection<Exam> Exams { get; set; }

        public ObservableCollection<ExamResults> ExamResults { get; set; }

        public ObservableCollection<Group> Groups { get; set; }

        public ObservableCollection<EnglishLevel> EnglishLevels { get; set; }

        #region commands

        public ICommand AddBookCommand { get; }

        public ICommand AddEnglishLevelCommand { get; }

        public ICommand AddExamResultsCommand { get; }

        public ICommand AddExamCommand { get; }

        public ICommand AddGroupCommand { get; }

        public ICommand AddLessonCommand { get; }

        public ICommand AddStudentCommand { get; }

        public ICommand AddTeacherCommand { get; }

        public ICommand DeleteBookCommand { get; }

        public ICommand DeleteEnglishLevelCommand { get; }

        public ICommand DeleteExamResultsCommand { get; }

        public ICommand DeleteExamCommand { get; }

        public ICommand DeleteGroupCommand { get; }

        public ICommand DeleteLessonCommand { get; }

        public ICommand DeleteStudentCommand { get; }

        public ICommand DeleteTeacherCommand { get; }

        public ICommand UpdateBookCommand { get; }

        public ICommand UpdateEnglishLevelCommand { get; }

        public ICommand UpdateExamResultsCommand { get; }

        public ICommand UpdateExamCommand { get; }

        public ICommand UpdateGroupCommand { get; }

        public ICommand UpdateLessonCommand { get; }

        public ICommand UpdateStudentCommand { get; }

        public ICommand UpdateTeacherCommand { get; }

        public ICommand TransitionsCommand { get; }

        public ICommand SortTeachersForExperienceCommand { get; }

        #endregion

        public void AddBook(object? obj) { }
               
        public void AddEnglishLevel(object? obj) {  }
               
        public void AddExamResults(object? obj) {  }
               
        public void AddExam(object? obj) {  }
               
        public void AddGroup(object? obj) {  }
               
        public void AddLesson(object? obj) { }
               
        public void AddStudent(object? obj) {  }
               
        public void AddTeacher(object? obj) {  }
               
        public void DeleteBook(object? obj) { }
               
        public void DeleteEnglishLevel(object? obj) {  }
               
        public void DeleteExamResults(object? obj) { }
               
        public void DeleteExam(object? obj) { }
               
        public void DeleteGroup(object? obj) { }
               
        public void DeleteLesson(object? obj) {  }
               
        public void DeleteStudent(object? obj) {  }
               
        public void DeleteTeacher(object? obj) { }
               
        public void UpdateBook(object? obj) { }
               
        public void UpdateEnglishLevel(object? obj) { }
               
        public void UpdateExamResults(object? obj) { }
               
        public void UpdateExam(object? obj) { }
               
        public void UpdateGroup(object? obj) {  }
               
        public void UpdateLesson(object? obj) {  }
               
        public void UpdateStudent(object? obj) { }
               
        public void UpdateTeacher(object? obj) { }
               
        public void Transitions(object? obj) { }

        public void SortTeachersForExperience(object? obj) { }
    }
}
