using EnglishCources.Logic.Contracts;
using System;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class SelectWindowViewModel<T> : NotifyPropertyChangedBase
    {
        private IEntityLogic<T> _entityLogic;
        private int _entityId = 0;

        public int EntityId
        {
            get => _entityId;

            set => OnPropertyChanged(value, ref _entityId);
        }

        public ICommand DeleteCommand => new RelayCommand(Delete);
        public ICommand UpdateCommand => new RelayCommand(Update);

        private bool _deleteVisible;

        public bool DeleteVisible
        {
            get => _deleteVisible;

            set => OnPropertyChanged(value, ref _deleteVisible);
        }

        private bool _updateVisible;

        public bool UpdateVisible
        {
            get => _updateVisible;

            set => OnPropertyChanged(value, ref _updateVisible);
        }

        public SelectWindowViewModel(IEntityLogic<T> entityLogic)
        {
            _entityLogic = entityLogic;
        }

        public void Delete(object? obj)
        {
            if (EntityId != 0)
            {
                try
                {
                    _entityLogic.Delete(_entityId);
                    ((Window)obj).Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Incorrect Id",
         MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Id", "Enter Id",
         MessageBoxButton.OK, MessageBoxImage.Error);
                ((Window)obj).Close();
            }
        }

        public void Update(object? obj)
        {
            if (EntityId != 0)
            {
                try
                {
                    var item = _entityLogic.GetById(_entityId);
                    ((Window)obj).Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Incorrect Id",
         MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Id", "Enter Id",
         MessageBoxButton.OK, MessageBoxImage.Error);
                ((Window)obj).Close();
            }
        }
    }
}
