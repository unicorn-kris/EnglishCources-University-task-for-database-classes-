using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace EnglishCources.Presentation.ViewModels
{
    internal class GroupWindowViewModel : NotifyPropertyChangedBase, IWindowViewModel
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

                Teachers = (ObservableCollection<Teacher>)teacherLogic.GetAll();
                EnglishLevels = (ObservableCollection<EnglishLevel>)englishLevelLogic.GetAll();
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
                Teachers = (ObservableCollection<Teacher>)teacherLogic.GetAll();
                EnglishLevels = (ObservableCollection<EnglishLevel>)englishLevelLogic.GetAll();
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public void SaveCommand()
        {
            Group group = new Group();

            group.Number = Number;
            group.Teacher = Teacher;
            group.MinLevel = EnglishLevel;

            if (_entityId != null)
            {
                _groupLogic.Update((int)_entityId, group);
            }
            else
            {
                int res = _groupLogic.Add(group);
            }
        }
    }
}
