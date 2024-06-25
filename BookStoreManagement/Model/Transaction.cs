using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.Model
{
    public class Transaction: INotifyPropertyChanged
    {
        string transactionId;
        Book book;
        Customer customer;
        int quantity = 1;
        float totalPrice;

        public string TransactionId { get => transactionId; set { transactionId = value; RaisePropertyChanged(); } }
        public Book Book { get => book; set { book = value; RaisePropertyChanged(); } }
        public Customer Customer { get => customer; set { customer = value; RaisePropertyChanged(); } }
        public int Quantity { get => quantity; set { quantity = value; RaisePropertyChanged(); } }
        public float TotalPrice { get => totalPrice; set { totalPrice = value; RaisePropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
