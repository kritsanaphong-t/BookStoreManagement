using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.Model
{
    internal class Book : INotifyPropertyChanged
    {
        private string isbn = "";
        private string title = "";
        private string description = "";
        private float price = 0f;

        public string Isbn { get => isbn; set { isbn = value; RaisePropertyChanged(); } }
        public string Title { get => title; set { title = value; RaisePropertyChanged(); } }
        public string Description { get => description; set { description = value; RaisePropertyChanged(); } }
        public float Price { get => price; set { price = value; RaisePropertyChanged(); } }

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
