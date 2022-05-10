using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for LessonWindow.xaml
    /// </summary>
    public partial class LessonWindow : Window
    {
        public LessonWindow()
        {
            InitializeComponent();
        }

        private void Hour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(s => !Char.IsDigit(s)))
            {
                e.Handled = true;
            }
        }
    }
}
