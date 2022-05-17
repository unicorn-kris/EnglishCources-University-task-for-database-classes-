using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class TransitionsWindowViewModel: NotifyPropertyChangedBase
    {
       
        private ITransitionToTheGroupLogic _transitionToTheGroupLogic;

        private ITransitionToTheLevelLogic _transitionToTheLevelLogic;

        private IGroupLogic _groupLogic;

        private IEnglishLevelLogic _englishLevelLogic;

        public ObservableCollection<TransitionToTheGroup> TransitionToTheGroups { get; set; }

        public ObservableCollection<TransitionToTheLevel> TransitionToTheLevels { get; set; }

        public ObservableCollection<Group> Groups { get; set; }

        public ObservableCollection<EnglishLevel> Levels { get; set; }


        private Group _selectedGroup;

        public Group SelectedGroup {
            get => _selectedGroup;
            set {
                OnPropertyChanged(value, ref _selectedGroup);
                TransitionToTheGroups = new ObservableCollection<TransitionToTheGroup>(_transitionToTheGroupLogic.GetTransitionToTheGroupsByGroup(_selectedGroup.Id));
            }
        }

        private EnglishLevel _selectedLevel;

        public EnglishLevel SelectedLevel
        {
            get => _selectedLevel;
            set
            {
                OnPropertyChanged(value, ref _selectedLevel);
                TransitionToTheLevels = new ObservableCollection<TransitionToTheLevel>(_transitionToTheLevelLogic.GetTransitionToTheLevelsByLevel(_selectedLevel.Id));
            }
        }

        public TransitionsWindowViewModel(ITransitionToTheGroupLogic transitionToTheGroupLogic, ITransitionToTheLevelLogic transitionToTheLevelLogic, IGroupLogic groupLogic, IEnglishLevelLogic englishLevelLogic)
        {

            _transitionToTheGroupLogic = transitionToTheGroupLogic;
            _transitionToTheLevelLogic = transitionToTheLevelLogic;
            _groupLogic = groupLogic;
            _englishLevelLogic = englishLevelLogic;

            try
            {
                TransitionToTheGroups = new ObservableCollection<TransitionToTheGroup>(_transitionToTheGroupLogic.GetAll());
                TransitionToTheLevels = new ObservableCollection<TransitionToTheLevel>(_transitionToTheLevelLogic.GetAll());
                Groups = new ObservableCollection<Group>(_groupLogic.GetAll());
                Levels = new ObservableCollection<EnglishLevel>(_englishLevelLogic.GetAll());
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public ICommand SortGroupsCommand => new RelayCommand(SortGroups);

        public void SortGroups(object? obj)
        {
            TransitionToTheGroups = new ObservableCollection<TransitionToTheGroup>(_transitionToTheGroupLogic.SortedTransitionToTheGroupsByDate());
        }

        public ICommand SortLevelsCommand => new RelayCommand(SortLevels);

        public void SortLevels(object? obj)
        {
            TransitionToTheLevels = new ObservableCollection<TransitionToTheLevel>(_transitionToTheLevelLogic.SortedTransitionToTheLevelsByDate());
        }
    }
}
