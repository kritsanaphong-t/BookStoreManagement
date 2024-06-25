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
    /// Interaction logic for OrderSummaryWindow.xaml
    /// </summary>
    public partial class OrderSummaryWindow : Window
    {
        public OrderSummaryWindow(Transaction transaction)
        {
            InitializeComponent();
            customerIdTxt.Text += transaction.Customer.Id.ToString();
            bookTitleTxt.Text += transaction.Book.Title;
            quantityTxt.Text += transaction.Quantity.ToString();
            priceTxt.Text += transaction.Book.Price.ToString();
            totalPriceTxt.Text += transaction.TotalPrice.ToString(); 
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
