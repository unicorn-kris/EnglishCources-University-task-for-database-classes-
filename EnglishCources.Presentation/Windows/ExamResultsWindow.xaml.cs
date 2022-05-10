using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ExamResultsWindow.xaml
    /// </summary>
    public partial class ExamResultsWindow : Window
    {
        public ExamResultsWindow()
        {
            InitializeComponent();
        }

        private void Mark_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(s => !Char.IsDigit(s)))
            {
                e.Handled = true;
            }
        }
    }
}
