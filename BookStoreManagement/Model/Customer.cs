using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.Model
{
    public class Customer : INotifyPropertyChanged
    {
        private string id = "";
        private string name = "";
        private string address = "";
        private string email = "";

        public string Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public string Name { get => name; set { name = value; RaisePropertyChanged(); } }
        public string Address { get => address; set { address = value; RaisePropertyChanged(); } }
        public string Email { get => email; set { email = value; RaisePropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static ObservableCollection<Customer> GetCustomers()
        {
            return new ObservableCollection<Customer>()
            {
                new Customer() { Id = "1001", Name = "John Smith", Address = "123 Main Street, Anytown, USA", Email = "john.smith@example.com" },
                new Customer() { Id = "1002", Name = "Emily Johnson", Address = "456 Oak Avenue, Smalltown, USA", Email = "emily.johnson@example.com" },
                new Customer() { Id = "1003", Name = "Michael Davis", Address = "789 Elm Drive, Cityville, USA", Email = "michael.davis@example.com" },
                new Customer() { Id = "1004", Name = "Sarah Brown", Address = "567 Pine Road, Villagetown, USA", Email = "sarah.brown@example.com" },
                new Customer() { Id = "1005", Name = "James Wilson", Address = "890 Maple Lane, Suburbia, USA, USA", Email = "james.wilson@example.com" }
            };
        }
    }
}
