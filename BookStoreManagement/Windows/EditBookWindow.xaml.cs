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
using System.Windows.Shapes;
using BookStoreManagement.Model;

namespace BookStoreManagement.Windows
{
    /// <summary>
    /// Interaction logic for EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        Book book;
        string oldIsbn;

        public EditBookWindow(Book book)
        {
            this.book = book.Clone();
            this.oldIsbn = book.Isbn;
            InitializeComponent();
            this.DataContext = this.book;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            DataAccess.UpdateBook(book, oldIsbn);
            DialogResult = true;
            this.Close();
        }
    }
}
