using BookStoreManagement.Windows;
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
        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)this.MainWindow;
            DialogWindow dialogWindow = new DialogWindow("Do you want to Log out?");
            bool? isLogout = dialogWindow.ShowDialog();
            if (isLogout != null && isLogout == true)
            {
                mainWindow.Logout();
            }
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)this.MainWindow;
            mainWindow.BackPage();
        }
    }

}
