using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace EnglishCources.Presentation.ViewModels
{
    internal class StudentWindowViewModel : NotifyPropertyChangedBase, IWindowViewModel
    {
        private string _name;

        private string _surname;

        private EnglishLevel _englishLevel;

        private Group _group;

        public ObservableCollection<Group> Groups { get; set; }

        public ObservableCollection<EnglishLevel> EnglishLevels { get; set; }

        public Group Group
        {
            get => _group;

            set => OnPropertyChanged(value, ref _group);
        }

        public EnglishLevel EnglishLevel
        {
            get => _englishLevel;

            set => OnPropertyChanged(value, ref _englishLevel);
        }

        public string Name
        {
            get => _name;

            set => OnPropertyChanged(value, ref _name);
        }

        public string Surname
        {
            get => _surname;

            set => OnPropertyChanged(value, ref _surname);
        }

        private IStudentLogic _studentLogic;

        private int? _entityId;

        public StudentWindowViewModel(IStudentLogic studentLogic, IGroupLogic groupLogic, IEnglishLevelLogic englishLevelLogic, int entityId)
        {
            _entityId = entityId;
            _studentLogic = studentLogic;

            try
            {
                Student student = studentLogic.GetById(entityId);

                Name = student.Name;
                Surname = student.Surname;
                Group = student.GroupNumber;
                EnglishLevel = student.EnglishLevel;

                Groups = (ObservableCollection<Group>)groupLogic.GetAll();
                EnglishLevels = (ObservableCollection<EnglishLevel>)englishLevelLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public StudentWindowViewModel(IStudentLogic studentLogic, IGroupLogic groupLogic, IEnglishLevelLogic englishLevelLogic)
        {
            _entityId = null;
            _studentLogic = studentLogic;

            try
            {
                Groups = (ObservableCollection<Group>)groupLogic.GetAll();
                EnglishLevels = (ObservableCollection<EnglishLevel>)englishLevelLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void SaveCommand()
        {
            Student student = new Student();

            student.Surname = Surname;
            student.GroupNumber = Group;
            student.EnglishLevel = EnglishLevel;
            student.Name = Name;

            if (_entityId != null)
            {
                _studentLogic.Update((int)_entityId, student);
            }
            else
            {
                int res = _studentLogic.Add(student);
            }
        }
    }
}
