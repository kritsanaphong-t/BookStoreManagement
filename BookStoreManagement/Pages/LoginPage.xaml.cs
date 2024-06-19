using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookStoreManagement;
using BookStoreManagement.Model;

namespace BookStoreManagement.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void passwordTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordTxt.Password.Length > 0 )
            {
                passwordLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordLabel.Visibility= Visibility.Visible;
            }
        }

        private void usernameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (usernameTxt.Text.Length > 0)
            {
                usernameLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                usernameLabel.Visibility = Visibility.Visible;
            }
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (usernameTxt.Text == "admin" && passwordTxt.Password == "123")
            {
                if (MainWindow.Instance != null)
                {
                    DataAccess.InitializeDatabase();
                    MainWindow.Instance.ChangePage(new MainMenuPage());
                }
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
