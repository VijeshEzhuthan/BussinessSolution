using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BussinessSolution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    LoginWindow loginWindow = new LoginWindow();
        //    MainWindow mainWindow = new MainWindow();

        //    loginWindow.ShowDialog();
        //    if (!loginWindow.DialogResult.HasValue || !loginWindow.DialogResult.Value)
        //    {
        //        Application.Current.Shutdown();
        //    }

        //    mainWindow.Show();
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            //LoginWindow loginWindow = new LoginWindow();
            MainWindow1 mainWindow = new MainWindow1();

            //loginWindow.ShowDialog();
            //if (!loginWindow.DialogResult.HasValue || !loginWindow.DialogResult.Value)
            //{
            //    Application.Current.Shutdown();
            //}

            mainWindow.Show();
        }
    }


}
