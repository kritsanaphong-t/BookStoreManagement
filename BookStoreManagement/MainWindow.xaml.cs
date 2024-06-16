using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;

namespace BookStoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void passwordTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordTxt.Password.Length > 0)
            {
                passwordLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordLabel.Visibility = Visibility.Visible;
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
                usernameLabel.Visibility= Visibility.Visible;
            }
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (usernameTxt.Text == "admin" && passwordTxt.Password == "123")
            {
                MessageBox.Show("Login success.", "Message");
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}