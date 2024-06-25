using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace BookStoreManagement.Model
{
    internal class DataAccess
    {
        public async static void InitializeDatabase()
        {
            await using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();

                #region Create Customers Table
                String customersTableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (Customer_Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Customer_Name VARCHAR(100) NULL," +
                    "Address VARCHAR(255) NULL," +
                    "Email VARCHAR(100) NULL)";
                SqliteCommand createCustomersTable = new SqliteCommand(customersTableCommand, db);
                createCustomersTable.ExecuteReader();
                #endregion

                #region Create Books Table
                String booksTableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Books (ISBN VARCHAR(20) PRIMARY KEY, " +
                    "Title VARCHAR(255) NOT NULL," +
                    "Description TEXT NULL," +
                    "Price DECIMAL(10,2) NULL)";
                SqliteCommand createBooksTable = new SqliteCommand(booksTableCommand, db);
                createBooksTable.ExecuteReader();
                #endregion

                #region Create Transactions Table
                String transactionsTableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Transactions (Transaction_Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "ISBN VARCHAR(20), " +
                    "Customer_Id INTEGER, " +
                    "Quantity INTEGER, " +
                    "Total_Price DECIMAL(10, 2), " +
                    "FOREIGN KEY (ISBN) REFERENCES Books(ISBN) ON DELETE CASCADE, " +
                    "FOREIGN KEY (Customer_Id) REFERENCES Customers(Customer_Id) ON DELETE CASCADE)";
                SqliteCommand createTransactionsTable = new SqliteCommand(transactionsTableCommand, db);
                createTransactionsTable.ExecuteReader();
                #endregion
            }
        }

        #region Customer
        public async static void AddCustomer(Customer customer)
        {
            await using (SqliteConnection db =
              new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Customers (Customer_Name,Address,Email) VALUES (@Customer_Name, @Address, @Email);";
                insertCommand.Parameters.AddWithValue("@Customer_Name", customer.Name);
                insertCommand.Parameters.AddWithValue("@Address", customer.Address);
                insertCommand.Parameters.AddWithValue("@Email", customer.Email);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Customer customer = new Customer() { Id = query.GetInt32(0), Name = query.GetString(1), Address = query.GetString(2), Email = query.GetString(3) };
                    customers.Add(customer);
                }
                db.Close();
            }
            return customers;
        }

        public static List<Customer> GetCustomers(int id, string name, string email)
        {
            List<Customer> customers = new List<Customer>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                selectCommand.CommandText = "SELECT * from Customers WHERE " +
                    "Customer_Name LIKE @Customer_Name OR " +
                    "Email LIKE @Email";
                if (id > 0) selectCommand.CommandText += " OR Customer_Id = @Customer_Id";
                selectCommand.Parameters.AddWithValue("@Customer_Id", id);
                selectCommand.Parameters.AddWithValue("@Customer_Name", "%" + name + "%");
                selectCommand.Parameters.AddWithValue("@Email", "%" + email + "%");
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Customer customer = new Customer() { Id = query.GetInt32(0), Name = query.GetString(1), Address = query.GetString(2), Email = query.GetString(3) };
                    customers.Add(customer);
                }
                db.Close();
            }
            return customers;
        }

        public static Customer GetCustomers(int id)
        {
            Customer customer;
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                selectCommand.CommandText = "SELECT * from Customers WHERE " +
                    "Customer_Id = @Customer_Id";
                selectCommand.Parameters.AddWithValue("@Customer_Id", id);
                SqliteDataReader query = selectCommand.ExecuteReader();
                query.Read();
                customer = new Customer() { Id = query.GetInt32(0), Name = query.GetString(1), Address = query.GetString(2), Email = query.GetString(3) };
                db.Close();
            }
            return customer;
        }

        public async static void UpdateCustomer(Customer customer)
        {
            await using (SqliteConnection db =
              new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "UPDATE Customers SET Customer_Name = @Customer_Name," +
                    "Address = @Address," +
                    "Email = @Email " +
                    "WHERE Customer_Id = @Customer_Id";
                insertCommand.Parameters.AddWithValue("@Customer_Name", customer.Name);
                insertCommand.Parameters.AddWithValue("@Address", customer.Address);
                insertCommand.Parameters.AddWithValue("@Email", customer.Email);
                insertCommand.Parameters.AddWithValue("@Customer_Id", customer.Id);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public async static void DeleteCustomer(Customer customer)
        {
            await using (SqliteConnection db =
              new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "DELETE FROM Customers WHERE Customer_Id = @Customer_Id";
                insertCommand.Parameters.AddWithValue("@Customer_Id", customer.Id);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        #endregion

        #region Book
        public async static void AddBook(Book book)
        {
            await using (SqliteConnection db =
              new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Books (ISBN,Title,Description,Price) VALUES (@ISBN,@Title, @Description, @Price);";
                insertCommand.Parameters.AddWithValue("@ISBN", book.Isbn);
                insertCommand.Parameters.AddWithValue("@Title", book.Title);
                insertCommand.Parameters.AddWithValue("@Description", book.Description);
                insertCommand.Parameters.AddWithValue("@Price", book.Price);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book() { Isbn = query.GetString(0), Title = query.GetString(1), Description = query.GetString(2), Price = query.GetFloat(3) };
                    books.Add(book);
                }
                db.Close();
            }
            return books;
        }

        public static List<Book> GetBooks(string isbn, string title, string description)
        {
            List<Book> books = new List<Book>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                selectCommand.CommandText = "SELECT * from Books WHERE " +
                    "ISBN LIKE @ISBN OR " +
                    "Title LIKE @Title OR " +
                    "Description LIKE @Description";
                selectCommand.Parameters.AddWithValue("@ISBN", "%" + isbn + "%");
                selectCommand.Parameters.AddWithValue("@Title", "%" + title + "%");
                selectCommand.Parameters.AddWithValue("@Description", "%" + description + "%");
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book() { Isbn = query.GetString(0), Title = query.GetString(1), Description = query.GetString(2), Price = query.GetFloat(3) };
                    books.Add(book);
                }
                db.Close();
            }
            return books;
        }

        public static Book GetBook(string isbn)
        {
            Book book;
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                selectCommand.CommandText = "SELECT * from Books WHERE " +
                    "ISBN = @ISBN";
                selectCommand.Parameters.AddWithValue("@ISBN", isbn);
                SqliteDataReader query = selectCommand.ExecuteReader();
                query.Read();
                book = new Book() { Isbn = query.GetString(0), Title = query.GetString(1), Description = query.GetString(2), Price = query.GetFloat(3) };
                db.Close();
            }
            return book;
        }

        public async static void UpdateBook(Book book, string oldIsbn)
        {
            await using (SqliteConnection db =
              new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "UPDATE Books SET ISBN = @NewISBN," +
                    "Title = @Title," +
                    "Description = @Description, " +
                    "Price = @Price " +
                    "WHERE ISBN = @OldISBN";
                insertCommand.Parameters.AddWithValue("@OldISBN", oldIsbn);
                insertCommand.Parameters.AddWithValue("@NewISBN", book.Isbn);
                insertCommand.Parameters.AddWithValue("@Title", book.Title);
                insertCommand.Parameters.AddWithValue("@Description", book.Description);
                insertCommand.Parameters.AddWithValue("@Price", book.Price);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public async static void DeleteBook(Book book)
        {
            await using (SqliteConnection db =
              new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "DELETE FROM Books WHERE ISBN = @ISBN";
                insertCommand.Parameters.AddWithValue("@ISBN", book.Isbn);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        #endregion

        #region Transaction
        public async static void AddTransaction(Transaction transaction)
        {
            await using (SqliteConnection db =
              new SqliteConnection($"Filename=bookStoreManagement.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Transactions (ISBN,Customer_Id,Quantity,Total_Price) VALUES (@ISBN,@Customer_Id, @Quantity, @Total_Price);";
                insertCommand.Parameters.AddWithValue("@ISBN", transaction.Book.Isbn);
                insertCommand.Parameters.AddWithValue("@Customer_Id", transaction.Customer.Id);
                insertCommand.Parameters.AddWithValue("@Quantity", transaction.Quantity);
                insertCommand.Parameters.AddWithValue("@Total_Price", transaction.TotalPrice);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        #endregion
    }
}
