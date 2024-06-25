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
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void SearchChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTxt.Text.Length > 0)
            {
                SearchHint.Visibility = Visibility.Hidden;
            }
            else
            {
                SearchHint.Visibility = Visibility.Visible;
            }
        }

        private void SearchBook(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string isbn = SearchTxt.Text;
                try
                {
                    Book book = DataAccess.GetBook(isbn);
                    MakeOrderWindow makeOrberWindow = new MakeOrderWindow(book);
                    makeOrberWindow.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Cannot find any book with ISBN: " + isbn);
                }
            }
        }
    }
}
