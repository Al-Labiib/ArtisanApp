using System;
using System.Collections;
using ARTISANADO.Models;
using ARTISANADO.Enums;
using MySql.Data.MySqlClient;
using ArtisanAdo.Net.Enums;

namespace ARTISANADO.Repositories
{
    public class CustomerRepo
    {
        public string connect = "server = localhost;user = root;database = artisanapp;port = 3306;password = Labiib";
        public void Register(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin)
        {
            var customer = new Customer(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin);
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var query = $"INSERT INTO customer (firstname, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin) VALUES ('{customer.FirstName}','{customer.LastName}','{customer.Email}','{customer.PhoneNumber}','{customer.Password}','{customer.Dob}','{customer.Gender}','{customer.Address}','{customer.NextOfKin}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Customer Login(string email, string password)
        {
            var customer = GetCustomer(email);
            if (customer != null && customer.Password == password)
            {
                return customer;
            }
            return null;
        }
        public Customer GetCustomer(string email)
        {
            Customer customer = null;
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = $"select * from customer where email = '{email}'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Console.WriteLine("Repo is working");
                string FirstName = $"{reader["FirstName"]}";
                string LastName = $"{reader["LastName"]}";
                string Email = $"{reader["Email"]}";
                string PhoneNumber = $"{reader["PhoneNumber"]}";
                string Password = $"{reader["Password"]}";
                DateTime Dob = DateTime.Parse($"{reader["Dob"]}");
                Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{reader["Gender"]}");
                string Address = $"{reader["Address"]}";
                string NextOfKin = $"{reader["NextOfKin"]}";
                customer = new Customer(FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin);
                connection.Close();
                return customer;
            }
            else
            {
                return null;
            }
        }
        public List<Customer> ListAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = "select * from customer";
            var query = $"select count(*) from customer";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlCommand countCommand = new MySqlCommand(query, connection);
            int count = 0;
            connection.Open();
            using (countCommand)
            {
                count = Convert.ToInt32(countCommand.ExecuteScalar());
            }
            MySqlDataReader reader = command.ExecuteReader();
            if (count != 0)
            {
                for (var i = 0; i < count; i++)
                {
                    reader.Read();
                    int id = int.Parse($"{reader["Id"]}");
                    string FirstName = $"{reader["FirstName"]}";
                    string LastName = $"{reader["LastName"]}";
                    string Email = $"{reader["Email"]}";
                    string PhoneNumber = $"{reader["PhoneNumber"]}";
                    string Password = $"{reader["Password"]}";
                    DateTime Dob = DateTime.Parse($"{reader["Dob"]}");
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{reader["Gender"]}");
                    string Address = $"{reader["Address"]}";
                    string NextOfKin = $"{reader["NextOfKin"]}";
                    var customer = new Customer(id, FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin);
                    customers.Add(customer);
                }
                return customers;
            }
            else
            {
                return null;
            }
        }
        public Customer PrintCustomer()
        {
            var customers = ListAllCustomers();
            foreach (var customer in customers)
            {
                if (customer != null)
                {
                    System.Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.Email} {customer.PhoneNumber} {customer.Password} {customer.Dob} {customer.Gender} {customer.Gender} {customer.Address} {customer.NextOfKin}");
                }
                else
                {
                    System.Console.WriteLine("No Customer Found");
                }
            }
            return null;
        }
        public void Update(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin)
        {
            var customer = GetCustomer(email);
            if (customer != null && customer.Email == email)
            {
                System.Console.WriteLine("Enter FirstName:");
                string FirstName = Console.ReadLine();
                System.Console.WriteLine("Enter your Last Name:");
                string LastName = Console.ReadLine();
                System.Console.WriteLine("Enter your Email:");
                string Email = Console.ReadLine();
                System.Console.WriteLine("Enter PhoneNumber:");
                string PhoneNumber = Console.ReadLine();
                System.Console.WriteLine("Enter a new password");
                string Password = Console.ReadLine();
                System.Console.WriteLine("Enter your date of birth yyyy-mm-dd: ");
                DateTime Dob = DateTime.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Gender:");
                int Gender;
                while (!int.TryParse(Console.ReadLine(), out Gender) && Gender > 3 || Gender < 1)
                {
                    System.Console.WriteLine("Incorrect Input, Try again!");
                }
                System.Console.WriteLine("Enter Address:");
                string Address = Console.ReadLine();
                System.Console.WriteLine("Enter your Next Of Kin:");
                string NextOfKin = Console.ReadLine();
                MySqlConnection connection = null;
                connection = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"Update customer set firstName = '{FirstName}', '{LastName}', '{Email}', '{PhoneNumber}','{Password}','{Dob}', '{Gender}', '{Address}', '{NextOfKin}' where email = {email}", connection);
                connection.Open();
                command.ExecuteNonQuery();
                System.Console.WriteLine("Customer Details Updated Succesfully");
                connection.Close();
            }
            else
            {
                System.Console.WriteLine("Invalid email or password");
            }
        }
        public void FundWallet(Customer customer)
        {
            System.Console.WriteLine("Enter amount to fund your wallet");
            decimal amount = decimal.Parse(Console.ReadLine());
            customer.Wallet += amount;
            var sql = $"Update customer set Wallet = '{customer.Wallet}' where email = '{customer.Email}'";
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            System.Console.WriteLine($"Your Transaction is successful and your account has been credited with {amount}");
            connection.Close();
        }
        public void UpdateCustomerWallet(string email)
        {
            var customer = GetCustomer(email);
            if (customer != null && customer.Email == email)
            {
                Console.WriteLine("Enter the amount to fund your wallet:");
                decimal amount = decimal.Parse(Console.ReadLine());
                amount += customer.Wallet;
                MySqlConnection connection = null;
                connection = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"Update artisan set wallet = {customer.Wallet} where email = '{email}' ", connection);
                connection.Open();
                command.ExecuteNonQuery();
                System.Console.WriteLine($"Transaction successful, and your current balance is {customer.Wallet}");
                connection.Close();
            }
        }
        public void CheckWalletBalance(Customer customer)
        {
            Console.WriteLine($"Your Wallet balance is: {customer.Wallet}");
        }
        public void CashoutFromWallet(Customer customer)
        {
            System.Console.WriteLine("Enter amount to remove from your wallet");
            decimal amount = decimal.Parse(Console.ReadLine());
            customer.Wallet -= amount;
            var sql = $"Update customer set Wallet = {customer.Wallet} where email = {customer.Email}";
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            System.Console.WriteLine($"Your Transaction is successful and your account has been debited with {amount}");
            connection.Close();
        }
    }
}