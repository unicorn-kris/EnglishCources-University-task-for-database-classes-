using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public GroupWindow()
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
    }
}
