using System.Configuration;
using System.Data;
using System.Windows;

namespace BookStoreManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Logout(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)this.MainWindow;
            mainWindow.Logout();
        }
    }

}
