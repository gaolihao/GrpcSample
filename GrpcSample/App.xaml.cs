﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace GrpcSample;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindowViewModel = new MainViewModel();
        var mainWindow = new MainWindow
        {
            DataContext = mainWindowViewModel
        };

        MainWindow = mainWindow;
        MainWindow.Show();

    }
}
