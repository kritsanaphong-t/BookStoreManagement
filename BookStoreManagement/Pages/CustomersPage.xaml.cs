using System;
using System.CodeDom.Compiler;
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
using BookStoreManagement.Model;
using BookStoreManagement.Windows;

namespace BookStoreManagement.Pages
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        public ObservableCollection<Customer> Customers { get ; set; }

        public CustomersPage()
        {
            Customers = Customer.GetCustomers();
       
            InitializeComponent();
            customerGrid.ItemsSource = Customers;
        }

        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Customer customer = (Customer)button.DataContext;
            EditCustomerWindow editCustomerWindow = new EditCustomerWindow(customer);
            editCustomerWindow.ShowDialog();
        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Customer customer = (Customer)button.DataContext;
            Customers.Remove(customer);
        }
    }
}
