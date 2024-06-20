using BookStoreManagement.Model;
using BookStoreManagement.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public ObservableCollection<Book> Books { get; set; }
        public BooksPage()
        {
            InitializeComponent();
            Books = new ObservableCollection<Book>(DataAccess.GetBooks());
            bookGrid.ItemsSource = Books;
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Book book = (Book)button.DataContext;
            EditBookWindow editBookWindow = new EditBookWindow(book);
            bool? isEdited = editBookWindow.ShowDialog();
            if (isEdited == true) FetchBook();
        }

        private void FetchBook()
        {
            Books = new ObservableCollection<Book>(DataAccess.GetBooks());
            bookGrid.ItemsSource = Books;
        }
    }
}
