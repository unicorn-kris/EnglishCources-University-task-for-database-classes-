using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class GroupWindowViewModel : NotifyPropertyChangedBase
    {
        private int _number;

        private EnglishLevel _englishLevel;

        private Teacher _teacher;

        public ObservableCollection<EnglishLevel> EnglishLevels { get; set; }

        public ObservableCollection<Teacher> Teachers { get; set; }

        public int Number
        {
            get => _number;

            set => OnPropertyChanged(value, ref _number);
        }

        public EnglishLevel EnglishLevel
        {
            get => _englishLevel;

            set => OnPropertyChanged(value, ref _englishLevel);
        }

        public Teacher Teacher
        {
            get => _teacher;

            set => OnPropertyChanged(value, ref _teacher);
        }

        private IGroupLogic _groupLogic;

        private int? _entityId;

        public ICommand SaveCommand => new RelayCommand(Save);

        public GroupWindowViewModel(IGroupLogic groupLogic, IEnglishLevelLogic englishLevelLogic, ITeacherLogic teacherLogic, int entityId)
        {
            _entityId = entityId;

            _groupLogic = groupLogic;

            try
            {
                Group group = _groupLogic.GetById(entityId);

                Teacher = group.Teacher;
                EnglishLevel = group.MinLevel;
                Number = group.Number;

                Teachers = new ObservableCollection<Teacher>(teacherLogic.GetAll());
                EnglishLevels = new ObservableCollection<EnglishLevel>(englishLevelLogic.GetAll());
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }

        }

        public GroupWindowViewModel(IGroupLogic groupLogic, IEnglishLevelLogic englishLevelLogic, ITeacherLogic teacherLogic)
        {
            _groupLogic = groupLogic;

            _entityId = null;

            try
            {
                Teachers = new ObservableCollection<Teacher>(teacherLogic.GetAll());
                EnglishLevels = new ObservableCollection<EnglishLevel>(englishLevelLogic.GetAll());
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void Save(object? obj)
        {
            Group group = new Group();

            group.Number = Number;
            group.Teacher = Teacher;
            group.MinLevel = EnglishLevel;

            if (_entityId != null)
            {
                _groupLogic.Update((int)_entityId, group);
                ((Window)obj).Close();
            }
            else
            {
                int res = _groupLogic.Add(group);
                ((Window)obj).Close();
            }
        }
    }
}
