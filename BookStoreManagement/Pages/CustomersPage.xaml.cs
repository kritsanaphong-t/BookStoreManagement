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
            InitializeComponent();
            Customers = new ObservableCollection<Customer>(DataAccess.GetCustomers());
            customerGrid.ItemsSource = Customers;
        }

        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Customer customer = (Customer)button.DataContext;
            EditCustomerWindow editCustomerWindow = new EditCustomerWindow(customer);
            bool? isEdited = editCustomerWindow.ShowDialog();
            if (isEdited == true) FetchCustomers();
        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Customer customer = (Customer)button.DataContext;
            DialogWindow dialogWindow = new DialogWindow("Are you sure to delete customer data?");
            bool? isDelete = dialogWindow.ShowDialog();
            if (isDelete == true)
            {
                DataAccess.DeleteCustomer(customer);
                FetchCustomers();
            }
        }

        private void AddCustomer(object sender, MouseButtonEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            bool? isAdded = addCustomerWindow.ShowDialog();
            if (isAdded == true) FetchCustomers();
        }

        private void FetchCustomers()
        {
            Customers = new ObservableCollection<Customer>(DataAccess.GetCustomers());
            customerGrid.ItemsSource = Customers;
        }

        private void SearchChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTxt.Text.Length > 0)
            {
                SearchHint.Visibility = Visibility.Hidden;
                int id = 0;
                string name = SearchTxt.Text;
                string email = SearchTxt.Text;
                int.TryParse(SearchTxt.Text, out id);
                Customers = new ObservableCollection<Customer>(DataAccess.GetCustomers(id, name, email));
                customerGrid.ItemsSource = Customers;
            }
            else
            {
                SearchHint.Visibility = Visibility.Visible;
                FetchCustomers();
            }
        }
    }
}
