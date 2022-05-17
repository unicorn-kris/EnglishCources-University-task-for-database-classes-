using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.Collections.Generic;
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

                var result = _transitionToTheGroupLogic.GetTransitionToTheGroupsByGroup(SelectedGroup.Id);

                if (result != null)
                {
                    TransitionToTheGroups.Clear();
                    TransitionToTheGroups.AddRange(result);
                }
            }
        }

        private EnglishLevel _selectedLevel;

        public EnglishLevel SelectedLevel
        {
            get => _selectedLevel;
            set
            {
                OnPropertyChanged(value, ref _selectedLevel);
                var result = _transitionToTheLevelLogic.GetTransitionToTheLevelsByLevel(SelectedLevel.Id);

                if (result != null)
                {
                    TransitionToTheLevels.Clear();
                    TransitionToTheLevels.AddRange(result);
                }
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

        public ICommand ReturnCommand => new RelayCommand(Return);

        private void Return(object? obj)
        {

            TransitionToTheLevels.Clear();
            TransitionToTheLevels.AddRange(_transitionToTheLevelLogic.GetAll());

            TransitionToTheGroups.Clear();
            TransitionToTheGroups.AddRange(_transitionToTheGroupLogic.GetAll());
        }

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
