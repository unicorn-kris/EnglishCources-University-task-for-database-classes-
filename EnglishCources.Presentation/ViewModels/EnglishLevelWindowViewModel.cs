using EnglishCources.Common;
using EnglishCources.Logic.Contracts;
using System;
using System.IO;

namespace EnglishCources.Presentation.ViewModels
{
    internal class EnglishLevelWindowViewModel : NotifyPropertyChangedBase, IWindowViewModel
    {

        private string _letter;

        private int _number;

        public string Letter
        {
            get => _letter;
            set => OnPropertyChanged(value, ref _letter);
        }

        public int Number
        {
            get => _number;
            set => OnPropertyChanged(value, ref _number);
        }

        private IEnglishLevelLogic _englishLevelLogic;

        private int? _entityId;

        public EnglishLevelWindowViewModel(IEnglishLevelLogic englishLevelLogic, int entityId)
        {
            _englishLevelLogic = englishLevelLogic;
            try
            {
                EnglishLevel englishLevel = _englishLevelLogic.GetById(entityId);

                Letter = englishLevel.Letter;
                Number = englishLevel.Number;
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
            }
        }

        public EnglishLevelWindowViewModel(IEnglishLevelLogic englishLevelLogic)
        {
            _entityId = null;
            _englishLevelLogic = englishLevelLogic;
        }

        public void SaveCommand()
        {
            EnglishLevel englishLevel = new EnglishLevel();

            englishLevel.Number = Number;
            englishLevel.Letter = Letter;

            if (_entityId != null)
            {
                _englishLevelLogic.Update((int)_entityId, englishLevel);
            }
            else
            {
                int res = _englishLevelLogic.Add(englishLevel);
            }
        }
    }
}
