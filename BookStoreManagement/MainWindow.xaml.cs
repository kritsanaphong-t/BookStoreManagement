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
using BookStoreManagement.Pages;

namespace BookStoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow? Instance;
        private Page currentPage;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            ChangePage(new LoginPage());
        }

        public void ChangePage(Page page)
        {
            CurrentPage = page;
            MainContent.Content = currentPage.Content;
        }

        public void Logout()
        {
            ChangePage(new LoginPage());
        }

        public Page CurrentPage { get => currentPage; set => currentPage = value; }
    }
}