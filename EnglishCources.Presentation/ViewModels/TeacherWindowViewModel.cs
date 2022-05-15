using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.IO;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class TeacherWindowViewModel : NotifyPropertyChangedBase
    {
        private string _name;

        private string _surname;

        private int _age;

        private int _experience;

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

        public int Age
        {
            get => _age;

            set => OnPropertyChanged(value, ref _age);
        }

        public int Experience
        {
            get => _experience;

            set => OnPropertyChanged(value, ref _experience);
        }

        private ITeacherLogic _teacherLogic;

        private int? _entityId;

        public ICommand _saveCommand => new RelayCommand(SaveCommand);

        public TeacherWindowViewModel(ITeacherLogic teacherLogic, int entityId)
        {
            _entityId = entityId;
            _teacherLogic = teacherLogic;

            try
            {
                Teacher teacher = teacherLogic.GetById(entityId);

                Name = teacher.Name;
                Surname = teacher.Surname;
                Age = teacher.Age;
                Experience = teacher.Experience;
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public TeacherWindowViewModel(ITeacherLogic teacherLogic)
        {
            _entityId = null;
            _teacherLogic = teacherLogic;
        }

        public void SaveCommand(object? obj)
        {
            Teacher teacher = new Teacher();

            teacher.Surname = Surname;
            teacher.Age = Age;
            teacher.Experience = Experience;
            teacher.Name = Name;

            if (_entityId != null)
            {
                _teacherLogic.Update((int)_entityId, teacher);
            }
            else
            {
                int res = _teacherLogic.Add(teacher);
            }
        }
    }
}
