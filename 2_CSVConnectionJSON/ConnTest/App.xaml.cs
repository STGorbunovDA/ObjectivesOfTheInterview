using ConnTest.Infrastructure;
using ConnTest.Views;
using System;
using System.Windows;
using System.Windows.Threading;

namespace ConnTest
{
    public partial class App : Application
    {
        [Obsolete]
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (InstanceChecker.TakeMemory())
            {
                var jsonCsvConnectionView = new JsonCsvConnectionView();
                jsonCsvConnectionView.Show();
            }           
        }
        private void Application_DispatcherUnhandledException(object sender, 
            DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + 
                e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
