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
        Stack<Page> pages = new Stack<Page>();
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            pages.Push(new LoginPage());
            mainFrame.Content = pages.Peek();
        }

        public void ChangePage(Page page)
        {
            pages.Push(page);
            mainFrame.Content = pages.Peek();
        }

        public void BackPage()
        {
            pages.Pop();
            mainFrame.Content = pages.Peek();
        }

        public void Logout()
        {
            ChangePage(new LoginPage());
        }
    }
}