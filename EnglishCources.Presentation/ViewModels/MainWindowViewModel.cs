using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using EnglishCources.Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class MainWindowViewModel : NotifyPropertyChangedBase
    {
        #region private 
        private IBookLogic _bookLogic;

        private ITeacherLogic _teacherLogic;

        private ILessonLogic _lessonLogic;

        private IEnglishLevelLogic _englishLevelLogic;

        private IExamLogic _examLogic;

        private IGroupLogic _groupLogic;

        private ITransitionToTheGroupLogic _transitionToTheGroupLogic;

        private ITransitionToTheLevelLogic _transitionToTheLevelLogic;

        private IExamResultsLogic _examResultsLogic;

        private IStudentLogic _studentLogic;

        private Group _groupStudent;

        private EnglishLevel _levelStudent;

        private EnglishLevel _levelGroups;
        #endregion

        public MainWindowViewModel(IStudentLogic studentLogic,
            ITeacherLogic teacherLogic,
            ILessonLogic lessonLogic,
            IExamLogic examLogic,
            IEnglishLevelLogic englishLevelLogic,
            IExamResultsLogic examResultsLogic,
            IGroupLogic groupLogic,
            ITransitionToTheGroupLogic transitionToTheGroupLogic,
            ITransitionToTheLevelLogic transitionToTheLevelLogic,
            IBookLogic bookLogic)

        {
            Teachers = new ObservableCollection<Teacher>(teacherLogic.GetAll());
            Students = new ObservableCollection<Student>(studentLogic.GetAll());
            Lessons = new ObservableCollection<Lesson>(lessonLogic.GetAll());
            Exams = new ObservableCollection<Exam>(examLogic.GetAll());
            ExamResults = new ObservableCollection<ExamResults>(examResultsLogic.GetAll());
            Groups = new ObservableCollection<Group>(groupLogic.GetAll());
            EnglishLevels = new ObservableCollection<EnglishLevel>(englishLevelLogic.GetAll());

            GroupsStudent = new ObservableCollection<Group>(groupLogic.GetAll());
            LevelsGroups = new ObservableCollection<EnglishLevel>(englishLevelLogic.GetAll());
            LevelsStudent = new ObservableCollection<EnglishLevel>(englishLevelLogic.GetAll());

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

            AdminCommand = new RelayCommand(Admin);

            ReturnCommand = new RelayCommand(Return);

            SortTeachersForExperienceCommand = new RelayCommand(SortTeachersForExperience);

            _bookLogic = bookLogic;
            _englishLevelLogic = englishLevelLogic;
            _examLogic = examLogic;
            _examResultsLogic = examResultsLogic;
            _groupLogic = groupLogic;
            _studentLogic = studentLogic;
            _teacherLogic = teacherLogic;
            _groupLogic = groupLogic;
            _lessonLogic = lessonLogic;
            _transitionToTheGroupLogic = transitionToTheGroupLogic;
            _transitionToTheLevelLogic = transitionToTheLevelLogic;
        }

        #region props

        public Group GroupStudent
        {
            get => _groupStudent;

            set
            {
                OnPropertyChanged(value, ref _groupStudent);

                var studs = _studentLogic.GetStudentsByGroup(GroupStudent.Id);

                if (studs != null)
                {
                    Students.Clear();
                    Students.AddRange(studs);
                }
                else
                {
                    MessageBox.Show("No entities", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public EnglishLevel LevelStudent
        {
            get => _levelStudent;

            set
            {
                OnPropertyChanged(value, ref _levelStudent);

                var studs = _studentLogic.GetStudentsByLevel(LevelStudent.Id);

                if (studs != null)
                {
                    Students.Clear();
                    Students.AddRange(studs);
                }
                else
                {
                    MessageBox.Show("No entities", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public EnglishLevel LevelGroups
        {
            get => _levelGroups;

            set
            {
                OnPropertyChanged(value, ref _levelGroups);

                var studs = _groupLogic.GetGroupsByLevel(LevelGroups.Id);

                if (studs != null)
                {
                    Groups.Clear();
                    Groups.AddRange(studs);
                }
                else
                {
                    MessageBox.Show("No entities", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion

        #region collections
        public ObservableCollection<Group> GroupsStudent { get; set; }

        public ObservableCollection<EnglishLevel> LevelsStudent { get; set; }

        public ObservableCollection<EnglishLevel> LevelsGroups { get; set; }

        public ObservableCollection<Teacher> Teachers { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<Lesson> Lessons { get; set; }

        public ObservableCollection<Exam> Exams { get; set; }

        public ObservableCollection<ExamResults> ExamResults { get; set; }

        public ObservableCollection<Group> Groups { get; set; }

        public ObservableCollection<EnglishLevel> EnglishLevels { get; set; }

        #endregion

        #region commands
        
        public ICommand ReturnCommand { get; }

        public ICommand AdminCommand { get; }

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

        #region add commands
        public void AddBook(object? obj)
        {
            var vm = new BookWindowViewModel(_bookLogic, _englishLevelLogic);
            Window window = new BookWindow();
            window.DataContext = vm;
            window.ShowDialog();
        }

        public void AddEnglishLevel(object? obj)
        {
            var vm = new EnglishLevelWindowViewModel(_englishLevelLogic);
            Window window = new EnglishLevelWindow();
            window.DataContext = vm;
            window.ShowDialog();
        }

        public async void AddExamResults(object? obj)
        {
            var vm = new ExamResultsWindowViewModel(_examResultsLogic, _studentLogic, _examLogic);
            Window window = new ExamResultsWindow();
            window.DataContext = vm;
            window.ShowDialog();

            ExamResults.Clear();
            ExamResults.AddRange(_examResultsLogic.GetAll());
        }

        public void AddExam(object? obj)
        {
            var vm = new ExamWindowViewModel(_examLogic, _groupLogic);
            Window window = new ExamWindow();
            window.DataContext = vm;
            window.ShowDialog();

            Exams.Clear();
            Exams.AddRange(_examLogic.GetAll());
        }

        public void AddGroup(object? obj)
        {
            var vm = new GroupWindowViewModel(_groupLogic, _englishLevelLogic, _teacherLogic);
            Window window = new GroupWindow();
            window.DataContext = vm;
            window.ShowDialog();

            Groups.Clear();
            Groups.AddRange(_groupLogic.GetAll());
        }

        public void AddLesson(object? obj)
        {
            var vm = new LessonWindowViewModel(_lessonLogic, _groupLogic, _bookLogic);
            Window window = new LessonWindow();
            window.DataContext = vm;
            window.ShowDialog();

            Lessons.Clear();
            Lessons.AddRange(_lessonLogic.GetAll());
        }

        public void AddStudent(object? obj)
        {
            var vm = new StudentWindowViewModel(_studentLogic, _groupLogic, _englishLevelLogic);
            Window window = new StudentWindow();
            window.DataContext = vm;
            window.ShowDialog();

            Students.Clear();
            Students.AddRange(_studentLogic.GetAll());
        }

        public void AddTeacher(object? obj)
        {
            var vm = new TeacherWindowViewModel(_teacherLogic);
            Window window = new TeacherWindow();
            window.DataContext = vm;
            window.ShowDialog();

            Teachers.Clear();
            Teachers.AddRange(_teacherLogic.GetAll());
        }

        #endregion

        #region delete commands
        public void DeleteBook(object? obj)
        {
            var vm = new SelectWindowViewModel<Book>(_bookLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();
        }

        public void DeleteEnglishLevel(object? obj)
        {
            var vm = new SelectWindowViewModel<EnglishLevel>(_englishLevelLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();
        }

        public void DeleteExamResults(object? obj)
        {
            var vm = new SelectWindowViewModel<ExamResults>(_examResultsLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();

            ExamResults.Clear();
            ExamResults.AddRange(_examResultsLogic.GetAll());
        }

        public void DeleteExam(object? obj)
        {
            var vm = new SelectWindowViewModel<Exam>(_examLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();

            Exams.Clear();
            Exams.AddRange(_examLogic.GetAll());
        }

        public void DeleteGroup(object? obj)
        {
            var vm = new SelectWindowViewModel<Group>(_groupLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();

            Groups.Clear();
            Groups.AddRange(_groupLogic.GetAll());
        }

        public void DeleteLesson(object? obj)
        {
            var vm = new SelectWindowViewModel<Lesson>(_lessonLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();

            Lessons.Clear();
            Lessons.AddRange(_lessonLogic.GetAll());
        }

        public void DeleteStudent(object? obj)
        {
            var vm = new SelectWindowViewModel<Student>(_studentLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();

            Students.Clear();
            Students.AddRange(_studentLogic.GetAll());
        }

        public void DeleteTeacher(object? obj)
        {
            var vm = new SelectWindowViewModel<Teacher>(_teacherLogic);
            Window window = new SelectWindow();
            vm.DeleteVisible = true;
            vm.UpdateVisible = false;
            window.DataContext = vm;
            window.ShowDialog();

            Teachers.Clear();
            Teachers.AddRange(_teacherLogic.GetAll());
        }

        #endregion

        #region update commands
        public void UpdateBook(object? obj)
        {
            var selectvm = new SelectWindowViewModel<Book>(_bookLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new BookWindowViewModel(_bookLogic, _englishLevelLogic, selectId);
            window = new BookWindow();
            window.DataContext = vm;
            window.ShowDialog();
        }

        public void UpdateEnglishLevel(object? obj)
        {
            var selectvm = new SelectWindowViewModel<EnglishLevel>(_englishLevelLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new EnglishLevelWindowViewModel(_englishLevelLogic, selectId);
            window = new EnglishLevelWindow();
            window.DataContext = vm;
            window.ShowDialog();
        }

        public void UpdateExamResults(object? obj)
        {
            var selectvm = new SelectWindowViewModel<ExamResults>(_examResultsLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new ExamResultsWindowViewModel(_examResultsLogic, _studentLogic, _examLogic, selectId);
            window = new ExamResultsWindow();
            window.DataContext = vm;
            window.ShowDialog();

            ExamResults.Clear();
            ExamResults.AddRange(_examResultsLogic.GetAll());
        }

        public void UpdateExam(object? obj)
        {
            var selectvm = new SelectWindowViewModel<Exam>(_examLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new ExamWindowViewModel(_examLogic, _groupLogic, selectId);
            window = new ExamWindow();
            window.DataContext = vm;
            window.ShowDialog();


            Exams.Clear();
            Exams.AddRange(_examLogic.GetAll());
        }

        public void UpdateGroup(object? obj)
        {
            var selectvm = new SelectWindowViewModel<Group>(_groupLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new GroupWindowViewModel(_groupLogic, _englishLevelLogic, _teacherLogic, selectId);
            window = new GroupWindow();
            window.DataContext = vm;
            window.ShowDialog();


            Groups.Clear();
            Groups.AddRange(_groupLogic.GetAll());
        }

        public void UpdateLesson(object? obj)
        {
            var selectvm = new SelectWindowViewModel<Lesson>(_lessonLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new LessonWindowViewModel(_lessonLogic, _groupLogic, _bookLogic, selectId);
            window = new LessonWindow();
            window.DataContext = vm;
            window.ShowDialog();


            Lessons.Clear();
            Lessons.AddRange(_lessonLogic.GetAll());
        }

        public void UpdateStudent(object? obj)
        {
            var selectvm = new SelectWindowViewModel<Student>(_studentLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new StudentWindowViewModel(_studentLogic, _groupLogic, _englishLevelLogic, selectId);
            window = new StudentWindow();
            window.DataContext = vm;
            window.ShowDialog();

            Students.Clear();
            Students.AddRange(_studentLogic.GetAll());
        }

        public void UpdateTeacher(object? obj)
        {
            var selectvm = new SelectWindowViewModel<Teacher>(_teacherLogic);
            Window window = new SelectWindow();
            selectvm.DeleteVisible = false;
            selectvm.UpdateVisible = true;
            window.DataContext = selectvm;
            window.ShowDialog();

            int selectId = selectvm.EntityId;

            var vm = new TeacherWindowViewModel(_teacherLogic, selectId);
            window = new TeacherWindow();
            window.DataContext = vm;
            window.ShowDialog();

            Teachers.Clear();
            Teachers.AddRange(_teacherLogic.GetAll());
        }

        #endregion

        public void Transitions(object? obj)
        {
            var vm = new TransitionsWindowViewModel(_transitionToTheGroupLogic, _transitionToTheLevelLogic, _groupLogic, _englishLevelLogic);
            Window window = new Transitions();
            window.DataContext = vm;
            window.ShowDialog();
        }

        private bool IsSortTeach = false;

        public void SortTeachersForExperience(object? obj)
        {
            IsSortTeach = !IsSortTeach;

            if (IsSortTeach)
            {
                Teachers.Clear();
                Teachers.AddRange(_teacherLogic.SortedTeachersByExperience());
            }
            else
            {
                Teachers.Clear();
                Teachers.AddRange(_teacherLogic.GetAll());
            }
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get => _isAdmin;
            set => OnPropertyChanged(value, ref _isAdmin);
        }

        private void Admin(object? obj)
        {
            var vm = new AdminWindowViewModel();
            Window window = new AdminWindow();
            window.DataContext = vm;
            window.ShowDialog();

            IsAdmin = vm.IsAdmin;
        }

        private void Return(object? obj)
        {
            ExamResults.Clear();
            ExamResults.AddRange(_examResultsLogic.GetAll());

            Teachers.Clear();
            Teachers.AddRange(_teacherLogic.GetAll());

            Students.Clear();
            Students.AddRange(_studentLogic.GetAll());

            Lessons.Clear();
            Lessons.AddRange(_lessonLogic.GetAll());

            Groups.Clear();
            Groups.AddRange(_groupLogic.GetAll());

            Exams.Clear();
            Exams.AddRange(_examLogic.GetAll());
        }

    }


    internal static class ObservableHelp
    {
        public static void AddRange<T>(this IList<T> collection, IEnumerable<T> addCollection)
        {
            foreach (var item in addCollection)
            {
                collection.Add(item);
            }
        }
    }
}