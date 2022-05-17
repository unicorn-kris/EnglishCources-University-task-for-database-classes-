using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.ViewModels
{
    internal class AdminWindowViewModel : NotifyPropertyChangedBase
    {
        private bool _isAdmin = false;

        public bool IsAdmin
        {
            get => _isAdmin;
            set => OnPropertyChanged(value, ref _isAdmin);
        }

        private string _login;

        public string Login
        {
            get => _login;
            set => OnPropertyChanged(value, ref _login);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => OnPropertyChanged(value, ref _password);
        }

        public ICommand LogInCommand => new RelayCommand(LogIn);

        public void LogIn(object? obj)
        {
            if (Login == "admin" && Password == "admin")
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;

                MessageBox.Show("Enter correct login or password", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ((Window)obj).Close();
        }
    }
}
