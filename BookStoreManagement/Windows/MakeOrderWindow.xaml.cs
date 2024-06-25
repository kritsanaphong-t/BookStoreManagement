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
    /// Interaction logic for MakeOrberWindow.xaml
    /// </summary>
    public partial class MakeOrderWindow : Window
    {
        Transaction transaction = new Transaction();

        public MakeOrderWindow(Book book)
        {
            InitializeComponent();
            this.transaction.Book = book;
            this.DataContext = transaction;
            this.isbnTxt.Text += book.Isbn;
            this.titleTxt.Text += book.Title;
            this.descriptionTxt.Text += book.Description;
            this.priceTxt.Text += (book.Price + " ฿");
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IncreaseQuantity(object sender, MouseButtonEventArgs e)
        {
            transaction.Quantity += 1;
            //MessageBox.Show(transaction.Quantity.ToString());
        }

        private void DecreaseQuantity(object sender, MouseButtonEventArgs e)
        {
            if (transaction.Quantity > 1)
            {
                transaction.Quantity -= 1;
            }
            //MessageBox.Show(transaction.Quantity.ToString());
        }

        private void Purchase(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = DataAccess.GetCustomers(int.Parse(customerIdTxt.Text));
                this.transaction.Customer = customer;
                this.transaction.TotalPrice = transaction.Quantity * transaction.Book.Price;
                DataAccess.AddTransaction(transaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer Id not found.", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            OrderSummaryWindow orderSummaryWindow = new OrderSummaryWindow(transaction);
            orderSummaryWindow.Show();
            this.Close();
        }
    }
}
