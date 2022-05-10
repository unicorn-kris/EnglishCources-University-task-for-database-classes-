﻿using Autofac;
using EnglishCources.Presentation.ViewModels;
using System.Windows;

namespace EnglishCources.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IContainer _container;
        public MainWindow()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            builder.RegisterModule<PresentationModule>();
            _container = builder.Build();

            DataContext = _container.Resolve<MainWindowViewModel>();
        }
    }
}
