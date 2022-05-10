using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for EnglishLevelWindow.xaml
    /// </summary>
    public partial class EnglishLevelWindow : Window
    {
        public EnglishLevelWindow()
        {
            InitializeComponent();
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(s => !Char.IsDigit(s)))
            {
                e.Handled = true;
            }
        }

        private void Letter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(s => !Char.IsDigit(s)))
            {
                e.Handled = true;
            }
        }
    }
}
