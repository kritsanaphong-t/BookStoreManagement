﻿using BookStoreManagement.Model;
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

namespace BookStoreManagement.Windows
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        Customer customer;

        public EditCustomerWindow(Customer customer)
        {
            this.customer = customer.Clone();
            InitializeComponent();
            this.DataContext = this.customer;
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
            DataAccess.UpdateCustomer(customer);
            DialogResult = true;
            this.Close();
        }
    }
}
