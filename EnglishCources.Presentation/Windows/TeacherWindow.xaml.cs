using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EnglishCources.Presentation
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
        }

        private void Age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(s => !Char.IsDigit(s)))
            {
                e.Handled = true;
            }
        }

        private void Experience_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(s => !Char.IsDigit(s)))
            {
                e.Handled = true;
            }
        }
    }
}
