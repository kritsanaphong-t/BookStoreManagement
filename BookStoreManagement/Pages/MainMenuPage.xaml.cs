using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BookStoreManagement.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void EnterOrderMenu(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Enter Order Menu");
        }

        private void EnterCustomersMenu(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Instance != null) MainWindow.Instance.ChangePage(new CustomersPage());
        }

        private void EnterBooksMenu(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Instance != null) MainWindow.Instance.ChangePage(new BooksPage());
        }
    }
}
